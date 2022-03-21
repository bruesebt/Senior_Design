using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;
using WhatsTheMove.Core.Services;
using System.Threading.Tasks;
using WhatsTheMove.Core.Common;

namespace WhatsTheMove.Core.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {

        #region Fields

        public override IUserService UserService { get => _userService; }
        private IUserService _userService;

        #endregion

        #region Commands

        public Common.Command SignUpCommand => new Common.Command(SignUp);

        public Common.Command BackToLoginCommand => new Common.Command(BackToLogin);

        #endregion

        #region Constructors

        public SignUpViewModel(IUserService userService)
        {
            _userService = userService;
            InitializeUser();
        }

        #endregion

        #region Properties

        public User User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private User _user = new User();

        /// <summary>
        /// Message to display to the user under certain conditions
        /// </summary>
        public string UserActionResponse
        {
            get => _userActionResponse;
            set => UpdateOnPropertyChanged(ref _userActionResponse, value);
        }
        private string _userActionResponse = string.Empty;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes any properties of the User
        /// </summary>
        private void InitializeUser()
        {
            User.DateOfBirth = DateTime.Today;
            User.DateAdded = DateTime.Today;

            // eventually use location services to get zip code?
        }

        /// <summary>
        /// Validates user fields and signs up the user
        /// </summary>
        /// <param name="param"></param>
        private async void SignUp(object param)
        {
            // Validate fields
            if (!await IsUserInputValid())
                return;

            // Sign the user up. if it fails, display error message and return false
            if (!await UserService.SignUp(User))
            {                
                UserActionResponse = "Error occurred when creating new account.";
                return;
            }                        
        }

        /// <summary>
        /// Returns the active page back to the Login Page
        /// </summary>
        /// <param name="param"></param>
        private void BackToLogin(object param)
        {
            OnChangeViewRequested(Enums.ViewRoute.Login);
        }

        /// <summary>
        /// Checks to see whether the information input by the user are valid
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsUserInputValid()
        {
            string message = string.Empty;

            // validate each field
            if (string.IsNullOrEmpty(User.FirstName))
                message = "First Name cannot be empty.";
            else if (string.IsNullOrEmpty(User.LastName))
                message = "Last Name cannot be empty.";
            else if (User.DateOfBirth == DateTime.MinValue)
                message = "Date of birth must be a valid date.";
            else if (string.IsNullOrEmpty(User.ZipCode))
                message = "ZIP Code cannot be empty.";
            else if (string.IsNullOrEmpty(User.Email))
                message = "Email cannot be empty.";
            else if (string.IsNullOrEmpty(User.Username))
                message = "Username cannot be empty.";
            else if (string.IsNullOrEmpty(User.Password))
                message = "Password cannot be empty.";
            else if (string.IsNullOrEmpty(User.PasswordConfirmed) || !User.Password.Equals(User.PasswordConfirmed))
                message = "Passwords must match.";
            else if (!User.Password.IsPlainTextPasswordValid())
                message = "Password must contain at least 8 characters with at least one of each: a lower case letter, an upper case letter, a number, and a special character ('@', '#', '$', '%', '^', '&', '+', '=', '!', '*', '(', ')')";
            else
            {
                User storedUser = await API.UserProcessor.LoadUser(User.Username);
                if (storedUser != null)
                    message = "A user with that username already exists.";
            }

            // if message is not empty, display to user and return false
            if (!string.IsNullOrEmpty(message))
            {
                UserActionResponse = message;
                User.Password = string.Empty;
                User.PasswordConfirmed = string.Empty;
                return false;
            }

            return true;
        }

         #endregion

        }
}
