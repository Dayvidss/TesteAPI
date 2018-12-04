using Cencosud.TesteAPI.Enums;
using Cencosud.TesteAPI.Resources;
using System;

namespace Cencosud.TesteAPI.Entities
{
    public class UsuarioAD
    {
        public string Nome;
        public string NomeApresentacao;
        public string Matricula;
        public string Usuario;
        public string Email;
        public string tel1;
        public string tel2;
        public string Departamento;
        public string Gerente;
        public string cpf;
        public string cargo;
        public string loja;
        public string Caminho;
        public string Empresa;
        public string Grupos;
        public string HomePage;
        public string Status;

        public UsuarioAD()
        {

        }

        public UsuarioAD(string nome, string nomeApresentacao, string matricula, string usuario, string email, string tel1, string tel2, string departamento, string gerente, string cpf, string cargo, string loja, string caminho, string empresa, string grupos, string homepage, int status)
        {
            Nome = nome;
            NomeApresentacao = nomeApresentacao;
            Matricula = matricula;
            Usuario = usuario;
            Email = email;
            this.tel1 = tel1;
            this.tel2 = tel2;
            Departamento = departamento;
            Gerente = gerente;
            this.cpf = cpf;
            this.cargo = cargo;
            this.loja = loja;
            Caminho = caminho;
            Empresa = empresa;
            Grupos = grupos;
            HomePage = homepage;
            if (status == Convert.ToInt32(UserStatusAD.X_512_ENABLED_ACCOUNT))
            {
                Status = Message.X_512_ENABLED_ACCOUNT;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_514DISABLED_ACCOUNT))
            {
                Status = Message.X_514DISABLED_ACCOUNT;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_544_ENABLED_PASSWORD_NOT_REQUIRED))
            {
                Status = Message.X_544_ENABLED_PASSWORD_NOT_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_546_DISABLED_PASSWORD_NOT_REQUIRED))
            {
                Status = Message.X_546_DISABLED_PASSWORD_NOT_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_66048_ENABLED_PASSWORD_DOESNT_EXPIRE))
            {
                Status = Message.X_66048_ENABLED_PASSWORD_DOESNT_EXPIRE;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_66050_DISABLED_PASSWORD_DOESNT_EXPIRE))
            {
                Status = Message.X_66050_DISABLED_PASSWORD_DOESNT_EXPIRE;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_66080_ENABLED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED))
            {
                Status = Message.X_66080_ENABLED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_66082_DISABLED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED))
            {
                Status = Message.X_66082_DISABLED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_262656_ENABLED_SMARTCARD_REQUIRED))
            {
                Status = Message.X_262656_ENABLED_SMARTCARD_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_262658_DISABLED_SMARTCARD_REQUIRED))
            {
                Status = Message.X_262658_DISABLED_SMARTCARD_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_262688_ENABLED_SMARTCARD_REQUIRED_PASSWORD_NOT_REQUIRED))
            {
                Status = Message.X_262688_ENABLED_SMARTCARD_REQUIRED_PASSWORD_NOT_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_262690_DISABLED_SMARTCARD_REQUIRED_PASSWORD_NOT_REQUIRED))
            {
                Status = Message.X_262690_DISABLED_SMARTCARD_REQUIRED_PASSWORD_NOT_REQUIRED;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_328192_ENABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE))
            {
                Status = Message.X_328192_ENABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_328194_DISABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE))
            {
                Status = Message.X_328194_DISABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE;
            }
            else if (status == Convert.ToInt32(UserStatusAD.X_328224_ENABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED))
            {
                Status = Message.X_328224_ENABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED;
            }
            else
            {
                Status = Message.X_328226_DISABLED_SMARTCARD_REQUIRED_PASSWORD_DOESNT_EXPIRE_E_NOT_REQUIRED;
            }
        }
    }
}
