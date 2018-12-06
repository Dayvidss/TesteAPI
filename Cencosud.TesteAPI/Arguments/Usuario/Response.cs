using Newtonsoft.Json;

namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class Response
    {
        [JsonProperty("p_CPF")]
        public string Cpf { get; set; }
        [JsonProperty("p_MATRICULA")]
        public string Matricula { get; set; }
        [JsonProperty("p_LOJA")]
        public int Loja { get; set; }
        [JsonProperty("p_NOME")]
        public string Nome { get; set; }
        [JsonProperty("x_return_message")]
        public string Msg { get; set; }

        public static explicit operator Response(Entities.Usuario entidade)
        {
            return new Response()
            {
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula
            };
        }
    }
}
