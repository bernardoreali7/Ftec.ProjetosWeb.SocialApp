using Ftec.ProjetosWeb.Social.Aplicacao.DTO;
using Ftec.ProjetosWeb.Social.Dominio.Entidades;

namespace Ftec.ProjetosWeb.Social.Aplicacao.Adapter
{
    public static class StoryAdapter
    {
        public static List<StoryViewDto> ParaDto(List<Story> storys)
        {
            List<StoryViewDto> storysView = new List<StoryViewDto>();

            foreach (Story story in storys)
                storysView.Add(ParaDto(story));
            

            return storysView;
        }

        public static StoryViewDto ParaDto(Story story)
        {
            return new StoryViewDto()
            {
                Id = story.Id,
                DataInclusao = story.DataInclusao,
                Imagem = story.Imagem
            };
        }
    }
}
