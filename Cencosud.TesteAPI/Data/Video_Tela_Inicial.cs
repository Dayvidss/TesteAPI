namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video_Tela_Inicial
    {
        [Key]
        public int Vdo_Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Vdo_Nome { get; set; }

        [Required]
        public byte[] Vdo_File { get; set; }

        public bool Vdo_Ativo { get; set; }

        public DateTime Vdo_Data { get; set; }
    }
}
