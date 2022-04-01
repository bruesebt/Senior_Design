using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using WhatsTheMove.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTheMove.Core.Common
{
    public static class PasswordHelper
    {

        #region Constants

        public const int SALT_SIZE = 32; // size in bytes
        public const int HASH_SIZE = 32; // size in bytes
        public const int ITERATIONS = 100000; // number of pbkdf2 iterations

        #endregion

        #region Methods

        /// <summary>
        /// Compares the user being input to the user stored in the database to validate
        /// </summary>
        /// <param name="inputUser"></param>
        /// <param name="storedUser"></param>
        /// <returns></returns>
        public static bool IsUser(this User inputUser, User storedUser)
        {
            return storedUser.Password.Equals(ByteArrayToString(CreateHash(inputUser.Password, StringToByteArray(storedUser.HashKey))));
        }

        /// <summary>
        /// Updates the password, password confirmed, and password salt of the user being input (should be a new user)
        /// </summary>
        /// <param name="inputUser"></param>
        /// <returns></returns>
        public static User CreateUserCredentials(this User inputUser)
        {
            inputUser.HashKey = ByteArrayToString(CreateSalt());
            inputUser.Password = ByteArrayToString(CreateHash(inputUser.Password, StringToByteArray(inputUser.HashKey)));
            inputUser.PasswordConfirmed = ByteArrayToString(CreateHash(inputUser.PasswordConfirmed, StringToByteArray(inputUser.HashKey)));

            return inputUser;
        }

        /// <summary>
        /// Updates the password and password confirmed of the user being updated (should be a current user)
        /// </summary>
        /// <param name="inputUser"></param>
        /// <returns></returns>
        public static User UpdateUserCredentials(this User inputUser)
        {
            inputUser.Password = ByteArrayToString(CreateHash(inputUser.Password, StringToByteArray(inputUser.HashKey)));
            inputUser.PasswordConfirmed = ByteArrayToString(CreateHash(inputUser.PasswordConfirmed, StringToByteArray(inputUser.HashKey)));

            return inputUser;
        }

        /// <summary>
        /// Generates a password reset key for the user, emails it to the user, and saves hashed version
        /// </summary>
        /// <param name="inputUser"></param>
        /// <returns></returns>
        public async static Task<User> NotifyPasswordResetRequest(this User inputUser)
        {
            // generate password key, plain
            string resetKey = GenerateResetKey();

            // email key to user
            string html = EmailHelper.GetResetHtml(resetKey, inputUser.Username);
            EmailHelper.SendEmail(inputUser.Email, html, "What's The Move? Password Reset 1-Time Code");

            // hash key and store in db
            inputUser.ForgotPasswordKey = ByteArrayToString(CreateHash(resetKey, StringToByteArray(inputUser.HashKey)));
            inputUser = await API.UserProcessor.UpdateUser(inputUser);

            return inputUser;
        }

        /// <summary>
        /// Sends an email to user notifying them of email being reset, and updates database with new data
        /// </summary>
        /// <param name="inputUser"></param>
        /// <returns></returns>
        public async static Task<User> NotifyPasswordReset(this User inputUser)
        {
            inputUser = await API.UserProcessor.UpdateUser(inputUser);

            string html = EmailHelper.GetResetNotifyHtml(inputUser.Username);
            EmailHelper.SendEmail(inputUser.Email, html, "What's The Move? Account Password Reset");

            return inputUser;
        }

        /// <summary>
        /// Checks to see if the input reset key matches what is stored for the user in the database
        /// </summary>
        /// <param name="inputUser"></param>
        /// <param name="resetKey"></param>
        /// <returns></returns>
        public static bool IsResetKeyValid(this User inputUser, string resetKey)
        {
            string hashedKey = ByteArrayToString(CreateHash(resetKey, StringToByteArray(inputUser.HashKey)));

            return hashedKey.Equals(inputUser.ForgotPasswordKey);
        }

        /// <summary>
        /// Generates byte array based on input password and salt to be used as hashed password
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static byte[] CreateHash(string input, byte[] salt)
        {
            // Generate the hash
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS);
            return pbkdf2.GetBytes(HASH_SIZE);
        }

        /// <summary>
        /// Generates byte array to be used as Salt
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateSalt()
        {
            // Generate a salt
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);

            return salt;
        }

        /// <summary>
        /// Generates a random string to be used as a key to reset password for a user
        /// </summary>
        /// <returns></returns>
        public static string GenerateResetKey()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            return provider.GetHashCode().ToString();
        }

        /// <summary>
        /// Converts byte array to string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] array)
        {
            string arrayStr = $"{array[0]}";
            for (int i = 1; i < array.Length; i++)
                arrayStr += $".{array[i]}";

            return arrayStr;
        }

        /// <summary>
        /// Converts string to byte array
        /// </summary>
        /// <param name="arrayStr"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string arrayStr)
        {
            byte[] array = new byte[SALT_SIZE];
            int index = 0;

            foreach (string substring in arrayStr.Split('.'))
            {
                array[index] = Convert.ToByte(int.Parse(substring));
                index++;
            }

            return array;
        }

        /// <summary>
        /// Checks input password to see if it meets all requirements
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsPlainTextPasswordValid(this string password)
        {
            // Number of valid conditions
            bool[] conditions = new bool[5];

            // First Condition: Length of password should be equal to or greater than 8
            conditions[0] = password.Length >= 8;

            // Iterate over characters in password to validate other conditions
            foreach (char character in password)
            {
                // Should contain at least one lower case letter
                if (character >= 'a' && character <= 'z' && !conditions[1])
                    conditions[1] = true;

                // Should contain at least one upper case letter
                if (character >= 'A' && character <= 'Z' && !conditions[2])
                    conditions[2] = true;

                // Should contain at least one number
                if (character >= '0' && character <= '9' && !conditions[3])
                    conditions[3] = true;
            }

            // Should contain at least one special character from below
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '!', '*', '(', ')' };
            conditions[4] = !(password.IndexOfAny(special) == -1);

            // return true iff all conditions are true (satisfied). If any are false (not satisfied), returns false
            return !conditions.Any(c => !c);           
        }

        #endregion

    }
}
