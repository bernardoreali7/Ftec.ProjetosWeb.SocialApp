using Ftec.ProjetosWeb.CadCliente.Aplicacao.DTO;
using Ftec.ProjetosWeb.CadCliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.CadCliente.Aplicacao.Adapter
{
    public static class ClienteAdapter
    {
        public static List<ClienteDto> ParaDto(List<Cliente> clientes)
        {
            List<ClienteDto> clientes1 = new List<ClienteDto>();

            foreach (Cliente cliente in clientes)
            {
                clientes1.Add(ParaDto(cliente));
            }

            return clientes1;
        }
        public static List<Cliente> ParaDomain(List<ClienteDto> clientes)
        {
            List<Cliente> clientes1 = new List<Cliente>();

            foreach (ClienteDto cliente in clientes)
            {
                clientes1.Add(ParaDomain(cliente));
            }

            return clientes1;
        }
        public static Cliente ParaDomain(ClienteDto cliente)
        {
            return new Cliente()
            {
                Cpf = cliente.Cpf,
                Cnpj = cliente.Cnpj,
                DataFundacao = cliente.DataFundacao,
                Id = cliente.Id,
                RazaoSocial = cliente.RazaoSocial,
                Endereco = new Endereco()
                {
                    Bairro = cliente.Endereco.Bairro,
                    Cep = cliente.Endereco.Cep,
                    Cidade = cliente.Endereco.Cidade,
                    Complemento = cliente.Endereco.Complemento,
                    Numero = cliente.Endereco.Numero,
                    Rua = cliente.Endereco.Rua
                }
            };
        }
        public static ClienteDto ParaDto(Cliente cliente)
        {
            return new ClienteDto()
            {
                Cpf = cliente.Cpf,
                Cnpj = cliente.Cnpj,
                DataFundacao = cliente.DataFundacao,
                Id = cliente.Id,
                RazaoSocial = cliente.RazaoSocial,
                Endereco = new EnderecoDto()
                {
                    Bairro = cliente.Endereco.Bairro,
                    Cep = cliente.Endereco.Cep,
                    Cidade = cliente.Endereco.Cidade,
                    Complemento = cliente.Endereco.Complemento,
                    Numero = cliente.Endereco.Numero,
                    Rua = cliente.Endereco.Rua
                }
            };


        }
    }
}
