using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.CadCliente.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj {  get; set; }
        public string Cpf {  get; set; }    
        public DateTime DataFundacao { get; set; }
        public Endereco Endereco { get; set; }
        public Cliente()
        {
            this.Id = Guid.NewGuid();
            this.RazaoSocial = string.Empty;
            this.Cnpj = string.Empty;
            this.Cpf = string.Empty;
            this.DataFundacao = DateTime.MinValue;
            this.Endereco = new Endereco();
        }

        public bool PessoaFisica()
        {
            if (!string.IsNullOrEmpty(this.Cpf))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PessoaJuridica()
        {
            if (!string.IsNullOrEmpty(this.Cnpj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
