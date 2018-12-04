namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acao")]
    public partial class Acao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acao()
        {
            Permissao = new HashSet<Permissao>();
        }

        [Key]
        public int Aco_Id { get; set; }

        public int Fno_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Aco_Nome { get; set; }

        public bool Aco_Padrao { get; set; }

        public virtual Funcao Funcao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permissao> Permissao { get; set; }
    }
}
