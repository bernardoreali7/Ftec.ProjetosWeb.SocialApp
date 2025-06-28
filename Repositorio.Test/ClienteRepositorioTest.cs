using Ftec.ProjetosWeb.CadCliente.Dominio.Entidades;
using Ftec.ProjetosWeb.CadCliente.Repositorio;

namespace Repositorio.Test
{
    [TestClass]
    public class ClienteRepositorioTest
    {
        [TestMethod]
        public void InserirTeste()
        {
            var cliente = new Story();
            var clienteRepositorio = new ClienteRepositorio();
            try
            {
                cliente.Cpf = "12312312300";
                cliente.Cnpj = "";
                cliente.RazaoSocial = "Juliano Menzen";
                cliente.DataFundacao = DateTime.Now;

                clienteRepositorio.Inserir(cliente);
                Assert.IsTrue(true);    
            }
            catch (Exception ex) 
            {
                Assert.Fail(ex.Message);
            }
            
        }
        [TestMethod]
        public void ExcluirTeste()
        {
            var cliente = new Story();
            var clienteRepositorio = new ClienteRepositorio();
            try
            {
                cliente.Cpf = "12312312300";
                cliente.Cnpj = "";
                cliente.RazaoSocial = "Juliano Menzen";
                cliente.DataFundacao = DateTime.Now;

                clienteRepositorio.Inserir(cliente);
                clienteRepositorio.Excluir(cliente.Id);
                var clienteRetorno = clienteRepositorio.Procurar(cliente.Id);

                Assert.IsTrue(clienteRetorno == null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTeste()
        {
            var cliente = new Story();
            var clienteRepositorio = new ClienteRepositorio();
            try
            {
                cliente.Cpf = "12312312300";
                cliente.Cnpj = "";
                cliente.RazaoSocial = "Juliano Menzen";
                cliente.DataFundacao = DateTime.Now;

                clienteRepositorio.Inserir(cliente);
                 var clienteRetorno = clienteRepositorio.Procurar(cliente.Id);

                Assert.IsTrue(clienteRetorno != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        public void ProcurarTodosTeste()
        {
            var clienteRepositorio = new ClienteRepositorio();
            try
            {
                var clientes = clienteRepositorio.ProcurarTodos();  

                Assert.IsTrue(clientes.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarTeste()
        {
            var cliente = new Story()
            {
                Cpf = "123",
                RazaoSocial = "Juliano",
                DataFundacao = DateTime.Now,
                Endereco = new Endereco()
                {
                    Rua = "teste"
                }
            };

            var clienteRepositorio = new ClienteRepositorio();
            try
            {
                clienteRepositorio.Inserir(cliente);
                cliente.RazaoSocial = "Jose";
                clienteRepositorio.Alterar(cliente);

                cliente = clienteRepositorio.Procurar(cliente.Id);
                Assert.IsTrue(!cliente.RazaoSocial.Equals("Juliano"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}