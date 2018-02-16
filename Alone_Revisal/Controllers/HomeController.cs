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
       private IRevisalRepository _irevisal;
        private IHostingEnvironment _hostingEnvironment;
        private IAppRepository _appRepository;

        public HomeController(IRevisalRepository revisalRepository, IHostingEnvironment hostingEnvironment, IAppRepository appRepository)
        {
            _irevisal = revisalRepository;
            _hostingEnvironment = hostingEnvironment;
            _appRepository = appRepository;
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


        public IActionResult AngajatiActivi()
        {
            ViewData["Mess"] = "Employee from Revisal";

            return View(_irevisal.GetAllSalariat());

        }

        public IActionResult DetaliiAngajati()
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

     
        public IActionResult InsertPontaje(string cnp )
        {
            if (ModelState.IsValid)
            {
                _appRepository.InsertPontaje(cnp);
            }

            ViewData["Mess"] = "Employee from Revisal";

            return View();

        }
    }
}
