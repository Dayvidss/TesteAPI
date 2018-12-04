using Cencosud.TesteAPI.Arguments.Usuario;
using Cencosud.TesteAPI.Data;
using Cencosud.TesteAPI.Enums;
using Cencosud.TesteAPI.Services;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Cencosud.TesteAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            int teste = 2;

            AGP contexto = new AGP();
            var path1 = @"C:\Temp\logAgpObter.txt";
            //var path2 = @"C:\Temp\logAgpAdd.txt";
            var fi1 = new FileInfo(path1);
            //var fi2 = new FileInfo(path2);
            var sw1 = fi1.CreateText();
            //var sw2 = fi2.CreateText();

            var query = contexto.Pessoa
                .Where(x => x.Psa_CargoRH.Contains("Atendente") || x.Psa_CargoRH.Contains("Operador Caixa"))
                .Where(x => x.Lja_Id != 1 && x.Lja_Id != 2 && x.Lja_Id != 128)
                .Where(x => x.Psa_Matricula.Length >= 7)
                //.Where(x=>x.Usuario.Uso_Login == "EB9149" )
                .Take(10)
                .Select(x => new { x.Psa_Cpf, x.Psa_Matricula, x.Psa_Nome, x.Lja_Id, x.Loja.Lja_Nome, x.Usuario.Uso_Login })
                .ToList();

            if (teste == (int)TipoServico.Emporium)
            {
                Random r = new Random();

                foreach (var item in query)
                {
                    //var totvs = new Servico((int)TipoServico.TOTVS).ConsultaTOTVSAsync(item.Psa_Cpf);
                    var cpf = item.Psa_Cpf;
                    //var matricula = totvs.Result.CdnFuncionario + totvs.Result.Numdigitoverfdorfunc;
                    var matricula = item.Psa_Matricula;
                    var nome = item.Psa_Nome;
                    var perfil = string.Empty;
                    //var loja = int.Parse(totvs.Result.CdnEstab);
                    var loja = int.Parse(item.Lja_Nome.Substring(2, 3));

                    var lj = Convert.ToInt32(loja);

                    var cod_agp = r.Next(10000000, 99999999).ToString();

                    if (item.Lja_Nome.Substring(0, 2) == "GB" || item.Lja_Nome.Substring(0, 2) == "MA")
                    {
                        perfil = "GB_OPERA";
                    }
                    else
                    {
                        perfil = item.Lja_Nome.Substring(0, 2) + "_OPCX";
                    }

                    //var user1 = new ObterUserRequest(cpf, matricula, (int)TipoAcao.Consulta);
                    //var user2 = new AddUserRequest(item.Psa_Cpf, matricula, nome, perfil, loja, (int)TipoAcao.Inclusão, cod_agp);

                    //var r1 = new Servico((int)TipoServico.Emporium).ObterUsuario(user1);
                    //var r2 = new Servico((int)TipoServico.Emporium).ObterUsuario(user2);
                    Console.WriteLine(string.Format("=> {0}|{1}|{2}|{3}|{4}|{5}", cpf, matricula, nome, perfil, loja, cod_agp));
                    sw1.WriteLine(string.Format("=> {0}|{1}|{2}|{3}|{4}|{5}", cpf, matricula, nome, perfil, loja, cod_agp));
                }
            }
            else if (teste == (int)TipoServico.ActiveDirectory)
            {
                foreach (var item in query)
                {
                    var login = item.Uso_Login;
                    if (login is null)
                    {
                        Console.WriteLine(string.Format("A Matricula {0} do Funcionário(a) {1}, não tem cadastro de rede", item.Psa_Matricula, item.Psa_Nome));
                        sw1.WriteLine(string.Format("A Matricula {0} do Funcionário(a) {1}, não tem cadastro de rede", item.Psa_Matricula, item.Psa_Nome));
                    }
                    else
                    {
                        var user = new Servico((int)TipoServico.ActiveDirectory).ConsultaAD(login).Result;

                        Console.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}"
                            , user.Nome
                            , user.NomeApresentacao
                            , user.Matricula
                            , user.Usuario
                            , user.Email
                            , user.tel1
                            , user.tel2
                            , user.Departamento
                            , user.Gerente.Replace("OU=", "").Replace("CN=", "").Replace("DC=", "")
                            , user.cpf
                            , user.cargo
                            , user.loja
                            , user.Caminho.Replace("OU=", "/").Replace("CN=", "/").Replace("DC=", "/").Replace(",", "")
                            , user.Empresa
                            , user.Grupos.Replace("OU=", "").Replace("CN=", "").Replace("DC=", "")
                            , user.HomePage
                            , user.Status));
                        sw1.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}"
                            , user.Nome
                            , user.NomeApresentacao
                            , user.Matricula
                            , user.Usuario
                            , user.Email
                            , user.tel1
                            , user.tel2
                            , user.Departamento
                            , user.Gerente.Replace("OU=", "").Replace("CN=", "").Replace("DC=", "")
                            , user.cpf
                            , user.cargo
                            , user.loja
                            , user.Caminho.Replace("OU=", "/").Replace("CN=", "/").Replace("DC=", "/").Replace(",", "")
                            , user.Empresa
                            , user.Grupos.Replace("OU=", "").Replace("CN=", "").Replace("DC=", "")
                            , user.HomePage
                            , user.Status));
                    }
                }
            }

            sw1.Close();
            //sw2.Close();
            Console.WriteLine("Finalizado...");
            Console.ReadKey();
        }
    }
}
