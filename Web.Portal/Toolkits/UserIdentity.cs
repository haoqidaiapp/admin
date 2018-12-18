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
using System.Web;

namespace Hao.WebSite.Toolkits
{
    /// <summary>
    /// The user identity.
    /// </summary>
    public class UserIdentity
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public static ManagerDto CurrentUser
        {
            get
            {
                try
                {
                    var user = HttpContext.Current.Session["CurrentUserDto"];
                    return user as ManagerDto;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            set
            {
                HttpContext.Current.Session["CurrentUserDto"] = value;
            }
        }
    }

    public class ManagerDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}