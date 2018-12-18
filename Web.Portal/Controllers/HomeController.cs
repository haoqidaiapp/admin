//// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   首页控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Hao.Infrastructure;
using System.Web.Mvc;
using Hao.WebSite.Toolkits;

namespace Hao.WebSite.Controllers
{
    /// <summary>
    /// 首页控制器
    /// </summary>
    public class HomeController : AppAuthorizeController
    {
        /// <summary>
        /// 系统首页
        /// </summary>
        /// <returns>返回试图页面</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}