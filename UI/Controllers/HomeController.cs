using Azure;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection.Metadata;
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
            await GeneratePdf();
            //var ateClient = _httpClient.CreateClient("ateClient");
            _httpClient.BaseAddress = new Uri("https://localhost:44367/api/ATE/");
            var result = await _httpClient.GetAsync("GetAll");
            var jsonString = await result.Content.ReadFromJsonAsync<List<ATE>>();

            return View(jsonString);
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
