//------------------------------------------------------------
// <copyright file="FromJsonAttribute.cs" company="WIKI Tec">
//     WIKI Tec copyright.
// </copyright>
// <author>李天赐</author>
// <date>2015/4/3 17:54:15</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

using System.Web.Mvc;

namespace Hao.WebSite.Toolkits.Mvc.ModelBinder
{
    /// <summary>
    /// 提供JsonModelBinder的CustomModelBinderAttribute
    /// </summary>
    public class FromJsonAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }    
    }
}
