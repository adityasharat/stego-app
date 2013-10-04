using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace StegoApp{

    class Text {

        /// <summary>
        /// Reads and returns the contents of a file as a string.
        /// </summary>
        /// <param name="path">Absolute path to the file</param>
        /// <returns>Text as string</returns>
        public static string readText(string path){  
            try {
                return File.ReadAllText(path);
            } catch (Exception ex) {
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strToEncrypt"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Encrypt(string strToEncrypt, string key)
        {
            try
            {
                TripleDESCryptoServiceProvider crypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
                
                byte[] byteHash, byteBuff;
                
                string strTempKey = key;
                
                byteHash = hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                hash = null;
                
                crypto.Key = byteHash;
                crypto.Mode = CipherMode.ECB; //CBC, CFB
                
                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);

                return Convert.ToBase64String(crypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message + ".\n Encryption Failed. Please try again.");
            }
        }

        /// <summary>
        /// Decrypt the given string using the specified key.
        /// </summary>
        /// <param name="strEncrypted">The string to be decrypted.</param>
        /// <param name="key">The decryption key.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="Exception">Unexpected Exception</exception>
        public static string Decrypt(string strEncrypted, string key)
        {
            try
            {
                TripleDESCryptoServiceProvider decrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                
                string tempKey = key;
                
                byteHash = hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(tempKey));
                
                hash = null;
                
                decrypto.Key = byteHash;
                decrypto.Mode = CipherMode.ECB; //CBC, CFB
                
                byteBuff = Convert.FromBase64String(strEncrypted);
                
                string strDecrypted = ASCIIEncoding.ASCII.GetString(decrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                decrypto = null;
                
                return strDecrypted;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message + ".\n Decryption Failed. Please start over..!");
            }
        }
    }
}
