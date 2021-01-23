namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promocion")]
    public partial class Promocion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_promocion { get; set; }

        [StringLength(11)]
        public string id_producto { get; set; }

        [StringLength(50)]
        public string nombreProm { get; set; }

        [StringLength(50)]
        public string infoPromocion { get; set; }

        public int? cantidadProducto { get; set; }

        public int? descuento { get; set; }

        [StringLength(10)]
        public string codigoPromo { get; set; }

        [StringLength(15)]
        public string area { get; set; }

        public bool? aprobacion { get; set; }

        public virtual ReporteVenta ReporteVenta { get; set; }
    }
}
