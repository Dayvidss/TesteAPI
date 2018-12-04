namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aplicativo")]
    public partial class Aplicativo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aplicativo()
        {
            Aplicativo1 = new HashSet<Aplicativo>();
            Aplicativo_Ambiente = new HashSet<Aplicativo_Ambiente>();
            Grupo_Atendimento = new HashSet<Grupo_Atendimento>();
        }

        [Key]
        public int Apo_Id { get; set; }

        public int? Apo_IdPai { get; set; }

        [Required]
        [StringLength(50)]
        public string Apo_Nome { get; set; }

        public bool Apo_Ativo { get; set; }

        [StringLength(3)]
        public string Apo_Sigla { get; set; }

        [StringLength(1000)]
        public string Apo_Descricao { get; set; }

        public int Apo_Ordem { get; set; }

        public int? Apo_Sla { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aplicativo> Aplicativo1 { get; set; }

        public virtual Aplicativo Aplicativo2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aplicativo_Ambiente> Aplicativo_Ambiente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupo_Atendimento> Grupo_Atendimento { get; set; }
    }
}
