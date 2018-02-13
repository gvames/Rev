using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alone_Revisal.Models;
using Alone_Revisal.Interfaces;

namespace Alone_Revisal.Controllers
{
    public class HomeController : Controller
    {
        IRevisalRepository _irevisal;

        public HomeController(IRevisalRepository revisalRepository)
        {
            _irevisal = revisalRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Salariati_Revisal()
        {
            ViewData["Mess"] = "Employee from Revisal";

            return View();

        }
  

        public IActionResult Cucu()
        {
            ViewData["Mess"] = "Employee from Revisal";
          
            return View(_irevisal.GetAllAngajat());

        }

        public IActionResult Cucu_2()
        {
            ViewData["Mess"] = "Employee from Revisal";

            return View(_irevisal.GetAngajatByCNP("1550704131229"));

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
