namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hotel")]
    public partial class hotel
    {
        [StringLength(15)]
        public string nombreServicio { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int precio { get; set; }

        [StringLength(30)]
        public string detalles { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int habitacion { get; set; }
    }
}
