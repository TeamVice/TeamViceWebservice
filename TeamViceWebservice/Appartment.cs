namespace TeamViceWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appartment")]
    public partial class Appartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appartment()
        {
            Assignment = new HashSet<Assignment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppartNo { get; set; }

        [Required]
        [StringLength(30)]
        public string AppartmentOwner { get; set; }

        public int AppartmentPhone1 { get; set; }

        public int AppartmentPhone2 { get; set; }

        public int BuildingNo { get; set; }

        public int DepId { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignment { get; set; }
    }
}
