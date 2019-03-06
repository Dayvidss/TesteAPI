using Cencosud.TesteAPI.Arguments.Funcionario;
using Cencosud.TesteAPI.Arguments.Usuario;
using Cencosud.TesteAPI.Arguments.UsuarioAD;
using Cencosud.TesteAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cencosud.TesteAPI.Services
{
    public class Servico
    {
        HttpClient cliente = new HttpClient();
        private Uri ApiURI;
        private readonly string token = "FrguEYrZ17ky52bGNNC5lDUsJVTfmBmYcXZocKk9WMzGv2a859HZyCzSu9Uf7Grq";

        public Servico(int operacao)
        {
            if (operacao == 0)
            {
                //cliente.BaseAddress = new Uri("http://g300603sv894:3001/");
                cliente.BaseAddress = new Uri("http://g300603nt113:3001/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                ApiURI = cliente.BaseAddress;
            }
            else if (operacao == 1)
            {
                cliente.BaseAddress = new Uri("http://g300603sv091:57772/webservices/GBarbosa.WS.AGP.Service.cls?");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                ApiURI = cliente.BaseAddress;
            }
            else if (operacao == 2)
            {
                cliente.BaseAddress = new Uri("http://localhost:8090/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                ApiURI = cliente.BaseAddress;
            }
        }

        public async Task<Response> ApiEmporiumUserAsync(Request request)
        {
            try
            {
                string uri = ApiURI + "api/Emporium/UserAGPHomolog";
                var serializedAgent = JsonConvert.SerializeObject(request);
                var content = new StringContent(serializedAgent, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(uri, content);

                var result = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<Response>(result.Remove(0, result.IndexOf("p_CPF") - 2).Substring(0, result.Remove(0, 12).Length - 1));

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Não foi possível efetuar consulta aos dados do usuário: Erro - {0}", e.Message));
            }
        }

        public async Task<ObterFuncionarioResponse> ConsultaTOTVSAsync(string request)
        {
            try
            {
                var uri = ApiURI + "soap_method=ConsultaFuncionario&cpf=" + request;
                var response = await cliente.GetAsync(uri);
                var result = response.Content.ReadAsStringAsync().Result;
                var doc = new XmlDocument();
                doc.LoadXml(result);
                var xnList = doc.GetElementsByTagName("ItemFuncionario");
                var user = new Funcionario()
                {
                    CdnFuncionario = xnList[0]["cdnFuncionario"].InnerText,
                    Numdigitoverfdorfunc = xnList[0]["numdigitoverfdorfunc"].InnerText,
                    CdnEmpresa = xnList[0]["cdnEmpresa"].InnerText,
                    CdnEstab = xnList[0]["cdnEstab"].InnerText,
                    NomPessoaFisic = xnList[0]["nomPessoaFisic"].InnerText,
                    DatNascimento = xnList[0]["datNascimento"].InnerText,
                    NomEnderRh = xnList[0]["nomEnderRh"].InnerText,
                    CodLivre1 = xnList[0]["codLivre1"].InnerText,
                    NomBairroRh = xnList[0]["nomBairroRh"].InnerText,
                    NomCidadRh = xnList[0]["nomCidadRh"].InnerText,
                    CodCepRh = xnList[0]["codCepRh"].InnerText,
                    NomEmail = xnList[0]["nomEmail"].InnerText,
                    NumDDD = xnList[0]["numDDD"].InnerText,
                    Numtelefone = xnList[0]["numtelefone"].InnerText,
                    Numdddcontat = xnList[0]["numdddcontat"].InnerText,
                    Numtelefcontat = xnList[0]["numtelefcontat"].InnerText,
                    Codunidfederacrh = xnList[0]["codunidfederacrh"].InnerText,
                    Codidestadfisic = xnList[0]["codidestadfisic"].InnerText,
                    Datadmisfunc = xnList[0]["datadmisfunc"].InnerText,
                    DesCargo = xnList[0]["desCargo"].InnerText,
                    CodIdFeder = xnList[0]["codIdFeder"].InnerText,
                    Desunidlotac = xnList[0]["desunidlotac"].InnerText,
                    Codrhccusto = xnList[0]["codrhccusto"].InnerText,
                    Desrhccusto = xnList[0]["desrhccusto"].InnerText,
                    Datdesligtofunc = xnList[0]["datdesligtofunc"].InnerText,
                    Bandeira = xnList[0]["bandeira"].InnerText
                };

                return (ObterFuncionarioResponse)user;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Não foi possível efetuar consulta aos dados do usuário: Erro - {0}", e.Message));
            }
        }

        public async Task<ObterUsuarioAD> ConsultaAD(string request)
        {
            try
            {
                string uri = ApiURI + "api/UsuarioAD/ListarPorLogin?request=" + request;

                var response = await cliente.GetAsync(uri);
                var result = response.Content.ReadAsStringAsync().Result;

                var user = JsonConvert.DeserializeObject<ObterUsuarioAD>(result);

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Não foi possível efetuar consulta aos dados do usuário: Erro - {0}", e.Message));
            }
        }
    }
}
