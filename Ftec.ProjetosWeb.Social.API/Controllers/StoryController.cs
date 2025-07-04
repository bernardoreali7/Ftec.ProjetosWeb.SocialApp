using Ftec.ProjetosWeb.Social.Aplicacao;
using Ftec.ProjetosWeb.Social.Aplicacao.DTO;
using Ftec.ProjetosWeb.Social.Dominio.Repositorio;
using Ftec.ProjetosWeb.Social.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.Social.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private IStoryRepository storyRepository;
        private StoryAplicacao aplicacao;
        public StoryController(IConfiguration configuration)
        {
            string strConexao = configuration.GetConnectionString("conexao")
                                ?? throw new InvalidOperationException("Connection string 'conexao' não encontrada."); storyRepository = new StoryRepositorio(strConexao);
            aplicacao = new StoryAplicacao(storyRepository);
        }

        [HttpGet]
        public List<StoryViewDto> Get(Guid idUsuario)
        {
            return aplicacao.PesquisarStorys(idUsuario);
        }


        [HttpGet]
        [Route("ListarIdUsuariosStory")]
        public List<Guid> ListarIdUsuariosStory()
        {
            return aplicacao.ListarIdUsuariosStory();
        }

        [HttpPost]
        public void Post(Guid idUsuario, string fotoBase64)
        {
            aplicacao.Inserir(idUsuario, fotoBase64);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            aplicacao.Excluir(id);
        }

    }
}
