using Ftec.ProjetosWeb.Social.Dominio.Entidades;
using Ftec.ProjetosWeb.Social.Dominio.Repositorio;
using Npgsql;

namespace Ftec.ProjetosWeb.Social.Repositorio
{
    public class StoryRepositorio : IStoryRepository
    {
        private string? _connectionString;
        public StoryRepositorio(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public List<Guid> ListarIdUsuariosStory()
        {
            var query = @" SELECT DISTINCT idUsuario
                            FROM Story 
                            WHERE s.dataInclusao >= @dataLimite";

            var resultado = new List<Guid>();

            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dataLimite", DateTime.UtcNow.AddHours(-24));

            conn.OpenAsync();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado.Add(reader.GetGuid(0));
            }

            return resultado;
        }

        public List<Story> ListarStorys(Guid? idUsuario = null)
        {
            string sWhereUsuario = idUsuario != null ? " and idUsuario = @idUsuario " : string.Empty;
            var query = $@"SELECT Id, idUsuario, dataInclusao, imagem
                  FROM Story
                  WHERE 1=1
                  {sWhereUsuario}
                  AND dataInclusao >= @dataLimite
                  ORDER BY dataInclusao ASC";

            var stories = new List<Story>();
            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);
            if (idUsuario != null)
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario.Value);
            
            cmd.Parameters.AddWithValue("@dataLimite", DateTime.UtcNow.AddHours(-24));

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stories.Add(new Story
                {
                    Id = reader.GetGuid(0),
                    IdUsuario = reader.GetGuid(1),
                    DataInclusao = reader.GetDateTime(2),
                    Imagem = reader.GetString(3)
                });
            }

            return stories;
        }


        public async void PostStoryAsync(Guid idUsuario, string imagemBase64)
        {
            var query = @"INSERT INTO Story (Id, IdUsuario, DataInclusao, Imagem)
                          VALUES           (@Id,@IdUsuario,@DataInclusao,@Imagem)";

            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@DataInclusao", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@Imagem", imagemBase64);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async void DeleteStoryAsync(Guid storyId)
        {
            var query = "DELETE FROM Story WHERE Id = @Id";

            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", storyId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

    }
}
