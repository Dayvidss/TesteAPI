namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parametro")]
    public partial class Parametro
    {
        [Key]
        public int Pro_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Pro_Nome { get; set; }

        [Required]
        [StringLength(4000)]
        public string Pro_Valor { get; set; }
    }
}
