namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pessoa_Solicitacao
    {
        [Key]
        public int Pso_Id { get; set; }

        public int Slo_Id { get; set; }

        public int Psa_Id { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Solicitacao Solicitacao { get; set; }
    }
}
