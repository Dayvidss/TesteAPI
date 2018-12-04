namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GrupoAtendimento_Usuario
    {
        [Key]
        public int Gru_Id { get; set; }

        public int Gra_Id { get; set; }

        public int Psa_Id { get; set; }
    }
}
