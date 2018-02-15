using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alone_Revisal.Models;
using Alone_Revisal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Alone_Revisal.Controllers
{

    public class HomeController : Controller
    {
        IRevisalRepository _irevisal;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(IRevisalRepository revisalRepository, IHostingEnvironment hostingEnvironment)
        {
            _irevisal = revisalRepository;
            _hostingEnvironment = hostingEnvironment;
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
          
            return View(_irevisal.GetAllSalariat());

        }

        public IActionResult Cucu_2()
        {
            ViewData["Mess"] = "Employee from Revisal";

            return View(_irevisal.GetSalariatByCNP("1550704131229"));

        }

        public IActionResult UploadRevisalDatabase()
        {
            ViewData["Mess"] = "Employee from Revisal";

            return View();

        }

        public IActionResult UploadDataBase(IFormFile file)
        {
            string ext = Path.GetExtension(file.FileName);

            if (ext != ".db")
            {
                return PartialView("failtoupload");
            }

            if (file != null)
            {
                string fileName = Path.Combine(_hostingEnvironment.WebRootPath, Path.GetFileName(file.FileName));
                file.CopyTo(new FileStream(fileName, FileMode.Create));
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
