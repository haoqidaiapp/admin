﻿﻿//------------------------------------------------------------
// <copyright file="UserFriendlyException.cs" company="Stluciabj">
//     Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <date>2015/3/25 14:08:12</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

using System;

namespace Hao.WebSite.Toolkits.Exceptions
{
    /// <summary>
    /// This exception type is directly shown to the user.
    /// </summary>
    public class MessageException : Exception
    {
        /// <summary>
        /// Additional information about the exception.
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public MessageException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public MessageException(string message, string details)
            : base(message)
        {
            Details = details;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public MessageException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        /// <param name="innerException">Inner exception</param>
        public MessageException(string message, string details, Exception innerException)
            : base(message, innerException)
        {
            Details = details;
        }
    }
}
