//------------------------------------------------------------
// <copyright file="JsonModelBinder.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>李天赐</author>
// <date>2015/4/3 17:53:29</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Hao.WebSite.Toolkits.Mvc.ModelBinder
{
    /// <summary>
    /// JsonModelBinder
    /// </summary>
    public class JsonModelBinder : IModelBinder
    {
        private readonly static JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var stringified = controllerContext.HttpContext.Request[bindingContext.ModelName];
            if (string.IsNullOrEmpty(stringified))
            {
                return null;
            }
            var model = Serializer.Deserialize(stringified, bindingContext.ModelType);
            return model;
        }
    }
}
