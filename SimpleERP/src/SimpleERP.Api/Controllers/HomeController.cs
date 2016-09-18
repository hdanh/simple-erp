﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleERP.Api.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json("Hello");
        }
    }
}