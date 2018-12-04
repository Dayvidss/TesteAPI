namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            Pessoa_Solicitacao = new HashSet<Pessoa_Solicitacao>();
        }

        [Key]
        public int Psa_Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Psa_Cpf { get; set; }

        [StringLength(100)]
        public string Psa_Matricula { get; set; }

        [Required]
        [StringLength(100)]
        public string Psa_Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Psa_NomeApresentacao { get; set; }

        [StringLength(20)]
        public string Psa_NumRG { get; set; }

        [StringLength(10)]
        public string Psa_OrgaoExpRG { get; set; }

        [StringLength(2)]
        public string Psa_UfRG { get; set; }

        [StringLength(14)]
        public string Psa_Telefone1 { get; set; }

        [StringLength(14)]
        public string Psa_Telefone2 { get; set; }

        [StringLength(50)]
        public string Psa_Email { get; set; }

        [StringLength(100)]
        public string Psa_CargoRH { get; set; }

        [StringLength(100)]
        public string Psa_Setor { get; set; }

        [StringLength(100)]
        public string Psa_Departamento { get; set; }

        [StringLength(100)]
        public string Psa_UnidadeNegocio { get; set; }

        public bool Psa_Ativo { get; set; }

        public int Lja_Id { get; set; }

        public virtual Loja Loja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pessoa_Solicitacao> Pessoa_Solicitacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
