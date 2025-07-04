﻿using Ftec.ProjetosWeb.Social.Aplicacao.Adapter;
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


        public List<StoryViewDto> ListarStorys()
        {
            var storys = _storyRepository.ListarStorys();
            return StoryAdapter.ParaDto(storys);
        }

        public List<Guid> ListarIdUsuariosStory()
        {
            return _storyRepository.ListarIdUsuariosStory();
        }

        public List<StoryViewDto> ListarStorysByUsuario(Guid idUsuario)
        {
            var storys = _storyRepository.ListarStorys(idUsuario);
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
