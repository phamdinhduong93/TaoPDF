using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WkHtmlToPdfDotNet;

namespace TaoPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("TaoFile")]
        public IActionResult TaoFile()
        {
            var converter = new BasicConverter(new PdfTools());
            for (int i = 0; i < 6000; i++)
            {
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4,
                },
                    Objects = {
                    new ObjectSettings() {
                    //    PagesCount = true,
                        HtmlContent = @"Lorem ipsum dolor sit amet, consectetur <b style='color:red'>このページは、お住まいの地域からはご利用頂けません</b><br>  adipiscing elit. In consectetur mauris eget ultrices  iaculis. Ut      odio viverra, molestie lectus nec, venenatis turpis.",
                        WebSettings = { DefaultEncoding = "utf-8" },
                        //HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
                };
                byte[] pdf = converter.Convert(doc);
                System.IO.File.WriteAllBytes($@"D:/chang/chang_{Guid.NewGuid()}.pdf", pdf);
            }
            return new OkResult();
        }
    }
}
