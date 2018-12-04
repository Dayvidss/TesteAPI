namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Colecao")]
    public partial class Colecao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Colecao()
        {
            Valor_Informacao = new HashSet<Valor_Informacao>();
        }

        [Key]
        public int Clo_Id { get; set; }

        public int Tco_Id { get; set; }

        [StringLength(1000)]
        public string Clo_Chave { get; set; }

        [Required]
        [StringLength(100)]
        public string Clo_Valor { get; set; }

        public bool Clo_Ativo { get; set; }

        public int? Clo_IdPai { get; set; }

        [StringLength(1000)]
        public string Clo_ValorOculto1 { get; set; }

        [StringLength(1000)]
        public string Clo_ValorOculto2 { get; set; }

        [StringLength(1000)]
        public string Clo_ValorOculto3 { get; set; }

        public virtual Tipo_Colecao Tipo_Colecao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valor_Informacao> Valor_Informacao { get; set; }
    }
}
