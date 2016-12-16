namespace f1h2o5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RaceResultType")]
    public partial class RaceResultType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceResultType()
        {
            DriverRunsRaces = new HashSet<DriverRunsRace>();
        }

        [DisplayName("Race result type ID")]
        [Key]
        public int ResultTypeId { get; set; }

        [DisplayName("Type of race result")]
        [Required]
        [StringLength(128)]
        public string ResultTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverRunsRace> DriverRunsRaces { get; set; }
    }
}
