using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebGallery.Models.Statistics;
using WebGallery.Repositories.Contexts;

namespace WebGallery.Controllers
{
    public class StatisticsController : BaseController
    {
        [HttpGet(), Route("/stats/visits")]
        public HtmlResult ShowVisits()
        {
            var visits = statisticsContext.Visits;

            StringBuilder stringBuilder = new StringBuilder("<h3>Статистика посещаемости страниц</h3><table>");

            /*
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
             */

            return null;
        }


        public StatisticsController(StatisticsContext statisticsContext) : base(statisticsContext)
        {
        }
    }
}
