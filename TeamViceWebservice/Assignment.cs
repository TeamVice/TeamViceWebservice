namespace TeamViceWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assignment")]
    public partial class Assignment
    {
        [Key]
        public int AssignId { get; set; }

        [Required]
        [StringLength(30)]
        public string AssignTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string AssignText { get; set; }

        public int AssignRankNo { get; set; }

        [Required]
        [StringLength(100)]
        public string AssignComment { get; set; }

        public int DepId { get; set; }

        public int EmployeeId { get; set; }

        public int AppartNo { get; set; }

        public virtual Appartment Appartment { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
