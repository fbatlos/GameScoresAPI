using GameScoreAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GameScoreAPI.Models;
using GameScoreAPI.Services.GameScoreAPI.Services;

namespace GameScoreAPI.Services
{
    
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace GameScoreAPI.Services
    {
        public interface IScoreService
        {
            Task<List<Score>> GetScoresAsync();         // Obtener todas las puntuaciones
            Task<List<Score>> GetScoreAsync(string name); // Obtener puntuaciones por nombre de jugador
            Task<Score> AddScoreAsync(Score score);       // Agregar una nueva puntuación
            Task<Score?> GetScoreByIdAsync(string id);    // Obtener una puntuación por ID
            Task<bool> UpdateScoreAsync(string id, Score updatedScore); // Actualizar una puntuación
            Task<bool> DeleteScoreAsync(string id);      // Eliminar una puntuación
        }
    }

    
    public class ScoreService : IScoreService
    {
        private readonly IMongoCollection<Score> _scoreCollection;

        public ScoreService(IOptions<MongoDBSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _scoreCollection = database.GetCollection<Score>("scores");
        }

        public async Task<List<Score>> GetScoresAsync()
        {
            return await _scoreCollection.Find(_ => true)
                .SortByDescending(s => s.Points)
                .ToListAsync();
        }

        public async Task<List<Score>> GetScoreAsync(string name)
        {
            return await _scoreCollection.Find(s => s.PlayerName == name)
                .SortByDescending(s => s.Points)
                .ToListAsync();
        }

        public async Task<Score?> GetScoreByIdAsync(string id)
        {
            return await _scoreCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Score> AddScoreAsync(Score score)
        {
            await _scoreCollection.InsertOneAsync(score);
            return score;
        }

        public async Task<bool> UpdateScoreAsync(string id, Score updatedScore)
        {
            var result = await _scoreCollection.ReplaceOneAsync(s => s.Id == id, updatedScore);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteScoreAsync(string id)
        {
            var result = await _scoreCollection.DeleteOneAsync(s => s.Id == id);
            return result.DeletedCount > 0;
        }
    }
}