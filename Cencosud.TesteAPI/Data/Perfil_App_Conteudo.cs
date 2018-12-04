namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Perfil_App_Conteudo
    {
        [Key]
        public int Pac_id { get; set; }

        public int Pap_id { get; set; }

        public int Cto_id { get; set; }

        public virtual Conteudo Conteudo { get; set; }

        public virtual Perfil_App Perfil_App { get; set; }
    }
}
