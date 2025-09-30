using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebGallery
{
    public class HtmlResult : IActionResult
    {
        private string _htmlCode;


        public HtmlResult(string html) => _htmlCode = html;

        public HtmlResult (StringBuilder stringBuilder) => _htmlCode = stringBuilder.ToString();


        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = @$"<!DOCTYPE html>
            <html>
                <head>
                    <title>WebGallery</title>
                    <meta charset=utf-8 />
                </head>
                <body>{_htmlCode}</body>
            </html>";

            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
