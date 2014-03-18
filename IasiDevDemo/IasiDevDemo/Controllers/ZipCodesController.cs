using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using ZipCodes;

namespace IasiDevDemo.Controllers
{
    public class ZipCodesController : Controller
    {
        //
        // GET: /ZipCodes/
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult BreakpointOnFunctionExit()
        {
            SetZipCode();
            return View("Index");
        }

        public ActionResult ImmediateWindow()
        {

            return View("Index");
        }

        private void SetZipCode()
        {
            ViewBag.ZipCode = new ZipCodesRepository().FilterListOfZipCodesByComplicatedCriteria(x => x%2 == 0).First();
        }

        public ActionResult ParalelRetrievalOfCities()
        {
            return View("Index");
        }
    }
}
