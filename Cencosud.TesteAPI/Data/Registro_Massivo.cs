namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registro_Massivo
    {
        [Key]
        public int Reg_Id { get; set; }

        [Required]
        public string Reg_Valor { get; set; }

        public string Reg_Retorno { get; set; }

        public int Tct_Id { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
