//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hao.Infrastructure.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatchRemarks
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int PatientId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<int> LastModifierUserId { get; set; }
        public Nullable<int> MatchRecord_Id { get; set; }
    
        public virtual MatchRecord MatchRecord { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual SysUser SysUser { get; set; }
        public virtual SysUser SysUser1 { get; set; }
    }
}
