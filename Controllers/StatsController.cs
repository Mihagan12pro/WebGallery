using Microsoft.AspNetCore.Mvc;
using WebGallery.Models.Statistics;
using WebGallery.Models.Statistics.HelpStructs;
using WebGallery.Repositories.Contexts;

namespace WebGallery.Controllers
{
    public class StatsController : BaseController
    {
        [HttpGet()]
        public ViewResult Visits()
        {
            var visits = statisticsContext.Visits;

            return View(visits.OrderByDescending(v => v.Id));
        }


        [HttpGet()]
        public ViewResult  Last()
        {
            var maxIds = from visit in statisticsContext.Visits
                         group visit by visit.Page into g
                         select new
                         {
                             Page = g.Key,

                             Id = g.Max(visit => visit.Id)
                         };
            var lastVisits = from visit in statisticsContext.Visits
                             join maxId in maxIds on visit.Id equals maxId.Id
                             select new Visit()
                             {
                                 Id = maxId.Id,

                                 Date = visit.Date,

                                 Time = visit.Time,

                                 Method = visit.Method,

                                 Page = maxId.Page,

                                 UserAgent = Request.Headers.UserAgent
                             };
            return View(lastVisits.OrderByDescending(v => v.Id));
        }


        [HttpGet()]
        public ViewResult Count()
        {
            IEnumerable<PageCount> countOfVisits = (
                from visit in statisticsContext.Visits
                group visit by visit.Page into grouped
                orderby grouped.Count() descending
                select new PageCount
                {
                    Count = grouped.Count(),

                    Page = grouped.Key
                });

            return (View(countOfVisits));
        }


        public StatsController(StatisticsContext statisticsContext) : base(statisticsContext)
        {
        }
    }
}
