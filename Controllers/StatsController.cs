using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using System.Text;
using WebGallery.Models.Statistics;
using WebGallery.Repositories.Contexts;

namespace WebGallery.Controllers
{
    public class StatsController : BaseController
    {
        [HttpGet()]
        public ViewResult Visits()
        {
            //foreach(Visit visit in statisticsContext.Visits)
            //{
            //    var page = visit.Page;

            //    Console.WriteLine(page?.Path);
            //}

            return View(statisticsContext.Visits);
        }


        public StatsController(StatisticsContext statisticsContext) : base(statisticsContext)
        {
        }
    }
}
