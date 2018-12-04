namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ambiente")]
    public partial class Ambiente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ambiente()
        {
            Aplicativo_Ambiente = new HashSet<Aplicativo_Ambiente>();
        }

        [Key]
        public int Ame_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ame_Nome { get; set; }

        public bool Ame_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aplicativo_Ambiente> Aplicativo_Ambiente { get; set; }
    }
}
