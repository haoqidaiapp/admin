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
using System.Globalization;
using System.Linq;

namespace Hao.WebSite.Toolkits.Helper
{
    /// <summary>
    /// 随机数生成辅助类
    /// </summary>
    public class RandomNumberHelper
    {
        /// <summary>
        /// The get random number.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetRandomNumber(int length =10)
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var r = rand.Next(99999999).ToString(CultureInfo.InvariantCulture);
            var result = string.Empty;
            if (r.Length >= length)
            {
                return result + r;
            }

            for (var i = 0; i < length - r.Length; i++)
            {
                result += "0";
            }

            return result + r;
        }


        /// <summary>
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>
        /// <returns>string</returns>
        public static string GuidTo16String()
        {
            var i = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current * ((int)b + 1));
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
