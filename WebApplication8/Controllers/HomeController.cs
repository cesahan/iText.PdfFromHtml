
using iText.Html2pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Text;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public FileResult PDFUsingiTextSharp()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang=\"en\">");
            sb.Append("<head>");
            sb.Append("<meta charset=\"UTF-8\" />");
            sb.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />");
            sb.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />");
            sb.Append("<title>Document</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<h2>Test</h2>");
            sb.Append("</body>");
            sb.Append("</html>");

            using (MemoryStream memoryStream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(sb.ToString(), memoryStream);
                return File(memoryStream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
    }
}
