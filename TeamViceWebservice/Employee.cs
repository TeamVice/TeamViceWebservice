namespace TeamViceWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Assignment = new HashSet<Assignment>();
        }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        public int EmployeePhone { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeTitle { get; set; }

        public int DepId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignment { get; set; }

        public virtual Department Department { get; set; }
    }
}
