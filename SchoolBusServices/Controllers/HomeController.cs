using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBusServices.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(MvcApplication.GeoPointRepository);
        }

        public JsonResult AddGeopoint(double lat, double lon, string trackingName)
        {
            var newGeopoint = new { lat = lat, lon = lon, trackingName = trackingName };
            var id = MvcApplication.GeoPointRepository.Count();
            MvcApplication.GeoPointRepository.Add(new Models.GeoPoint
            {
                ID = id,
                Lat = lat,
                Lon = lon,
                TrackingName = trackingName,
                CreatedDateTime = DateTime.Now,
            });

            return Json(new { success = true, totalGeopoint = MvcApplication.GeoPointRepository.Count}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLastGeopoint(string trackingName)
        {
            return Json(new { 
                success = true,
                lastGeopoint = MvcApplication
                .GeoPointRepository
                .Where(g => g.TrackingName == trackingName)
                .LastOrDefault() 
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Echo(string trackingName)
        {
            var random = new Random();
            return Json(new { trackingName = trackingName, random = random.Next(0, 100) }, JsonRequestBehavior.AllowGet);
        }
    }
}
