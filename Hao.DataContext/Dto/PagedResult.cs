﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedResult.cs" company="Stluciabj">
//   Stluciabj copyright.
// </copyright>
// <author>李天赐</author>
// <summary>
//   PagedResult，分页结果
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Hao.Infrastructure.Dto
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public class PagedResult<TEntity>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="list">数据列表</param>
        public PagedResult(int pageIndex, int pageSize, int recordCount, IEnumerable<TEntity> list)
        {
            List = list;
            PageIndex = pageIndex;
            PageSize = pageSize;
            RecordCount = recordCount;
        }

        public PagedResult() { }

        /// <summary>
        /// 数据列表
        /// </summary>
        public IEnumerable<TEntity> List { get; private set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; }

        /// <summary>
        /// 页的总数
        /// </summary>
        public int PageCount
        {
            get { return Convert.ToInt32(Math.Ceiling((double)RecordCount / PageSize)); }
        }

        /// <summary>
        /// 附加信息，在分页中需要补充的信息
        /// </summary>
        public string ExtrMessage { get; set; }
    }
}
