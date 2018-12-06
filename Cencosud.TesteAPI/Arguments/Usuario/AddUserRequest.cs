using Newtonsoft.Json;

namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class AddUserRequest
    {
        [JsonProperty("cpf")]
        public string Cpf { get ; set ; }
        [JsonProperty("matricula")]
        public string Matricula { get ; set ; }
        [JsonProperty("nome")]
        public string Nome { get ; set ; }
        [JsonProperty("perfil")]
        public string Perfil { get ; set ; }
        [JsonProperty("loja")]
        public int Loja { get ; set ; }
        [JsonProperty("acao")]
        public int Acao { get ; set ; }
        [JsonProperty("cod_agp")]
        public string Cod_agp { get ; set ; }
        [JsonProperty("origem")]
        public int Origem { get ; set ; }

        protected AddUserRequest()
        {

        }

        public AddUserRequest(string cpf, string matricula, string nome, string perfil, int loja, int acao, string cod_agp)
        {
            Cpf = cpf;
            Matricula = matricula;
            Nome = nome;
            Perfil = perfil;
            Loja = loja;
            Acao = acao;
            Cod_agp = cod_agp;
            Origem = 1;
        }

        public static explicit operator AddUserRequest(Entities.Usuario entidade)
        {
            return new AddUserRequest()
            {
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula,
                Nome = entidade.Nome,
                Perfil = entidade.Perfil,
                Loja = entidade.Loja,
                Acao = entidade.Acao,
                Cod_agp = entidade.Cod_agp,
                Origem = entidade.Origem
            };
        }
    }
}
