using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameScoreAPI.Models;
using GameScoreAPI.Services;

namespace GameScoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        // Obtener todas las puntuaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            var scores = await _scoreService.GetScoresAsync();
            return Ok(scores);
        }

        // Obtener una puntuación por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _scoreService.GetScoreAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        // Agregar una nueva puntuación
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            var newScore = await _scoreService.AddScoreAsync(score);
            return CreatedAtAction(nameof(GetScore), new { id = newScore.Id }, newScore);
        }
    }
}