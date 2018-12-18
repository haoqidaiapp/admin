// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   首页控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Script.Serialization;

namespace Hao.WebSite.Toolkits.Helper
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 将对象转化为Json字符串   
        /// </summary>
        /// <typeparam name="T">
        /// T
        /// </typeparam>
        /// <param name="obj">
        /// 源对象
        /// </param>
        /// <returns>
        /// json数据
        /// </returns>
        public static string Obj2JsonStr<T>(T obj)
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Serialize(obj);
        }

        /// <summary>
        /// 将Json字符串转化为对象  
        /// </summary>
        /// <param name="strJson">
        /// Json字符串
        /// </param>
        /// <returns>
        /// 目标对象
        /// </returns>
        public static T JsonStr2Obj<T>(string strJson)
        {

            var serialize = new JavaScriptSerializer();
            return serialize.Deserialize<T>(strJson);
        }
    }
}