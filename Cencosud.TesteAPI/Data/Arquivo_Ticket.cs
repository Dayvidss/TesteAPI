namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Arquivo_Ticket
    {
        [Key]
        public int Att_Id { get; set; }

        public int Tct_Id { get; set; }

        [Required]
        public byte[] Att_File { get; set; }

        [Required]
        [StringLength(100)]
        public string Att_Name { get; set; }

        public bool Att_Ativo { get; set; }

        public int? psa_id { get; set; }

        public DateTime? Att_DataCriacao { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
