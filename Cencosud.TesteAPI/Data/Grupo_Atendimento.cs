namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grupo_Atendimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grupo_Atendimento()
        {
            Perfil_App = new HashSet<Perfil_App>();
            Tramitacao = new HashSet<Tramitacao>();
            Aplicativo = new HashSet<Aplicativo>();
        }

        [Key]
        public int Gra_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Gra_Descricao { get; set; }

        public bool Gra_Ativo { get; set; }

        public int Mto_Id { get; set; }

        [StringLength(50)]
        public string Gra_Email { get; set; }

        public virtual Marco_Tramitacao Marco_Tramitacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfil_App> Perfil_App { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tramitacao> Tramitacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aplicativo> Aplicativo { get; set; }
    }
}
