namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Autorizante_App
    {
        [Key]
        public int Aap_Id { get; set; }

        public int Pap_Id { get; set; }

        public int Psa_Id { get; set; }

        public byte? Aap_OrdemAutoriz { get; set; }

        public virtual Perfil_App Perfil_App { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
