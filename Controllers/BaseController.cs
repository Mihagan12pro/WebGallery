using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebGallery.Models.Statistics;

namespace WebGallery.Controllers
{
    public class BaseController : Controller
    {
        protected readonly static Dictionary<string, Stack<Visit>> visitingStatistics = new Dictionary<string, Stack<Visit>>();

       
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext httpContext = context.HttpContext;

            HttpRequest request = httpContext.Request;

            string path = request.Path;

            path = path.TrimEnd('/');

            if (path.Length == 0)
                path = "/";

            if (!visitingStatistics.ContainsKey(path))
               visitingStatistics.Add(path, new Stack<Visit>());
            

            Stack<Visit> visits = visitingStatistics[path];

            DateTime dateTime = DateTime.Now;

            //visits.Push(new Visit(path, request.Method, new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day), new TimeOnly(dateTime.Hour, dateTime.Minute, dateTime.Second)));
        }


        [NonAction()]
        public static Visit LastVisitOnPage(string path)
        {
            Visit? lastVisit = visitingStatistics[path].Peek();

            if (lastVisit == null)
                throw new NullReferenceException("Нет посещений!");

            return lastVisit;
        }
    }
}
