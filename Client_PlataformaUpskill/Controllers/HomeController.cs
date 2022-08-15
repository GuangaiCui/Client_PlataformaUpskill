﻿using Client_PlataformaUpskill.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client_PlataformaUpskill.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("email") != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}