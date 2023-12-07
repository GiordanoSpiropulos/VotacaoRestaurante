using DesafioCertponto.Application.DTO.DTO.Restaurante;
using DesafioCertponto.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCertponto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IServiceRestaurante _restauranteService;
        public RestauranteController(IServiceRestaurante restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _restauranteService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _restauranteService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RestauranteDTO restauranteDTO)
        {
            var result = _restauranteService.Add(restauranteDTO);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public ActionResult Put([FromBody] RestauranteUpdateDTO restauranteUpdateDTO)
        {
            var result = _restauranteService.Update(restauranteUpdateDTO);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _restauranteService.Remove(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
