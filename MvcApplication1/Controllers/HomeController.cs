using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Class1 model)
        {
            string csvfilepath = "C:/Users/Prashant/Desktop/detail.csv";
            StreamReader strrcheck = new StreamReader(csvfilepath);
            int correctcount = 0;
            int incorrectcount = 0;
            int rowcount = 0;
            int totalcount = -1;
            while (!strrcheck.EndOfStream)
            {
                strrcheck.ReadLine();
                totalcount++;
            }

            string[] datavalues = null;
            StreamReader strr = new StreamReader(csvfilepath);
            while (!strr.EndOfStream)
            {
                string rowdata = strr.ReadLine().Trim();
                if (rowdata.Length > 0)
                {
                    datavalues = rowdata.Split(',');
                    rowcount++;
                    if (rowcount > 1)
                    {
                        if (model.FirstName != null && model.LastName != null && model.PhoneNumber != null && model.Address != null)
                        {
                            if (datavalues[0] == model.FirstName.ToString() && datavalues[1] == model.LastName.ToString() && datavalues[2] == model.PhoneNumber.ToString() && datavalues[3] == model.Address.ToString())
                            {
                                correctcount++;
                            }
                            else
                            {
                                incorrectcount++;
                            }
                        }

                    }
                }
            }
            if (incorrectcount == totalcount)
            {
                TempData["message"] = "Sorry we don’t recognize you";
            }
            else if (correctcount >= 1)
            {
                TempData["message"] = "Welcome to the site";
            }
            return View();
        }

    }
}
