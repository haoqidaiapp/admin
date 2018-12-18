// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppAuthorizationException.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   没有权限的异常
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Hao.WebSite.Toolkits.Exceptions
{
    /// <summary>
    /// 没有权限的异常
    /// </summary>
    public class AppAuthorizationException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public AppAuthorizationException(string message)
            : base(message)
        {
        }
    }
}
