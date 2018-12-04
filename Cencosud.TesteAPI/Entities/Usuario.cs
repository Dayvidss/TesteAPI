namespace Cencosud.TesteAPI.Entities
{
    public class Usuario
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
    }
}
