namespace Cencosud.TesteAPI.Arguments.Funcionario
{
    public class ObterFuncionarioResponse
    {
        public string CdnFuncionario { get; set; }
        public string Numdigitoverfdorfunc { get; set; }
        public string CdnEmpresa { get; set; }
        public string CdnEstab { get; set; }
        public string NomPessoaFisic { get; set; }
        public string DatNascimento { get; set; }
        public string NomEnderRh { get; set; }
        public string CodLivre1 { get; set; }
        public string NomBairroRh { get; set; }
        public string NomCidadRh { get; set; }
        public string CodCepRh { get; set; }
        public string NomEmail { get; set; }
        public string NumDDD { get; set; }
        public string Numtelefone { get; set; }
        public string Numdddcontat { get; set; }
        public string Numtelefcontat { get; set; }
        public string Codunidfederacrh { get; set; }
        public string Codidestadfisic { get; set; }
        public string Datadmisfunc { get; set; }
        public string DesCargo { get; set; }
        public string CodIdFeder { get; set; }
        public string Desunidlotac { get; set; }
        public string Codrhccusto { get; set; }
        public string Desrhccusto { get; set; }
        public string Datdesligtofunc { get; set; }
        public string Bandeira { get; set; }

        public static explicit operator ObterFuncionarioResponse(Entities.Funcionario entidade)
        {
            return new ObterFuncionarioResponse()
            {
                CdnFuncionario = entidade.CdnFuncionario,
                Numdigitoverfdorfunc = entidade.Numdigitoverfdorfunc,
                CdnEmpresa = entidade.CdnEmpresa,
                CdnEstab = entidade.CdnEstab,
                NomPessoaFisic = entidade.NomPessoaFisic,
                DatNascimento = entidade.DatNascimento,
                NomEnderRh = entidade.NomEnderRh,
                CodLivre1 = entidade.CodLivre1,
                NomBairroRh = entidade.NomBairroRh,
                NomCidadRh = entidade.NomCidadRh,
                CodCepRh = entidade.CodCepRh,
                NomEmail = entidade.NomEmail,
                NumDDD = entidade.NumDDD,
                Numtelefone = entidade.Numtelefone,
                Numdddcontat = entidade.Numdddcontat,
                Numtelefcontat = entidade.Numtelefcontat,
                Codunidfederacrh = entidade.Codunidfederacrh,
                Codidestadfisic = entidade.Codidestadfisic,
                Datadmisfunc = entidade.Datadmisfunc,
                DesCargo = entidade.DesCargo,
                CodIdFeder = entidade.CodIdFeder,
                Desunidlotac = entidade.Desunidlotac,
                Codrhccusto = entidade.Codrhccusto,
                Desrhccusto = entidade.Desrhccusto,
                Datdesligtofunc = entidade.Datdesligtofunc,
                Bandeira = entidade.Bandeira
            };
        }
    }
}
