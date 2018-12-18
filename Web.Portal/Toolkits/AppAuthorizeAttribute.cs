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
using System.Web.Mvc;

namespace Hao.WebSite.Toolkits
{
    /// <summary>
    /// 需要权限的控制器基类
    /// </summary>
    public class AppAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Action执行之前调用
        /// </summary>
        /// <param name="filterContext">
        /// 过滤器上下文
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var isAjaxRequest = filterContext.HttpContext.Request.Headers["X-Requested-With"] != null && filterContext.HttpContext.Request.Headers["X-Requested-With"].ToLower() == "xmlhttprequest";
            var controllerName = filterContext.RouteData.Values["controller"].ToString();


            // 没有经过登录验证
            if (UserIdentity.CurrentUser == null)
            {
                if (isAjaxRequest)
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.Result = new JsonResult
                    {
                        Data = new { errorMessage = "抱歉，您的登录已经失效，请刷新页面重试！" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    return;
                }

                // 同步请求，直接返回登录页面
                filterContext.Result = new RedirectResult("/account/login");
                return;
            }

            //if (filterContext.ActionDescriptor.IsDefined(typeof(AnonymousAttribute), true))
            //{
            //    return;
            //}

            // 默认开放首页权限
            if (controllerName.ToLower() == "home")
            {
                return;
            }
        }
    }

}