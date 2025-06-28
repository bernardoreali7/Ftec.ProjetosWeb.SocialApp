using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.Social.Aplicacao.DTO
{
    public class StoryViewDto
    {
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public string? Imagem { get; set; } // base64 string
    }
}
