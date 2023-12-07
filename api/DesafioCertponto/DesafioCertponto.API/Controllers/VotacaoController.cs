using DesafioCertponto.Application.DTO.DTO.Votacao;
using DesafioCertponto.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCertponto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotacaoController : ControllerBase

    {
        private readonly IServiceVotacao _votacaoService;

        public VotacaoController(IServiceVotacao votacaoService)
        {
            _votacaoService = votacaoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _votacaoService.GetResultadoVotacao();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(VotacaoDTO votacao)
        {
            var result = _votacaoService.Add(votacao);
            if(result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("ProfissionaisDidntVote")]
        public IActionResult GetProfissionaisDidntVote()
        {
            var result = _votacaoService.GetProfissionaisDidntVote();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}