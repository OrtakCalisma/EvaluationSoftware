using Azure;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using UI.Models;
using WebApi.Controllers;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            //await GeneratePdf();
            _httpClient.BaseAddress = new Uri("https://localhost:44367/api/ATE/");
            var result = await _httpClient.GetAsync("GetAll");
            var jsonString = await result.Content.ReadFromJsonAsync<List<ATE>>();

            return View(jsonString);
        }

        [HttpPost]
        public async Task<IActionResult> AtePost(ATE body)
        {
            //var atee = new ATE
            //{
            //    Description = "ddasdasd",
            //    CalibrationDate = DateTime.Now,
            //    Name = "name",
            //    SerialNumber = "1234567890",
            //    PartNumber = "1234567890",
            //    BomList = "dsadas",
            //    TPSId = 4,
            //    Id = 5
            //};

            _httpClient.BaseAddress = new Uri("https://localhost:44367/api/ATE/");
            var message = await _httpClient.PostAsJsonAsync("Add", body);

            return RedirectToAction("AtePost");
        }

        [HttpGet]
        public IActionResult AtePost()
        {
            //var atee = new ATE
            //{
            //    Description = "ddasdasd",
            //    CalibrationDate = DateTime.Now,
            //    Name = "name",
            //    SerialNumber = "1234567890",
            //    PartNumber = "1234567890",
            //    BomList = "dsadas",
            //    TPSId = 4,
            //    Id = 5
            //};

            //_httpClient.BaseAddress = new Uri("https://localhost:44367/api/ATE/");
            //var message = await _httpClient.PostAsJsonAsync("Add", body);

            return View(new ATE()) ;
        }
        public ActionResult DosyaYukle()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DosyaGetir(int dosyaName)   // HttpPostedFileBase
        {


            return Ok();
        }



        [HttpPost]
        public async Task<IActionResult> DosyaYukle(IFormFile yuklenecekDosya)   // HttpPostedFileBase
        {
            if (yuklenecekDosya != null)
            {
                _httpClient.BaseAddress = new Uri("https://localhost:44367/api/File/");

                string json = JsonConvert.SerializeObject(yuklenecekDosya);   //using Newtonsoft.Json

                byte[] data;
                using (var br = new BinaryReader(yuklenecekDosya.OpenReadStream()))
                    data = br.ReadBytes((int)yuklenecekDosya.OpenReadStream().Length);

                ByteArrayContent bytes = new ByteArrayContent(data);

                MultipartFormDataContent multiContent = new MultipartFormDataContent();

                multiContent.Add(bytes, "file", yuklenecekDosya.FileName);
                StringContent httpcontent = new StringContent(json, Encoding.UTF8, "text/plain");

                StreamContent streamContent = new StreamContent(HttpContext.Request.Body);
                var message = await _httpClient.PostAsync("Add", multiContent);

            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task GeneratePdf()
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(2);//2 listenin sütun sayýsý
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            var basliklar = new List<string>() { "meyve", "sebze" };

            //Adding Header row
            foreach (var meyve in basliklar)
            {
                PdfPCell cell = new PdfPCell(new Phrase(meyve));
                pdfTable.AddCell(cell);
            }

            var meyveler = new List<string>() { "armut", "roka" };
            //Adding DataRow
            foreach (var itemRow in meyveler)
            {
                pdfTable.AddCell(itemRow);
            }

            //Exporting to PDF
            string folderPath = @"C:/tmp/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

        }
    }
}
