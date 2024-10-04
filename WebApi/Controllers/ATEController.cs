using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATEController : Controller
    {
        private IATEService _ateService;
        public ATEController(IATEService ateService)
        {
            _ateService = ateService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ATE ate)
        {
            var result = _ateService.Add(ate);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _ateService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

    }
}
