using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
            
        }

        
        //GET : Home
        public IActionResult Index()
        {
            var s = new WcfEmp.CrudServiceClient();
            var all = s.GetEmployees();

            return View(all);
        }

        public IActionResult ONama()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        public IActionResult AddOglas()
        {
            return View("Dodaj");
        }

        /*
        public IActionResult Update(int Id)
        {
            
            Automobil model = Oglasavanje.GetAutomobil(Id);
            return View("Dodaj", model);
        }

        [Route("~/home/detail/{Id}")]
        public IActionResult Detail(int Id)
        {
            Automobil model = Oglasavanje.GetAutomobil(Id);
            return View("Detalji", model);
        }
        [Authorize]
        [Route("~/home/delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            Automobil model = Oglasavanje.DeleteAutomobil(Id);
            TempData["Obrisano"] = model.Marka + " " + model.Model;
            return RedirectToAction("Index", "home");
        }



        [HttpPost]
        public IActionResult Index(Automobil automobil)
        {



            if (ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine(_env.ContentRootPath, "wwwroot\\images\\", file.FileName);
                        using (var outputStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(outputStream);
                            automobil.Foto = Path.Combine("~/images/", file.FileName);
                        }

                    }
                }

                Oglasavanje.AddOglas(automobil);
                TempData["Marka"] = automobil.Marka + " " + automobil.Model;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }



        }

        [HttpPost]
        public IActionResult Update(Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    foreach (var file in Request.Form.Files)
                    {
                        if (file.Length > 0)
                        {
                            var filePath = Path.Combine(_env.ContentRootPath, "wwwroot\\images\\", file.FileName);
                            using (var outputStream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(outputStream);
                                automobil.Foto = Path.Combine("~/images/", file.FileName);
                            }
                        }
                    }
                }


                Oglasavanje.UpdateOglas(automobil, automobil.Id);
                TempData["Izmena"] = automobil.Marka + " " + automobil.Model;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Index()
        {
            return View();
        }
        */

    }
}
