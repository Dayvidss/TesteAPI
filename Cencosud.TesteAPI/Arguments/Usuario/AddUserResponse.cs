using Newtonsoft.Json;
using System.Text;

namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class AddUserResponse
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

        public static explicit operator AddUserResponse(Entities.Usuario entidade)
        {
            return new AddUserResponse()
            {
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula,
                Nome = entidade.Nome
            };
        }

        public override string ToString()
        {
            var caracter = '-';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append(caracter);
            }
            return sb.ToString()
                + "\n"
                + "=> " + Cpf
                + "=> " + Matricula
                + "=> " + Nome
                + "=> " + Msg;
        }
    }
}
