namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        [Key]
        public int Bnr_Id { get; set; }

        public int Tbr_Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Bnr_Nome { get; set; }

        [Required]
        public byte[] Bnr_File { get; set; }

        [StringLength(1000)]
        public string Bnr_Link { get; set; }

        public int Bnr_Ordem { get; set; }

        public bool Bnr_Ativo { get; set; }

        public virtual Tipo_Banner Tipo_Banner { get; set; }
    }
}
