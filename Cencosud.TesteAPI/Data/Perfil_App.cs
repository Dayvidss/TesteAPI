namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Perfil_App
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Perfil_App()
        {
            Autorizante_App = new HashSet<Autorizante_App>();
            Inf_Adicional = new HashSet<Inf_Adicional>();
            Perfil_App_Conteudo = new HashSet<Perfil_App_Conteudo>();
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        public int Pap_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Pap_Nome { get; set; }

        public bool Pap_Ativo { get; set; }

        public bool Pap_AtendAutomatico { get; set; }

        public int Apa_Id { get; set; }

        public int? Gra_Id { get; set; }

        public virtual Aplicativo_Ambiente Aplicativo_Ambiente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autorizante_App> Autorizante_App { get; set; }

        public virtual Grupo_Atendimento Grupo_Atendimento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inf_Adicional> Inf_Adicional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfil_App_Conteudo> Perfil_App_Conteudo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
