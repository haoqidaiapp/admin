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
    
    public partial class MatchRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatchRecord()
        {
            this.MatchQuestion = new HashSet<MatchQuestion>();
            this.MatchRemarks = new HashSet<MatchRemarks>();
        }
    
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Number { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string MatchingResutl { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchQuestion> MatchQuestion { get; set; }
        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchRemarks> MatchRemarks { get; set; }
    }
}
