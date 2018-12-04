namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acesso")]
    public partial class Acesso
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Acs_DataAcesso { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Acs_Login { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string Acs_IP { get; set; }
    }
}
