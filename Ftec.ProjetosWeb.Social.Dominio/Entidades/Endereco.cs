using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.CadCliente.Dominio.Entidades
{
    public class Endereco
    {
        public string Rua {  get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Numero {  get; set; }
        public Endereco() 
        {
            this.Bairro = string.Empty;
            this.Cep = string.Empty;
            this.Numero = string.Empty;
            this.Cidade = string.Empty;
            this.Complemento = string.Empty;
            this.Rua = string.Empty;
        }
    }
}
