using Microsoft.AspNetCore.Mvc;
using WebGallery.Models.Statistics;
using WebGallery.Repositories.Contexts;

namespace WebGallery.Controllers
{
    public class StatsController : BaseController
    {
        [HttpGet()]
        public ViewResult Visits()
        {
            return View(statisticsContext.Visits);
        }


        [HttpGet()]
        public ViewResult Last()
        {
            var lastVisitsAttributes = from visit in statisticsContext.Visits
                                       group visit by visit.Page into g
                                       select new Visit()
                                       {
                                           Page = g.Key,

                                           Date = g.Max(v => v.Date),

                                           Time = g.Max(v => v.Time),

                                           Method = g.OrderByDescending(v => v.Date).ThenByDescending(v => v.Time).First().Method,

                                           PageKey = g.OrderByDescending(v => v.Date).ThenByDescending(v => v.Time).First().PageKey
                                       };

            return View(lastVisitsAttributes);
        }


        [HttpGet()]
        public ViewResult Count()
        {
            return View();
        }


        public StatsController(StatisticsContext statisticsContext) : base(statisticsContext)
        {
        }
    }
}
