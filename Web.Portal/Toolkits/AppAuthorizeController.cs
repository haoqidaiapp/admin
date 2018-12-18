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

namespace Hao.WebSite.Toolkits
{
    /// <summary>
    /// 需要权限的控制器基类
    /// </summary>
    [Mvc.Filter.Exception(View = "Error")]
    [AppAuthorize]
    public class AppAuthorizeController : Controller
    {
    }
}