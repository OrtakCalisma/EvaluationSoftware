using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private IFileService _fileService;
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

        //[HttpGet("Get")]
        //public IActionResult Get(string? fileName)
        //{
        //    var result = _fileService.GetAll();

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}
        [HttpGet("GetByProjectName")]
        public IActionResult GetByProjectName(string projectName)
        {
            var result = _fileService.GetByProjectName(projectName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetByBaselineId")]
        public IActionResult GetByBaselineId(string baselineId)
        {
            var result = _fileService.GetByBaselineId(baselineId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetBy")]
        public IActionResult GetBy(string? baselineId, string? projectName, string? mocLevel, string? revision)
        {
            var result = _fileService.GetBy(baselineId, projectName, mocLevel, revision);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetTypes")]
        public String GetTypes()
        {
            var count = 0;
            var result = _fileService.GetCount();

            //x =>
            //                                x.ProjectName == hrs.ProjectName
            //                             && x.MoC == hrs.MoC
            //                             && x.Baseline == hrs.Baseline
            //                             && x.Revision == hrs.Revision
            if (result.Success)
            {
                count = result.Data;
            }

            var sb = new StringBuilder();
            Type t = typeof(HRS);
            Type t2 = typeof(DataResult<HRS>);

            foreach (var prop in t2.GetProperties())
            {
                sb.Append(prop.Name);
                sb.Append(";");
                sb.Append(prop.PropertyType.Name);
                sb.Append(";");
            }
            sb.AppendLine();

            sb.Append(t.Name);
            sb.Append(";");
            //sb.Append(t.Name);
            //sb.Append(";");

            foreach (var prop in t.GetProperties())
            {
                sb.Append(prop.Name);
                sb.Append(";");
                sb.Append(prop.PropertyType.Name);
                sb.Append(";");
            }
            sb.Append("Count;");
            sb.Append(count);
            //sb.Remove(sb.Length-1,1);

            return sb.ToString();
            //var result = _fileService.GetAll();

            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _fileService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
