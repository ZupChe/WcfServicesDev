using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
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
            var s = new WcfEmp.CrudServiceClient();
            var all = s.GetEmployees();

            return View(all);
        }

        
        public IActionResult Edit(int Id)
        {
            var emp = new WcfEmp.CrudServiceClient().GetEmployees().Single(e => e.Id == Id); 
            return View("Dodaj", new EmpViewModel {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                BirthDate = emp.BirthDate,
                Id = emp.Id
            });
        }

        [HttpPost]
        public IActionResult Edit(EmpViewModel emp)
        {
            new WcfEmp.CrudServiceClient().EditEmployee(new WcfEmp.EmployeeModel { 
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                BirthDate = emp.BirthDate,
                Id = emp.Id
            });
            TempData["msg"] = String.Format("Edit of {0} {1} succeded", emp.FirstName, emp.LastName);
            return RedirectToAction("Index");
        }
        
        public IActionResult Add()
        {
            return View("Dodaj");
        }

        [HttpPost]
        public IActionResult Add(EmpViewModel emp)
        {
            new WcfEmp.CrudServiceClient().AddEmployee(new WcfEmp.EmployeeModel
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                BirthDate = emp.BirthDate            
            });
            TempData["msg"] = String.Format("Add of {0} {1} succeded", emp.FirstName, emp.LastName);
            return RedirectToAction("Index");
        }

        [Route("~/home/delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            var emp = new WcfEmp.CrudServiceClient().DeleteEmployee(Id);
            TempData["msg"] = String.Format("Delete of {0} {1} succeded", emp.FirstName, emp.LastName);
            return RedirectToAction("Index", "home");
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
