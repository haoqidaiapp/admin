// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   首页控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Web.Mvc;
using Hao.Infrastructure;
using Hao.WebSite.Toolkits;

namespace Hao.WebSite.Controllers
{
    public class SystemController : AppController
    {
        /// <summary>
        /// 系统首页
        /// </summary>
        /// <returns>返回试图页面</returns>
        public ActionResult Index()
        {
            ViewBag.System = "start active open";
            ViewBag.SystemAction = "open active";
            return View();
        }

        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="optionType"></param>
        /// <returns>返回json</returns>
        public JsonResult GetPageList(int pageIndex, int pageSize, int optionType)
        {
            var list = SystemServices.GetPageListDic(pageIndex, pageSize, optionType);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}

