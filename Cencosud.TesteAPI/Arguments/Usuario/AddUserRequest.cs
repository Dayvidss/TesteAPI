namespace Cencosud.TesteAPI.Arguments.Usuario
{
    public class AddUserRequest
    {
        private string cpf;
        private string matricula;
        private string nome;
        private string perfil;
        private int loja;
        private int acao;
        private string cod_agp;
        private int origem;

        public string Cpf { get => cpf; set => cpf = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Perfil { get => perfil; set => perfil = value; }
        public int Loja { get => loja; set => loja = value; }
        public int Acao { get => acao; set => acao = value; }
        public string Cod_agp { get => cod_agp; set => cod_agp = value; }
        public int Origem { get => origem; set => origem = value; }

        protected AddUserRequest()
        {

        }

        public AddUserRequest(string cpf, string matricula, string nome, string perfil, int loja, int acao, string cod_agp)
        {
            this.Cpf = cpf;
            this.Matricula = matricula;
            this.Nome = nome;
            this.Perfil = perfil;
            this.Loja = loja;
            this.Acao = acao;
            this.Cod_agp = cod_agp;
            this.Origem = 1;
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
