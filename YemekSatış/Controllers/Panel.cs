﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YemekSatış.Controllers
{
    public class PanelController:Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();

        }
    }
}