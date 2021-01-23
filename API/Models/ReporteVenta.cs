namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReporteVenta")]
    public partial class ReporteVenta
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ReporteVenta()
        //{
        //    Promocion = new HashSet<Promocion>();
        //}

        [Key]
        [StringLength(11)]
        public string id_producto { get; set; }

        [StringLength(50)]
        public string nombre_prod { get; set; }

        public int? cantidad_vend { get; set; }

        public int? total_vend { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_envio { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Promocion> Promocion { get; set; }
    }
}
