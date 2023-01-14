using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab2MVC.Controllers
{
    public class FilesController : Controller
    {
        private readonly ILogger<FilesController> _logger;
        public FilesController(ILogger<FilesController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
         string[] files = Directory.GetFiles("TextFiles").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
         return View(files);
        }

        public IActionResult Content(string id)
        {
            string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "/TextFiles/" + id + ".txt");
            return View(lines);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}