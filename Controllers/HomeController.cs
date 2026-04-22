using Microsoft.AspNetCore.Mvc;

namespace HelicalToroidFrustum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Calculate(double h, double R, double r)
        {
            double volume = (Math.PI * h / 3.0) * (Math.Pow(R, 2) + (R * r) + Math.Pow(r, 2));

            ViewBag.Result = volume.ToString("F4");
            ViewBag.Height = h;
            ViewBag.MajorR = R;
            ViewBag.MinorR = r;

            return View("Index");
        }


    }
}
