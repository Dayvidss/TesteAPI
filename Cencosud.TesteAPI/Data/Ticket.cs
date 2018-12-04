namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Arquivo_Ticket = new HashSet<Arquivo_Ticket>();
            Registro_Massivo = new HashSet<Registro_Massivo>();
            Ticket1 = new HashSet<Ticket>();
            Tramitacao = new HashSet<Tramitacao>();
        }

        [Key]
        public int Tct_Id { get; set; }

        public int? Tct_IdPai { get; set; }

        public int Slo_Id { get; set; }

        public int Tct_Prioridade { get; set; }

        [StringLength(300)]
        public string Tct_InfAdicional { get; set; }

        public int Pap_Id { get; set; }

        public int Tct_Tipo { get; set; }

        [StringLength(100)]
        public string Tct_NumTicket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arquivo_Ticket> Arquivo_Ticket { get; set; }

        public virtual Perfil_App Perfil_App { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registro_Massivo> Registro_Massivo { get; set; }

        public virtual Solicitacao Solicitacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket1 { get; set; }

        public virtual Ticket Ticket2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tramitacao> Tramitacao { get; set; }
    }
}
