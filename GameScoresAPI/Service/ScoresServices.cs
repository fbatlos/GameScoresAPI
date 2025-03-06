using System.Collections.Generic;
using System.Threading.Tasks;
using GameScoreAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameScoreAPI.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace GameScoreAPI.Services
{
    public interface IScoreService
    {
        Task<List<Score>> GetScoresAsync();
        Task<Score> GetScoreAsync(int id);
        Task<Score> AddScoreAsync(Score score);
    }
}



namespace GameScoreAPI.Services
{
    public class ScoreService : IScoreService
    {
        private readonly string _filePath;

        public ScoreService(IHostEnvironment environment)
        {
            // Define la ruta al archivo JSON
            _filePath = Path.Combine(environment.ContentRootPath, "scores.json");
        }

        public async Task<List<Score>> GetScoresAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Score>();
            }

            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<Score>>(jsonData) ?? new List<Score>();
        }

        public async Task<Score> GetScoreAsync(int id)
        {
            var scores = await GetScoresAsync();
            return scores.FirstOrDefault(s => s.Id == id);
        }

        public async Task<Score> AddScoreAsync(Score score)
        {
            var scores = await GetScoresAsync();
            score.Id = scores.Any() ? scores.Max(s => s.Id) + 1 : 1;
            scores.Add(score);

            var jsonData = JsonConvert.SerializeObject(scores, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, jsonData);

            return score;
        }
    }
}
