namespace f1h2o5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            Drivers = new HashSet<Driver>();
        }

        [DisplayName("Team ID#")]
        public int TeamId { get; set; }

        [DisplayName("Team name")]
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [DisplayName("Country ID#")]
        public int CountryId { get; set; }

        [StringLength(128)]
        public string Boat { get; set; }

        [StringLength(128)]
        public string Sponsor { get; set; }

        [StringLength(128)]
        public string Manager { get; set; }

        [DisplayName("Team year")]
        public int TeamYear { get; set; }

        [DisplayName("Base Country")]
        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
