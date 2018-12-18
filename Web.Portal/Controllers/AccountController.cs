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
using System.Web.Mvc;
using Hao.WebSite.Toolkits;

namespace Hao.WebSite.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 用户登录首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password, string username)
        {
            UserIdentity.CurrentUser = new ManagerDto() { UserId = 1, UserName = "admin" };
            return Redirect("/System/Index");

            //var msg = "";

            //if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(username))
            //{
            //    msg = "请输入账号密码。";
            //    ViewBag.msg = msg;
            //    return View();

            //}

            //var sysUsers = sysUserManager.GetManagerByAccount(username);
            //if (sysUsers == null || sysUsers.Count == 0)
            //{
            //    msg = "用户或者密码输入错误。";
            //}
            //else
            //{
            //    msg = "密码输入错误。";
            //}

            //if (sysUsers != null)
            //{
            //    foreach (var managerDto in sysUsers)
            //    {
            //        if (managerDto.Password.Equals(password.Trim()))
            //        {
            //            UserIdentity.CurrentUser = managerDto;
            //            return Redirect("/SysUser/Index");
            //        }
            //    }
            //}

            //ViewBag.msg = msg;
            return View();

        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            var limit = Request.Cookies.Count;
            for (var i = 0; i < limit; i++)
            {
                var cookieName = Request.Cookies[i]?.Name;
                var aCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                Response.Cookies.Add(aCookie);
            }

            return Redirect("/");
        }
    }
}