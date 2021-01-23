namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banco")]
    public partial class Banco
    {
        [Key]
        public int idDatos { get; set; }

        [Required]
        [StringLength(3)]
        public string AccountCompanyId { get; set; }

        public int? Amount { get; set; }
        
        public long CardNumber { get; set; }

        public int? Cvv { get; set; }
    }
}
