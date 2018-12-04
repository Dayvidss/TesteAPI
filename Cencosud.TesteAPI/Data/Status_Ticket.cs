namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status_Ticket
    {
        [Key]
        public int Stt_Id { get; set; }

        [Required]
        [StringLength(2)]
        public string Stt_Status { get; set; }

        public DateTime? Stt_Data { get; set; }

        [StringLength(4000)]
        public string Stt_Observacao { get; set; }

        public int Tro_Id { get; set; }

        public int Psa_Id { get; set; }

        public virtual Tramitacao Tramitacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
