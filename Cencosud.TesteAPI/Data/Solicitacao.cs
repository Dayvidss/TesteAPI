namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Solicitacao")]
    public partial class Solicitacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitacao()
        {
            Pessoa_Solicitacao = new HashSet<Pessoa_Solicitacao>();
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        public int Slo_Id { get; set; }

        public int Slo_NumTicketCAU { get; set; }

        [StringLength(4000)]
        public string Slo_InfAdicional { get; set; }

        public DateTime Slo_DataAbertura { get; set; }

        public DateTime? Slo_DataFechamento { get; set; }

        [StringLength(20)]
        public string Slo_CentroCusto { get; set; }

        [StringLength(1)]
        public string Slo_NotaPesqSatisfacao { get; set; }

        [StringLength(4000)]
        public string Slo_ObsPesqSatisfacao { get; set; }

        public int Psa_IdCadastro { get; set; }

        public byte? Slo_Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pessoa_Solicitacao> Pessoa_Solicitacao { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
