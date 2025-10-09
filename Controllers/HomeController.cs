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


        public HomeController(StatisticsContext statisticsContext) : base(statisticsContext)
        {
        }
    }
}
