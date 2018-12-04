namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Marco_Tramitacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marco_Tramitacao()
        {
            Grupo_Atendimento = new HashSet<Grupo_Atendimento>();
            Tramitacao = new HashSet<Tramitacao>();
        }

        [Key]
        public int Mto_Id { get; set; }

        public byte Mto_Etapa { get; set; }

        [Required]
        [StringLength(30)]
        public string Mto_Nome { get; set; }

        public bool Mto_Ativo { get; set; }

        public int? Mto_Anterior { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupo_Atendimento> Grupo_Atendimento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tramitacao> Tramitacao { get; set; }
    }
}
