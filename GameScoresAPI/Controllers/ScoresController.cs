using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameScoreAPI.Models;
using GameScoreAPI.Services;
using GameScoreAPI.Services.GameScoreAPI.Services;

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

        // Obtener puntuaciones por nombre de jugador
        [HttpGet("player/{name}")]
        public async Task<ActionResult<List<Score>>> GetScoresByPlayer(string name)
        {
            var scores = await _scoreService.GetScoreAsync(name);
            if (scores == null || scores.Count == 0)
            {
                return NotFound($"No scores found for player: {name}");
            }
            return Ok(scores);
        }

        // Obtener un puntaje por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScoreById(string id)
        {
            var score = await _scoreService.GetScoreByIdAsync(id);
            if (score == null)
            {
                return NotFound($"Score with ID {id} not found");
            }
            return Ok(score);
        }

        // Agregar una nueva puntuación
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            var newScore = await _scoreService.AddScoreAsync(score);
            return CreatedAtAction(nameof(GetScoreById), new { id = newScore.Id }, newScore);
        }

        // Actualizar una puntuación por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScore(string id, Score updatedScore)
        {
            var result = await _scoreService.UpdateScoreAsync(id, updatedScore);
            if (!result)
            {
                return NotFound($"Score with ID {id} not found");
            }
            return NoContent();
        }

        // Eliminar una puntuación por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(string id)
        {
            var result = await _scoreService.DeleteScoreAsync(id);
            if (!result)
            {
                return NotFound($"Score with ID {id} not found");
            }
            return NoContent();
        }
    }
}
