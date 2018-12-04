namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdTable")]
    public partial class AdTable
    {
        public DateTime? whenCreated { get; set; }

        [StringLength(4000)]
        public string lockoutTime { get; set; }

        public int? userAccountControl { get; set; }

        [StringLength(4000)]
        public string samAccountName { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Psa_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Uso_Login { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Uso_Senha { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Uso_Ativo { get; set; }

        public byte? Uso_Tipo { get; set; }
    }
}
