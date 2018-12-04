namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bandeira")]
    public partial class Bandeira
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bandeira()
        {
            Loja = new HashSet<Loja>();
        }

        [Key]
        public int Bna_Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Bna_Sigla { get; set; }

        [Required]
        [StringLength(80)]
        public string Bna_Nome { get; set; }

        public bool Bna_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loja> Loja { get; set; }
    }
}
