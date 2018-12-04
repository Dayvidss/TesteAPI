namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inf_Adicional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inf_Adicional()
        {
            Inf_Adicional_Tipo_Colecao = new HashSet<Inf_Adicional_Tipo_Colecao>();
            Valor_Informacao = new HashSet<Valor_Informacao>();
        }

        [Key]
        public int Iad_Id { get; set; }

        public int Tia_Id { get; set; }

        public int Pap_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Iad_Label { get; set; }

        public int? Iad_Tamanho { get; set; }

        public bool Iad_PermiteNull { get; set; }

        public string Iad_ValorDefault { get; set; }

        public bool Iad_Ativo { get; set; }

        public int? Iad_Ordem { get; set; }

        public string Iad_Explicacao { get; set; }

        public virtual Perfil_App Perfil_App { get; set; }

        public virtual Tipo_Inf_Adicional Tipo_Inf_Adicional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inf_Adicional_Tipo_Colecao> Inf_Adicional_Tipo_Colecao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valor_Informacao> Valor_Informacao { get; set; }
    }
}
