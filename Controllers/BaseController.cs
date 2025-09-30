using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebGallery.Models;

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

            visits.Push(new Visit(path, DateTime.Now));
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
