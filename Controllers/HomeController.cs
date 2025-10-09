using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using WebGallery.Models.Statistics;
using WebGallery.Repositories.Contexts;

namespace WebGallery.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet(), Route("/")]
        public ViewResult Index()
        {
            return View();
        }


        //[HttpGet(), Route("/stats")]
        //public HtmlResult visits()
        //{
        //    Visit[] visits = statisticsContext.Visits.ToArray();

        //    StringBuilder stringBuilder = new StringBuilder("<h3>Статистика посещений страниц</h3><table>");
        //    stringBuilder.Append($"<tr>" +
        //        $"<td>Страница</td>" +
        //        $"<td>Количество посещений</td>" +
        //        $"<td>Последнее посещение</td>" +
        //    $"</tr>");

        //    foreach (string key in visitingStatistics.Keys)
        //    {
        //        stringBuilder.Append($"<tr>" +
        //            $"<td>{lastVisit.Path}</td>" +
        //            $"<td>{visits.Count}</td>" +
        //            $"<td>{lastVisit.Date} {lastVisit.Time.ToString("HH:mm:ss")}</td>" +
        //        $"</tr>");
        //    }

        //    stringBuilder.Append("</table>");

        //    return new HtmlResult(stringBuilder);

        //    throw new NotImplementedException();
        //}


        public HomeController(StatisticsContext statisticsContext) : base(statisticsContext)
        {
        }
    }
}
