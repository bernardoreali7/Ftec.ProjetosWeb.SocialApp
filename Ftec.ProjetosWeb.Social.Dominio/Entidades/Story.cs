namespace Ftec.ProjetosWeb.Social.Dominio.Entidades
{
    public class Story
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataInclusao { get; set; }
        public string? Imagem { get; set; } // base64 string
    }
}
