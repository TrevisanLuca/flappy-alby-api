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
    public IActionResult Post([FromBody] PlayerDto player)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _rankingRepository.SaveRanking(player);
        return Ok();
    }
}