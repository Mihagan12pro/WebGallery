using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebGallery.Models.Statistics;
using WebGallery.Repositories.Contexts;

namespace WebGallery.Controllers
{
    public class BaseController : Controller
    {
        protected readonly StatisticsContext statisticsContext;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext httpContext = context.HttpContext;

            HttpRequest request = httpContext.Request;

            string path = request.Path;

            path = path.TrimEnd('/');

            if (path.Length == 0)
                path = "/";

            Page ?page = statisticsContext.Pages.FirstOrDefault(p => p.Path == path);

            if (page == null)
            {
                page = new Page { Path = path };
                statisticsContext.Pages.Add(page);
                statisticsContext.SaveChanges(); 
            }

            Visit visit = new Visit()
            {
                PageKey = page.Id,

                Date = DateOnly.FromDateTime(DateTime.Now),

                Time = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),

                Method = context.HttpContext.Request.Method
            };

            statisticsContext.Visits.Add(visit);

            statisticsContext.SaveChanges();
        }


        public BaseController(StatisticsContext statisticsContext)
        {
            this.statisticsContext = statisticsContext;
        }
    }
}
