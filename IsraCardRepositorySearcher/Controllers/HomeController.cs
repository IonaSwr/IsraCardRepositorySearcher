using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsraCardRepositorySearcher.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Booked()
        {
            if (Session["idNumbersArray"] == null)
            {
                var indexes = new List<int>();

                return Json(indexes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var indexes = Session["idNumbersArray"] as List<int>;
               
                return Json(indexes, JsonRequestBehavior.AllowGet);
            }           
        }


        public JsonResult UpdateBooked(int idnumber,object data)
        {

            var abc = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            if (Session["idNumbersArray"] == null)
            {
                var indexes = new List<int>();
                indexes.Add(idnumber);
                Session["idNumbersArray"] = indexes;
                return Json(indexes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var indexes = Session["idNumbersArray"] as List<int>;
                if (indexes.Contains(idnumber))
                {
                    indexes.Remove(idnumber);
                }
                else
                {
                    indexes.Add(idnumber);
                }
                
                Session["idNumbersArray"] = indexes;
                return Json(indexes, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateBookedData(string data)
        {

           // var abc = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return Json("great");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}