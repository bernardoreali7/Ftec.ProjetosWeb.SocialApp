using Ftec.ProjetosWeb.Social.Dominio.Entidades;

namespace Ftec.ProjetosWeb.Social.Dominio.Repositorio
{
    public interface IStoryRepository
    {
        void PostStoryAsync(Guid idUsuario, string imagemBase64);
        void DeleteStoryAsync(Guid storyId);
        List<Guid> ListarIdUsuariosStory();
        List<Story> ListarStorys(Guid? idUsuario = null);
    }
}
