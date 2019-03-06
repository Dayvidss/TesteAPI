using Cencosud.TesteAPI.Arguments.Usuario;
using Cencosud.TesteAPI.Data;
using Cencosud.TesteAPI.Enums;
using Cencosud.TesteAPI.Resources;
using Cencosud.TesteAPI.Services;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace Cencosud.TesteAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            int teste = 0;

            Console.WriteLine("Quantos registros para efetuar o teste de stress:");
            int qtd = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantos caracteres deve ter a senha: ");
            int senhaQtd = int.Parse(Console.ReadLine());
            Console.WriteLine("Será testado o serviço do AD?");
            string op = Console.ReadLine();

            var tIni = DateTime.Now.TimeOfDay;
            var tfim = new TimeSpan();
            var dtInicial = DateTime.Today.AddMonths(-12);

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

            try
            {
                var query = from slo in contexto.Solicitacao
                            join psa in contexto.Pessoa on slo.Psa_IdCadastro equals psa.Psa_Id
                            join tct in contexto.Ticket on slo.Slo_Id equals tct.Slo_Id
                            join pap in contexto.Perfil_App on tct.Pap_Id equals pap.Pap_Id
                            join apa in contexto.Aplicativo_Ambiente on pap.Apa_Id equals apa.Apa_Id
                            join apo in contexto.Aplicativo on apa.Apo_Id equals apo.Apo_Id
                            where slo.Slo_DataAbertura >= dtInicial
                            where apo.Apo_Nome.StartsWith("Sol")
                            where psa.Psa_CargoRH.StartsWith("op") || psa.Psa_CargoRH.StartsWith("aten")
                            where psa.Lja_Id != 1
                            where psa.Lja_Id != 2
                            where psa.Lja_Id != 128
                            //where psa.Psa_Cpf != "51080044515" || psa.Psa_Cpf != "83694870504" || psa.Psa_Cpf != "83471456520" || psa.Psa_Cpf != "03454659388"
                            where psa.Psa_Cpf != "03454659388"
                            select new { psa.Psa_Cpf, psa.Psa_Matricula, psa.Psa_CargoRH, psa.Psa_Nome, psa.Lja_Id, psa.Loja.Lja_Nome, psa.Usuario.Uso_Login };

                //var query = contexto.Pessoa
                //    .Where(x => x.Psa_CargoRH.Contains("Atendente") || x.Psa_CargoRH.Contains("Operador Caixa"))
                //    .Where(x => x.Lja_Id != 1 && x.Lja_Id != 2 && x.Lja_Id != 128)
                //    .Where(x => x.Psa_Matricula.Length >= 7)
                //    .Where(x => x.Psa_Cpf.Length >= 11)
                //    //.Where(x=>x.Usuario.Uso_Login == "EB9149" )
                //    .Take(qtd)
                //    .OrderByDescending(x => x.Psa_Id)
                //    .Select(x => new { x.Psa_Cpf, x.Psa_Matricula, x.Psa_Nome, x.Lja_Id, x.Loja.Lja_Nome, x.Usuario.Uso_Login })
                //    .ToList();


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
                        var cargo = item.Psa_CargoRH;
                        var perfil = string.Empty;
                        //var loja = int.Parse(totvs.Result.CdnEstab);
                        var loja = int.Parse(item.Lja_Nome.Substring(2, 3));
                        int origem = 0;

                        var lj = Convert.ToInt32(loja);

                        var qtdCaracter = senhaQtd;
                        StringBuilder ini = new StringBuilder();
                        StringBuilder fim = new StringBuilder();

                        for (int i = 0; i < qtdCaracter - 1; i++)
                        {
                            ini.Append("0");
                            fim.Append("9");
                        }

                        var numIni = "1" + ini.ToString();
                        var numFim = "9" + fim.ToString();

                        var cod_agp = r.Next(int.Parse(numIni), int.Parse(numFim)).ToString();
                        var s = r.Next(int.Parse(numIni), int.Parse(numFim)).ToString();
                        var senha = Criptografia.Base64Cifra(s);

                        if (item.Lja_Nome.Substring(0, 2) == "GB" || item.Lja_Nome.Substring(0, 2) == "MA")
                        {
                            perfil = "GB_OPERA";
                            origem = (int)Origem.VAREJO;
                        }
                        else if (item.Lja_Nome.Substring(0, 2) == "PE")
                        {
                            perfil = "PE_OPERADOR_CAIXA";
                            origem = (int)Origem.PERINI;
                        }
                        else
                        {
                            perfil = item.Lja_Nome.Substring(0, 2) + "_OPCX";
                            origem = (int)Origem.VAREJO;
                        }

                        var obterUsuario = new Request(cpf, matricula, loja, (int)TipoAcao.Consulta, origem);
                        var addUsuario = new Request(cpf, matricula, nome, perfil, loja, (int)TipoAcao.Inclusão, origem, cod_agp, senha);

                        var r1 = new Servico((int)TipoServico.Emporium).ApiEmporiumUserAsync(obterUsuario);

                        if (r1.Result.Nome is null)
                        {
                            Console.WriteLine(string.Format("=> {1}|{0}|{3:000}|{2} => não tem cadastro no Emporium", matricula, cpf, nome, loja, senha));
                            sw1.WriteLine(string.Format("=> {1}|{0}|{3:000}|{2} => não tem cadastro no Emporium - {4}", matricula, cpf, nome, loja, r1.Result.Msg));
                            var r2 = new Servico((int)TipoServico.Emporium).ApiEmporiumUserAsync(addUsuario);
                            sw2.WriteLine(string.Format("=> {0}|{1}|{2:000}|{3}|{4} {5}", r2.Result.Cpf, r2.Result.Matricula, r2.Result.Loja, r2.Result.Nome, r2.Result.Msg, senha));
                            break;
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
            }
            finally
            {
                sw1.Close();
                sw2.Close();
            }
            //Console.ReadKey();
        }
    }
}
