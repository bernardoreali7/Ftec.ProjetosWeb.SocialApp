using Ftec.ProjetosWeb.Social;
using Ftec.ProjetosWeb.Social.Aplicacao;
using Ftec.ProjetosWeb.Social.Aplicacao.DTO;
using Ftec.ProjetosWeb.Social.Dominio.Repositorio;
using Ftec.ProjetosWeb.Social.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.Social.API.Controllers
{
    [Route("api/[controller]/{id?}")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private IStoryRepository storyRepository;
        private StoryAplicacao aplicacao;
        public StoryController()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=422077bmx;";
            storyRepository = new StoryRepositorio(strConexao);
            aplicacao = new StoryAplicacao(storyRepository);
        }

        [HttpGet]
        public List<StoryViewDto> Get(Guid idUsuario)
        {
            return aplicacao.PesquisarStorys(idUsuario);
        }

        [HttpPost]
        public void Post(Guid idUsuario, string foto)
        {
            aplicacao.Inserir(idUsuario, foto);
        }

        [HttpDelete]    
        public void Delete(Guid id)
        {
            aplicacao.Excluir(id);
        }

    }
}
