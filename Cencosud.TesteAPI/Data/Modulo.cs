namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Modulo")]
    public partial class Modulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modulo()
        {
            Funcao = new HashSet<Funcao>();
        }

        [Key]
        public int Mdo_Id { get; set; }

        public int Mdo_Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Mdo_Nome { get; set; }

        public int Mdo_Ordem { get; set; }

        [StringLength(50)]
        public string Mdo_CssClassIcon { get; set; }

        public bool Mdo_Menu { get; set; }

        public bool Mdo_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcao> Funcao { get; set; }
    }
}
