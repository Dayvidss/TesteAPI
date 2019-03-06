using Newtonsoft.Json;

namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class Request
    {
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
        [JsonProperty("matricula")]
        public string Matricula { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("perfil")]
        public string Perfil { get; set; }
        [JsonProperty("loja")]
        public int Loja { get; set; }
        [JsonProperty("acao")]
        public int Acao { get; set; }
        [JsonProperty("cod_agp")]
        public string Cod_agp { get; set; }
        [JsonProperty("origem")]
        public int Origem { get; set; }
        [JsonProperty("senha")]
        public string Senha { get; set; }

        protected Request()
        {

        }

        public Request(string cpf, string matricula, int loja, int acao, int origem)
        {
            Cpf = cpf;
            Matricula = matricula;
            Loja = loja;
            Acao = acao;
            Origem = origem;
        }

        public Request(string cpf, string matricula, string nome, string perfil, int loja, int acao, int origem, string cod_agp, string senha)
        {
            Cpf = cpf;
            Matricula = matricula;
            Nome = nome;
            Perfil = perfil;
            Loja = loja;
            Acao = acao;
            Cod_agp = cod_agp;
            Origem = origem;
            Senha = senha;
        }

        public static explicit operator Request(Entities.Usuario entidade)
        {
            return new Request()
            {
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula,
                Loja = entidade.Loja
            };
        }
    }
}
