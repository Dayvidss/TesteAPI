namespace Cencosud.TesteAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permissao")]
    public partial class Permissao
    {
        [Key]
        public int Pro_Id { get; set; }

        public int Prl_Id { get; set; }

        public int Aco_Id { get; set; }

        public virtual Acao Acao { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
