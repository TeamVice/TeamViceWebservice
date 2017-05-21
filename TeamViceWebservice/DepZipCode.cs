namespace TeamViceWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepZipCode")]
    public partial class DepZipCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepZipCode()
        {
            Department = new HashSet<Department>();
        }

        [Key]
        [Column("DepZipCode")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepZipCode1 { get; set; }

        [Required]
        [StringLength(30)]
        public string DepCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Department { get; set; }
    }
}
