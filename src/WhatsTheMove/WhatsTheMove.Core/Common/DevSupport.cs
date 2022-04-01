using System;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using WhatsTheMove.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace WhatsTheMove.Core.Common
{
    public static class DevSupport
    {

        #region Fields

        private static byte[] _key;

        private static byte[] _vector;

        private static byte[] _email;

        private static byte[] _password;

        private static ICryptoTransform _decryptorTransform;

        private static System.Text.UTF8Encoding _utfEncoder;

        #endregion

        #region Properties

        /// <summary>
        /// Developer support email address
        /// </summary>
        public static string DeveloperEmailAddress { get => GetSupportEmail(); }

        /// <summary>
        /// Developer support password
        /// </summary>
        public static string DeveloperPassword { get => GetSupportPassword(); }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes developer account, should be called on application startup
        /// </summary>
        public async static Task InitializeDeveloper()
        {
            // Encryption Method
            RijndaelManaged rm = new RijndaelManaged();

            // Key and Vector for Encryption, stored in database
            User developer = await API.UserProcessor.LoadUser(username: "whatsthemovesupport");
            _key = PasswordHelper.StringToByteArray(developer.HashKey);
            _vector = PasswordHelper.StringToByteArray(developer.ForgotPasswordKey).Take(16).ToArray();
            _email = PasswordHelper.StringToByteArray(developer.Email);
            _password = PasswordHelper.StringToByteArray(developer.Password);

            // Initialize decryptor using encryption method, key, and vector.
            _decryptorTransform = rm.CreateDecryptor(_key, _vector);

            //Used to translate bytes to text and vice versa
            _utfEncoder = new System.Text.UTF8Encoding();
        }        

        /// <summary>
        /// Returns the email address associated with the developer support account
        /// </summary>
        /// <returns></returns>
        private static string GetSupportEmail()
        {
            return DecryptString(PasswordHelper.ByteArrayToString(_email));
        }

        /// <summary>
        /// Returns the password associated with the developer support account
        /// </summary>
        /// <returns></returns>
        private static string GetSupportPassword()
        {            
            return DecryptString(PasswordHelper.ByteArrayToString(_password));
        }

        /// <summary>
        /// Decrypts the encrypted string to plain text
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <returns></returns>
        private static string DecryptString(string encryptedString)
        {
            return Decrypt(PasswordHelper.StringToByteArray(encryptedString));
        }

        /// <summary>
        /// Decrypts the encrypted byte array
        /// </summary>
        /// <param name="encryptedValue"></param>
        /// <returns></returns>        
        private static string Decrypt(byte[] encryptedValue)
        {
            // Write the encrypted value to the decryption stream
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream decryptStream = new CryptoStream(encryptedStream, _decryptorTransform, CryptoStreamMode.Write);
            decryptStream.Write(encryptedValue, 0, encryptedValue.Length);
            decryptStream.FlushFinalBlock();

            // Read the decrypted value from the stream.
            encryptedStream.Position = 0;
            Byte[] decryptedBytes = new Byte[encryptedStream.Length];
            encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
            encryptedStream.Close();
            return _utfEncoder.GetString(decryptedBytes);
        }

        #endregion

    }
}
