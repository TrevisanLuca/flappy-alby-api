namespace FlappyAlby.API.Controllers; 

using Microsoft.AspNetCore.Mvc;
using FlappyAlby.API.Abstract;
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
    public async Task<IActionResult> Get(int topX = 10)
    {
        var result = await _rankingRepository.GetRanking(topX);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlayerDto player)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var newPlayerId = await _rankingRepository.AddPlayer(player);
            return Created($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}/{newPlayerId}", newPlayerId);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}