using System;
using System.Web.Mvc;
using System.Collections.Generic;
using InterviewTask.Services;
using InterviewTask.Models;
using InterviewTask.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Script.Serialization;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Prepare your opening times here using the provided HelperServiceRepository class.       
         */

        HelperServiceModel ServiceModel = new HelperServiceModel();
        HelperServiceViewModel ServiceModelVM = new HelperServiceViewModel();
        public ActionResult Index(List<string> Weather)
        {
            try
            {
                ServiceModelVM.HelperServiceList = HelperSetup.Setup(Weather);

                var GetIPAddress = HelperLogger.GetIPAddress(null);                
                
            }
            catch (Exception ex)
            {
                HelperLogger.GetIPAddress(ex);                
            }
            return View(ServiceModelVM);
        }

        [HttpPost]
        public ActionResult Index(string City)
        {            
            List<string> WeatherList = HelperWeather.WeatherList(City);                
            return Index(WeatherList);            
        }

    }
}
