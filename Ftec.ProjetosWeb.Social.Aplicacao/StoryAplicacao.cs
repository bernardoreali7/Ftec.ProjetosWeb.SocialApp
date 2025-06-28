using Ftec.ProjetosWeb.Social.Aplicacao.Adapter;
using Ftec.ProjetosWeb.Social.Aplicacao.DTO;
using Ftec.ProjetosWeb.Social.Dominio.Repositorio;

namespace Ftec.ProjetosWeb.Social.Aplicacao
{
    public class StoryAplicacao
    {
        private IStoryRepository _storyRepository;

        public StoryAplicacao(IStoryRepository storyRepository)
        {
            this._storyRepository = storyRepository;
        }

        //public async List<UsuarioViewDto> PesquisarUsuariosComStoryRecente()
        //{
        //    var usuarios = await _storyRepository.ListarUsuariosComStorysRecentesAsync();
        //    return UsuarioAdapter.ParaDto(usuarios);
        //}

        public List<StoryViewDto> PesquisarStorys(Guid idUsuario)
        {
            var storys = _storyRepository.ListarStorysUsuario(idUsuario);
            return StoryAdapter.ParaDto(storys);
        }

        public void Inserir(Guid idUsuario, string foto)
        {
            _storyRepository.PostStoryAsync(idUsuario, foto);
        }

        public void Excluir(Guid idStory)
        {
            _storyRepository.DeleteStoryAsync(idStory);
        }
    }
}
