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
using Alone_Revisal.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alone_Revisal.Controllers
{
    //[Authorize]
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

        [Authorize(Roles = "Administrator")]
        public IActionResult Administrare()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AngajatiActivi()
        {
            ViewData["Mess"] = "Employee from Revisal";

            List<Angajat> listaAngajatiActivi = _appRepository.GetAngajatiActiviAll().ToList();

            return View(listaAngajatiActivi);

        }

        public IActionResult Pontaj()
        {
            ViewData["Mess"] = "Employee from Revisal";

            // return View(_irevisal.GetSalariatByCNP("1550704131229"));
            return View(_appRepository.GetPontajAll().ToList());

        }
        [HttpPost]
        public IActionResult Pontaj(List<Pontaj> pontaj)
        {
            if (ModelState.IsValid)
            {
                var tmp = pontaj;
                return RedirectToAction("Index");
            }
            return View("Pontaje");
        }

        public IActionResult UploadRevisalDatabase()
        {
            ViewData["Mess"] = "Employee from Revisal";

            return View();

        }

        public IActionResult UploadDataBase(IFormFile file)
        {
            if (!CopyNewDB(file))
                return Error();

            return UpdateLocalDatabaseFromNewRevisal();
        }

        private IActionResult UpdateLocalDatabaseFromNewRevisal()
        {
            var newRevisal = _irevisal.GetAllSalariat();

            if (newRevisal == null)
                return PartialView("failtoupload");

            var result = _appRepository.InsertAngajat(newRevisal);

            if (result == SQLExceptions.UpdateFailed)
                return Error();

            return View();
        }

        private bool CopyNewDB(IFormFile file)
        {
            string dateNow = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string sourceFileName = Path.Combine(_hostingEnvironment.WebRootPath, @"Database\Revisal.db");
            string destFileName = Path.Combine(_hostingEnvironment.WebRootPath, @"Database\Backup\Revisal" + dateNow + ".db");
            string ext = Path.GetExtension(file.FileName);

            if (ext != ".db")
            {
                return false;
            }

            if (System.IO.File.Exists(sourceFileName))
            {
                System.IO.File.Copy(sourceFileName, destFileName);
                System.IO.File.Delete(sourceFileName);
            }

            if (file != null)
            {
                string fileName = Path.Combine(_hostingEnvironment.WebRootPath, @"Database\" + Path.GetFileName(file.FileName));
                file.CopyTo(new FileStream(fileName, FileMode.Create));
            }

            return true;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/Home/InsertPontaje/{cnp}")]
        public IActionResult InsertPontaje([FromRoute] string cnp)
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
