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
    
    public partial class SysRelated
    {
        public int Id { get; set; }
        public Nullable<int> SysQuestionOptionId { get; set; }
        public int SysQuestionId { get; set; }
        public Nullable<int> SysOption_Id { get; set; }
    
        public virtual SysOption SysOption { get; set; }
    }
}
