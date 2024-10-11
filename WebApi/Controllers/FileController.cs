using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Add")]
        public IActionResult AddFile(IFormFile file)
        {
           var result = _fileService.Add(file);

            if (result.Success)
            {
                return Ok(Messages.ProductAdded);
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public IActionResult Get(string fileName)
        {
            var result = _fileService.GetAll(fileName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
