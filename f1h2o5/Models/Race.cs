namespace f1h2o5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Race")]
    public partial class Race
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Race()
        {
            DriverRunsRaces = new HashSet<DriverRunsRace>();
        }

        [DisplayName("Race ID")]
        public int RaceId { get; set; }

        [DisplayName("Race name")]
        [Required]
        [StringLength(128)]
        public string RaceName { get; set; }

        public int LocationId { get; set; }

        [DisplayName("Year of race")]
        public int RaceYear { get; set; }

        [DisplayName("Race start date")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverRunsRace> DriverRunsRaces { get; set; }
    }
}
