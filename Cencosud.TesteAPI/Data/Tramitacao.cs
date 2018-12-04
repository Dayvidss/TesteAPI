namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tramitacao")]
    public partial class Tramitacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tramitacao()
        {
            Status_Ticket = new HashSet<Status_Ticket>();
        }

        [Key]
        public int Tro_Id { get; set; }

        public int Mto_Id { get; set; }

        public int Psa_idOrigem { get; set; }

        public int? Psa_IdDestino { get; set; }

        public int? Gra_IdDestino { get; set; }

        public DateTime Tro_DtTramitacao { get; set; }

        [StringLength(4000)]
        public string Tro_Observacao { get; set; }

        public int Tct_Id { get; set; }

        public virtual Grupo_Atendimento Grupo_Atendimento { get; set; }

        public virtual Marco_Tramitacao Marco_Tramitacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Status_Ticket> Status_Ticket { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
