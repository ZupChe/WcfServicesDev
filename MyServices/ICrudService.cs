using MyServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace MyServices
{
    [ServiceContract]
    public interface ICrudService
    {
        [OperationContract]
        void AddEmployee(EmployeeModel emp);
        [OperationContract]
        void EditEmployee(EmployeeModel emp);
        [OperationContract]
        EmployeeModel DeleteEmployee(int Id);
        [OperationContract]
        List<EmployeeModel> GetEmployees();
    }
}
