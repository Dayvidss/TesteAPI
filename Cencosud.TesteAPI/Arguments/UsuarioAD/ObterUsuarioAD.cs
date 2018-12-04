using Newtonsoft.Json;

namespace Cencosud.TesteAPI.Arguments.UsuarioAD
{
    public class ObterUsuarioAD
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("nomeApresentacao")]
        public string NomeApresentacao { get; set; }
        [JsonProperty("matricula")]
        public string Matricula { get; set; }
        [JsonProperty("usuario")]
        public string Usuario { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("tel1")]
        public string tel1 { get; set; }
        [JsonProperty("tel2")]
        public string tel2 { get; set; }
        [JsonProperty("departamento")]
        public string Departamento { get; set; }
        [JsonProperty("gerente")]
        public string Gerente { get; set; }
        [JsonProperty("cpf")]
        public string cpf { get; set; }
        [JsonProperty("cargo")]
        public string cargo { get; set; }
        [JsonProperty("loja")]
        public string loja { get; set; }
        [JsonProperty("caminho")]
        public string Caminho { get; set; }
        [JsonProperty("empresa")]
        public string Empresa { get; set; }
        [JsonProperty("grupos")]
        public string Grupos { get; set; }
        [JsonProperty("homePage")]
        public string HomePage { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
