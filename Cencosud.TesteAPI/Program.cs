using Cencosud.TesteAPI.Arguments.Usuario;
using Cencosud.TesteAPI.Data;
using Cencosud.TesteAPI.Enums;
using Cencosud.TesteAPI.Services;
using System;
using System.IO;
using System.Linq;

namespace Cencosud.TesteAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            int teste = 0;

            Console.WriteLine("Quantos registros para efetuar o teste de stress:");
            int qtd = int.Parse(Console.ReadLine());
            Console.WriteLine("Será testado o serviço do AD?");
            string op = Console.ReadLine();

            var tIni = DateTime.Now.TimeOfDay;
            var tfim = new TimeSpan();

            Console.Clear();
            var path1 = string.Empty;
            var path2 = string.Empty;

            if (op == "S" || op == "s")
            {
                teste = 2;
                path1 = @"C:\Temp\logADObter.txt";
                path2 = @"C:\Temp\logAgpAdd.txt";
            }
            else
            {
                path1 = @"C:\Temp\logAgpObter.txt";
                path2 = @"C:\Temp\logAgpAdd.txt";
            }

            AGP contexto = new AGP();
            var fi1 = new FileInfo(path1);
            var fi2 = new FileInfo(path2);
            var sw1 = fi1.CreateText();
            var sw2 = fi2.CreateText();

            var query = contexto.Pessoa
                .Where(x => x.Psa_CargoRH.Contains("Atendente") || x.Psa_CargoRH.Contains("Operador Caixa"))
                .Where(x => x.Lja_Id != 1 && x.Lja_Id != 2 && x.Lja_Id != 128)
                .Where(x => x.Psa_Matricula.Length >= 7)
                .Where(x => x.Psa_Cpf.Length >= 11)
                //.Where(x=>x.Usuario.Uso_Login == "EB9149" )
                .Take(qtd)
                .OrderByDescending(x => x.Psa_Id)
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

                    var obterUsuario = new Request(cpf, matricula, loja, (int)TipoAcao.Consulta);
                    var addUsuario = new Request(cpf, matricula, nome, perfil, loja, (int)TipoAcao.Inclusão, cod_agp);

                    var r1 = new Servico((int)TipoServico.Emporium).ApiEmporiumUserAsync(obterUsuario);

                    if (r1.Result.Nome is null)
                    {
                        Console.WriteLine(string.Format("=> {1}|{0}|{3:000}|{2} => não tem cadastro no Emporium", matricula, cpf, nome, loja));
                        sw1.WriteLine(string.Format("=> {1}|{0}|{3:000}|{2} => não tem cadastro no Emporium", matricula, cpf, nome, loja));
                        var r2 = new Servico((int)TipoServico.Emporium).ApiEmporiumUserAsync(addUsuario);
                        sw2.WriteLine(string.Format("=> {0}|{1}|{2:000}|{3}|{4}", r2.Result.Cpf, r2.Result.Matricula, r2.Result.Loja, r2.Result.Nome, r2.Result.Msg));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("=> {0}|{1}|{2:000}|{3}|{4}", r1.Result.Cpf, r1.Result.Matricula, r1.Result.Loja, r1.Result.Nome, r1.Result.Msg));
                        sw1.WriteLine(string.Format("=> {0}|{1}|{2:000}|{3}|{4}", r1.Result.Cpf, r1.Result.Matricula, r1.Result.Loja, r1.Result.Nome, r1.Result.Msg));
                    }
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
            tfim = DateTime.Now.TimeOfDay;
            var tTotal = tfim.Subtract(tIni);
            sw1.Close();
            sw2.Close();

            if (teste == (int)TipoServico.ActiveDirectory)
            {
                Console.Clear();
                Console.WriteLine("Teste de stress na API do Active Directory realizado com sucesso...");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(string.Format("Inicio do processamento => {0:00}:{1:00}:{2:00}\nTempo gasto => {3}", tIni.Hours, tIni.Minutes, tIni.Seconds, tTotal));
                Console.WriteLine("Teste de stress na API da Emporium realizado com sucesso...");
            }
            Console.ReadKey();
        }
    }
}
