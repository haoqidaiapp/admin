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
    
    public partial class SysDisease
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysDisease()
        {
            this.SysDisease1 = new HashSet<SysDisease>();
        }
    
        public int Id { get; set; }
        public string Value { get; set; }
        public Nullable<int> ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime ModifyTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysDisease> SysDisease1 { get; set; }
        public virtual SysDisease SysDisease2 { get; set; }
    }
}