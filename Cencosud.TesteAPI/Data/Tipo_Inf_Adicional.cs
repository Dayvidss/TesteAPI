namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Inf_Adicional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Inf_Adicional()
        {
            Inf_Adicional = new HashSet<Inf_Adicional>();
        }

        [Key]
        public int Tia_Id { get; set; }

        public int Tia_Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Tia_Nome { get; set; }

        public bool Tia_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inf_Adicional> Inf_Adicional { get; set; }
    }
}
