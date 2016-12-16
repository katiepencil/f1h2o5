namespace f1h2o5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverRunsRace")]
    public partial class DriverRunsRace
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriverId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RaceId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultTypeId { get; set; }

        [DisplayName("Race Time")]
        public decimal? RaceTime { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Race Race { get; set; }

        [DisplayName("Type of race result")]
        public virtual RaceResultType RaceResultType { get; set; }
    }
}
