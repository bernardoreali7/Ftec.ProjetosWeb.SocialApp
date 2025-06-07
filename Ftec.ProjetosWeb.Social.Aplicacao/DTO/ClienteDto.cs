using Ftec.ProjetosWeb.CadCliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.CadCliente.Aplicacao.DTO
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public DateTime DataFundacao { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
