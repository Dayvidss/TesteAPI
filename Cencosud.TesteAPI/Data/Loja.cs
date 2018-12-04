namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loja")]
    public partial class Loja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loja()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        [Key]
        public int Lja_Id { get; set; }

        public int Bna_Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Lja_Nome { get; set; }

        public bool Lja_Ativo { get; set; }

        [StringLength(100)]
        public string Lja_AD_OU { get; set; }

        [StringLength(100)]
        public string cdn_empresa_TOTVs { get; set; }

        [StringLength(100)]
        public string cdn_estab_TOTVs { get; set; }

        public virtual Bandeira Bandeira { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
