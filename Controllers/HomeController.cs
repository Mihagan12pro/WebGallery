using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebGallery.Models.Statistics;

namespace WebGallery.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet(), Route("/")]
        public string Index()
        {
            return "Hello";
        }


        [HttpGet(), Route("/stats")]
        public HtmlResult Stats()
        {
            //StringBuilder stringBuilder = new StringBuilder("<h3>Статистика посещаемости страниц</h3><table>");
            //stringBuilder.Append($"<tr>" +
            //    $"<td>Страница</td>" +
            //    $"<td>Количество посещений</td>" +
            //    $"<td>Последнее посещение</td>" +
            //$"</tr>");

            //foreach (string key in visitingStatistics.Keys)
            //{
            //    Stack<Visit> visits = visitingStatistics[key];

            //    Visit lastVisit = BaseController.LastVisitOnPage(key);

            //    stringBuilder.Append($"<tr>" +
            //        $"<td>{lastVisit.Path}</td>" +
            //        $"<td>{visits.Count}</td>" +
            //        $"<td>{lastVisit.Date} {lastVisit.Time.ToString("HH:mm:ss")}</td>" +
            //    $"</tr>");
            //}

            //stringBuilder.Append("</table>");

            //return new HtmlResult(stringBuilder);

            throw new NotImplementedException();
        }
    }
}
