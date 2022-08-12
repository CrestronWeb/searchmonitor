using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using searchmonitor.Models;
using System.Configuration;
using System.Net;
using System.IO;

namespace searchmonitor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Models.search pagesearch = new search();

            string url = ConfigurationManager.AppSettings["SearchURL"].ToString();

            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query url
            using (Stream responseStream = response.GetResponseStream())               // Load the response stream
            using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
            {
                pagesearch.siteContent = streamReader.ReadToEnd(); // Read the entire response and store it in the siteContent variable
            }

            return View(pagesearch);
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