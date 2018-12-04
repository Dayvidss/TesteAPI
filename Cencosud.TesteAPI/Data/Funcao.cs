namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Funcao")]
    public partial class Funcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcao()
        {
            Acao = new HashSet<Acao>();
        }

        [Key]
        public int Fno_Id { get; set; }

        public int Mdo_Id { get; set; }

        public int Fno_Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Fno_Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Fno_Endereco { get; set; }

        public int Fno_Ordem { get; set; }

        [StringLength(50)]
        public string Fno_CssClassIcon { get; set; }

        public bool Fno_Menu { get; set; }

        public bool Fno_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acao> Acao { get; set; }

        public virtual Modulo Modulo { get; set; }
    }
}
