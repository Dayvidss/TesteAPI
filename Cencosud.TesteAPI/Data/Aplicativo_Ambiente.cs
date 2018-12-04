namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aplicativo_Ambiente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aplicativo_Ambiente()
        {
            Perfil_App = new HashSet<Perfil_App>();
        }

        [Key]
        public int Apa_Id { get; set; }

        public int Ame_Id { get; set; }

        public int Apo_Id { get; set; }

        public virtual Ambiente Ambiente { get; set; }

        public virtual Aplicativo Aplicativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfil_App> Perfil_App { get; set; }
    }
}
