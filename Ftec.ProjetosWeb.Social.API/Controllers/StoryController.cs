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
        public List<StoryViewDto> Get()
        {
            return aplicacao.ListarStorys();
        }

        [HttpGet]
        [Route("ListarStorysByUsuario")]
        public List<StoryViewDto> ListarStorysByUsuario(Guid idUsuario)
        {
            return aplicacao.ListarStorysByUsuario(idUsuario);
        }


        [HttpGet]
        [Route("ListarIdUsuariosComStory")]
        public List<Guid> ListarIdUsuariosStory()
        {
            return aplicacao.ListarIdUsuariosStory();
        }

        [HttpPost]
        public void Post([FromBody] PostStoryDto model)
        {
            aplicacao.Inserir(model.idUsuario, model.fotoBase64);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            aplicacao.Excluir(id);
        }

    }
}
