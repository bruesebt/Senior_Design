using System;
using System.Collections.Generic;
using System.Text;
using WhatsTheMove.Data.Models;

namespace WhatsTheMove.Core.ViewModels
{
    public class SignUpViewModel : Common.ViewModelBase
    {
        #region Commands

        public Common.Command SignUpCommand => new Common.Command(SignUp);

        #endregion

        #region Constructors

        public SignUpViewModel()
        {

        }

        #endregion

        #region Properties

        public User User
        {
            get => _user;
            set => UpdateOnPropertyChanged(ref _user, value);
        }
        private User _user = new User();

        #endregion

        #region Methods

        private void SignUp(object param)
        {
            LoggedInUserChanged(User);
        }

        #endregion

    }
}
