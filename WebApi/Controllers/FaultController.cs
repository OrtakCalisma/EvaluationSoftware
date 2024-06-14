using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultController : Controller
    {
        private IFaultService _faultService;
        private IProductService _productService;

        public FaultController(IFaultService faultService, IProductService productService)
        {
            _faultService = faultService;
            _productService = productService;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _faultService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetBySerialNo")]
        public IActionResult GetBySerialNo(string serialNumber)
        {
            var result = _faultService.GetBySerialNumber(serialNumber);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Faults fault)
        {
            fault.Date = DateTime.Now;
            fault.IsSolved = false;

            var result = _faultService.Add(fault);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
