namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Colecao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Colecao()
        {
            Colecao = new HashSet<Colecao>();
            Inf_Adicional_Tipo_Colecao = new HashSet<Inf_Adicional_Tipo_Colecao>();
        }

        [Key]
        public int Tco_Id { get; set; }

        public int Tco_Codigo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Tco_Nome { get; set; }

        public bool Tco_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Colecao> Colecao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inf_Adicional_Tipo_Colecao> Inf_Adicional_Tipo_Colecao { get; set; }
    }
}
