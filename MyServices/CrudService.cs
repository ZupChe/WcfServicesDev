using MyServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServices
{
    public class CrudService : ICrudService
    {
        public void AddEmployee(EmployeeModel emp)
        {
            using (var db = new NORTHWNDDb())
            {
                db.Employees.Add(
                    new Employee
                    { 
                        FirstName = emp.FirstName, 
                        LastName = emp.LastName, 
                        BirthDate = emp.BirthDate 
                    });
                db.SaveChanges();
            }
        }

        
        public EmployeeModel DeleteEmployee(int Id)
        {
            using (var db = new NORTHWNDDb())
            {
                var dbEmployee = db.Employees.Single(e => e.EmployeeID == Id);
                var orders = db.Orders.Where(all => all.EmployeeID == Id);
                foreach (var o in orders)
                    o.EmployeeID = null;
                var terr = db.EmployeeTerritories.Where(all => all.EmployeeID == Id);
                db.EmployeeTerritories.RemoveRange(terr);
                
                db.Employees.Remove(dbEmployee);
                db.SaveChanges();
                return new EmployeeModel
                {
                    Id = dbEmployee.EmployeeID,
                    FirstName = dbEmployee.FirstName,
                    LastName = dbEmployee.LastName,
                    BirthDate = dbEmployee.BirthDate
                };
            }
        }

        public void EditEmployee(EmployeeModel emp)
        {
            using (var db = new NORTHWNDDb())
            {
                var dbEmployee = db.Employees.Single(e => e.EmployeeID == emp.Id);

                dbEmployee.FirstName = emp.FirstName;
                dbEmployee.LastName = emp.LastName;
                dbEmployee.BirthDate = emp.BirthDate;
                db.SaveChanges();
               
            }
        }

        public List<EmployeeModel> GetEmployees()
        {
            using (var db = new NORTHWNDDb())
            {
                return db.Employees.Select(e => new EmployeeModel
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    BirthDate = e.BirthDate,
                    Id = e.EmployeeID
                }).ToList();
            }
        }
    }
}
