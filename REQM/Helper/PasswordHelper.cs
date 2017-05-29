using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace REQM.Helper
{
    public static class PasswordHelper
    {
        /// <summary>
        /// 字符串加密算法
        /// </summary>
        /// <param name="s">要加密的字符</param>
        /// <returns>加密后的字符</returns>
        public static string GetMd5HashStr(string s)
        {
            Encoding ascii = Encoding.ASCII;
            string EncryptString;
            EncryptString = "";
            for (int i = 0; i < s.Length; i++)
            {
                int j;
                byte[] b = new byte[1];
                j = Convert.ToInt32(ascii.GetBytes(s[i].ToString())[0]);
                j = j + 5;
                b[0] = Convert.ToByte(j);
                EncryptString = EncryptString + ascii.GetString(b);
            }
            return EncryptString;
        }
        /// <summary>
        /// 解密字符串算法
        /// </summary>
        /// <param name="s">要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string Decryptor(string s)
        {
            Encoding ascii = Encoding.ASCII;
            string DecryptorString;
            DecryptorString = "";
            for (int i = 0; i < s.Length; i++)
            {
                int j;
                byte[] b = new byte[1];
                j = Convert.ToInt32(ascii.GetBytes(s[i].ToString())[0]);
                j = j - 5;
                b[0] = Convert.ToByte(j);
                DecryptorString = DecryptorString + ascii.GetString(b);
            }
            return DecryptorString;
        }
    }
}