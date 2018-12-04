using Newtonsoft.Json;

namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class ObterUserResponse
    {
        [JsonProperty("p_CPF")]
        public string Cpf { get; set; }
        [JsonProperty("p_MATRICULA")]
        public string Matricula { get; set; }
        [JsonProperty("p_NOME")]
        public string Nome { get; set; }
        [JsonProperty("x_return_message")]
        public string Msg { get; set; }

        public static explicit operator ObterUserResponse(Entities.Usuario entidade)
        {
            return new ObterUserResponse()
            {
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula
            };
        }
    }
}
