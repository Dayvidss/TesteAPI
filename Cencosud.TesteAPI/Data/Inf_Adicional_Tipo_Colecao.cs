namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inf_Adicional_Tipo_Colecao
    {
        [Key]
        public int Iat_Id { get; set; }

        public int Iad_Id { get; set; }

        public int Tco_Id { get; set; }

        public virtual Inf_Adicional Inf_Adicional { get; set; }

        public virtual Tipo_Colecao Tipo_Colecao { get; set; }
    }
}
