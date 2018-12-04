namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log_Sistema
    {
        [Key]
        public int Lsa_Id { get; set; }

        public int Psa_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Lsa_TabelaOrigem { get; set; }

        public int Lsa_IdRegistro { get; set; }

        [Required]
        [StringLength(20)]
        public string Lsa_Acao { get; set; }

        public DateTime Lsa_Data { get; set; }

        [Required]
        [StringLength(255)]
        public string Lsa_Pagina { get; set; }

        public string Lsa_Observacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
