namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Constrinfo")]
    public partial class Constrinfo
    {
        [Key]
        public int Ctr_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ctr_Nome { get; set; }

        [Required]
        [StringLength(4000)]
        public string Ctr_Descricao { get; set; }

        [Required]
        [StringLength(15)]
        public string Ctr_Tipo { get; set; }
    }
}
