using Ftec.ProjetosWeb.Social.Dominio.Entidades;
using Ftec.ProjetosWeb.Social.Dominio.Repositorio;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Ftec.ProjetosWeb.Social.Repositorio
{
    public class StoryRepositorio : IStoryRepository
    {
        private string? _connectionString;
        public StoryRepositorio(string connectionString)
        {
            this._connectionString = connectionString;
        }

        //public async Task<List<User>> ListarUsuariosComStorysRecentesAsync()
        //{
        //    var query = @"
        //                    SELECT DISTINCT u.Id, u.nome, u.foto
        //                    FROM User u
        //                    JOIN Story s ON u.Id = s.idUsuario
        //                    WHERE s.dataInclusao >= @dataLimite";

        //    var resultado = new List<User>();

        //    using var conn = new NpgsqlConnection(_connectionString);
        //    using var cmd = new NpgsqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@dataLimite", DateTime.UtcNow.AddHours(-24));

        //    await conn.OpenAsync();
        //    using var reader = await cmd.ExecuteReaderAsync();
        //    while (await reader.ReadAsync())
        //    {
        //        resultado.Add(new User
        //        {
        //            Id = reader.GetGuid(0),
        //            nome = reader.IsDBNull(1) ? null : reader.GetString(1),
        //            foto = reader.IsDBNull(2) ? null : reader.GetString(2)
        //        });
        //    }

        //    return resultado;
        //}

        public List<Story> ListarStorysUsuario(Guid idUsuario)
        {
            var query = @"SELECT Id, idUsuario, dataInclusao, imagem
                  FROM Story
                  WHERE idUsuario = @idUsuario AND dataInclusao >= @dataLimite
                  ORDER BY dataInclusao ASC";

            var stories = new List<Story>();
            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
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
