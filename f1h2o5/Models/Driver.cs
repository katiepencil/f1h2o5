namespace f1h2o5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Driver")]
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            DriverRunsRaces = new HashSet<DriverRunsRace>();
        }

        [DisplayName("Driver ID")]
        public int DriverId { get; set; }

        [DisplayName("First name")]
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [DisplayName("Address")]
        [StringLength(128)]
        public string Address1 { get; set; }

        [DisplayName("Address line 2")]
        [StringLength(128)]
        public string Address2 { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [DisplayName("State or Province")]
        [Column("State/Province")]
        [StringLength(128)]
        public string State_Province { get; set; }

        [DisplayName("Postal code")]
        [StringLength(128)]
        public string PostalCode { get; set; }

        public int CountryId { get; set; }

        [StringLength(128)]
        public string Phone { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(128)]
        public string DOB { get; set; }

        [DisplayName("Photo")]
        [StringLength(128)]
        public string ImageUrl { get; set; }

        [StringLength(800)]
        public string Bio { get; set; }

        [DisplayName("Team ID#")]
        public int TeamId { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverRunsRace> DriverRunsRaces { get; set; }

        public virtual Team Team { get; set; }
    }
}
