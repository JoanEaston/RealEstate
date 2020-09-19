using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        public readonly IPropertyRepository _propertyRepository;
        private IHostingEnvironment Environment;

        public HomeController(IPropertyRepository propertyRepository, IHostingEnvironment _environment)
        {
            _propertyRepository = propertyRepository;
            Environment = _environment;
        }

        public IActionResult Index()
        {

            var properties = _propertyRepository.GetAll();

            return View("Index1", properties);
        }

        public IActionResult Details(int id)
        {

            var property = _propertyRepository.GetProperty(id);

            return View("Details1",property);
        }

        [HttpGet]
        public IActionResult UpdateProperty(int id)
        {
            var property = _propertyRepository.GetProperty(id);
            return View(property);
        }





        [HttpGet]
        public IActionResult CreateProperty()
        {
            return View("CreateProperty1");
        }


        [HttpPost]
        public IActionResult Create(Property property)
        {

            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "assets/Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            if (ModelState.IsValid)
            {

                property.ImageUrl = property.postedFiles[0].FileName;

                _propertyRepository.Add(property);

                List<string> uploadedFiles = new List<string>();

                foreach (IFormFile postedFile in property.postedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }
                }


                return RedirectToAction("Index");
            }

            return View("CreateProperty", property);

        }



        [HttpPost]
        public IActionResult Update(Property property)
        {

            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            if (ModelState.IsValid)
            {

                property.ImageUrl = property.postedFiles[0].FileName;

                _propertyRepository.Update(property);

                List<string> uploadedFiles = new List<string>();

                foreach (IFormFile postedFile in property.postedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }
                }


                return RedirectToAction("Index");
            }

            return View("CreateProperty", property);
            
        }
    }
}