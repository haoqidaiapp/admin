// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   首页控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

namespace Hao.WebSite.Toolkits.Helper
{
    /// <summary>
    /// MD5加密算法
    /// </summary>
    public class EncryptHelper
    {
        /// <summary> 
        /// MD5　32位加密 
        /// </summary> 
        /// <param name="str">字符串</param> 
        /// <returns>返回MD5 32位加密以后的字符串</returns> 
        public static string MD5With32(string str)
        {
            var temp = string.Empty;

            if (str == null) return temp;

            var md5 = MD5.Create();

            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　 
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得 
            for (var i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                temp = temp + s[i].ToString("X2");
            }

            return temp;
        }


        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <returns>加密后的Base64字符串</returns>
        public static string EncodeBase64(string source)
        {
            if (source == null) return string.Empty;

            var bytes = Encoding.UTF8.GetBytes(source);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64 解密
        /// </summary>
        /// <param name="result">待解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            if (result == null) return string.Empty;

            var bytes = Convert.FromBase64String(result);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
