using Microsoft.AspNetCore.Mvc;
using FlappyAlby.API.Abstract;

namespace FlappyAlby.API.Controllers;

using Bogus;
using DTOs;

[ApiController]
[Route("[controller]")]
public class RankingController : ControllerBase
{
   private readonly ILogger<RankingController> _logger;
    private readonly IRankingRepository _rankingRepository;

    public RankingController(ILogger<RankingController> logger, IRankingRepository rankingRepository)
    {
        _logger = logger;
        _rankingRepository = rankingRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _rankingRepository.GetRanking();

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlayerDto player)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var newPlayerId = await _rankingRepository.CreatePlayer(player);

            return newPlayerId is not null
                ? Created($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}/{newPlayerId}", newPlayerId)
                : NotFound();
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}