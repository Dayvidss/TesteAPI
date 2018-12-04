namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Valor_Informacao
    {
        [Key]
        public int Vin_Id { get; set; }

        public int Tct_Id { get; set; }

        public int Iad_Id { get; set; }

        public int? Clo_Id { get; set; }

        public string Vin_Valor { get; set; }

        public virtual Colecao Colecao { get; set; }

        public virtual Inf_Adicional Inf_Adicional { get; set; }
    }
}
