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
public IActionResult Calculate(double R_major, double r_minor, double theta)
{
    // R_major = distansya mula sa gitna ng donut hanggang sa gitna ng tube
    // r_minor = radius ng mismong tube
    // theta = gaano kalaking parte ng ikot ang kinuha (in degrees)

    // Convert degrees to radians
    double radians = theta * (Math.PI / 180.0);

    // Formula: Volume = (Area of circle) * (Arc length of the center path)
    // V = (π * r^2) * (R * theta_radians)
    double volume = (Math.PI * Math.Pow(r_minor, 2)) * (R_major * radians);

    ViewBag.Result = volume.ToString("F4");
    
    return View("Index");
}



    }
}
