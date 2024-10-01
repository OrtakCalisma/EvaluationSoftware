using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITAController : ControllerBase
    {
        private IITAService _itaService;
        public ITAController(IITAService itaService)
        {
            _itaService = itaService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ITA ita)
        {
            var result = _itaService.Add(ita);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message); 
        }


        [HttpGet("GetByAteId")]
        public IActionResult GetByAteId(int id)
        {
            var result = _itaService.GetByATEId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _itaService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
