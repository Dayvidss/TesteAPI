namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class ObterUserRequest
    {
        private string cpf;
        private string matricula;
        private int acao;
        private int origem;

        public string Cpf { get => cpf; set => cpf = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public int Acao { get => acao; set => acao = value; }
        public int Origem { get => origem; set => origem = value; }

        protected ObterUserRequest()
        {

        }

        public ObterUserRequest(string cpf, string matricula, int acao)
        {
            this.Cpf = cpf;
            this.Matricula = matricula;
            this.Acao = acao;
            this.Origem = 1;
        }

        public static explicit operator ObterUserRequest(Entities.Usuario entidade)
        {
            return new ObterUserRequest()
            {
                Cpf = entidade.Cpf,
                Matricula = entidade.Matricula,
            };
        }
    }
}
