﻿namespace QuizHut.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class MonitorController : AdministrationController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}