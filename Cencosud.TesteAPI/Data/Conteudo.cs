namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conteudo")]
    public partial class Conteudo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conteudo()
        {
            Perfil_App_Conteudo = new HashSet<Perfil_App_Conteudo>();
        }

        [Key]
        public int Cto_Id { get; set; }

        public int Cta_Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Cto_Titulo { get; set; }

        [Required]
        public string Cto_Conteudo { get; set; }

        public bool Cto_Ativo { get; set; }

        public DateTime Cto_DataCriacao { get; set; }

        public DateTime? Cto_DataPublicacao { get; set; }

        public DateTime? Cto_DataExpiracao { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfil_App_Conteudo> Perfil_App_Conteudo { get; set; }
    }
}
