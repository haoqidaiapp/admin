using System;
using System.Collections.Generic;
using System.Linq;
using Hao.Infrastructure.DataContext;
using Hao.Infrastructure.Dto;

namespace Hao.Infrastructure
{
    /// <summary>
    /// 系服务
    /// </summary>
    public class SystemServices
    {
        /// <summary>
        /// 获得所有字典数据
        /// </summary>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">页码</param>
        /// <returns></returns>
        public static PagedResult<SysDictionaryDto> GetPageListDic(int pageIndex, int pageSize, int type)
        {
            using (var db = new HaoEntities())
            {
                var count = db.SysDictionary.Count();

                var query = db.SysDictionary.OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).Select(a => new SysDictionaryDto
                    {
                        Id = a.Id,
                        CreateTime = a.CreateTime.ToString(),
                        Type = a.Type,
                        Sort = a.Sort,
                        Value = a.Value
                    }).ToList();

                return new PagedResult<SysDictionaryDto>(pageIndex, pageSize, count, query);
            }
        }
    }
}
