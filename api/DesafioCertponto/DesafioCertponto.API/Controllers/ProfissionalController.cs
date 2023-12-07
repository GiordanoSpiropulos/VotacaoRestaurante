using DesafioCertponto.Application.DTO.DTO.Profissional;
using DesafioCertponto.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCertponto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IServiceProfissional _profissionalService;
        public ProfissionalController(IServiceProfissional profissionalService)
        {
            _profissionalService = profissionalService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _profissionalService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _profissionalService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProfissionalDTO profissionalDTO)
        {
            var result = _profissionalService.Add(profissionalDTO);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProfissionalUpdateDTO profissionalUpdateDTO)
        {
            var result = _profissionalService.Update(profissionalUpdateDTO);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _profissionalService.Remove(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
