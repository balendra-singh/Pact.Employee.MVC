using Demo.Employee.MVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Employee.MVC.Core.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        WebResponseModel<EmployeeModel> AddEmployee(EmployeeModel employeeModel);
        WebResponseModel<EmployeeModel> UpdateEmployee(EmployeeModel updatedEmployeeModel);
        WebResponseModel<bool> ToggleEmployeeStatus(int employeeNumber);
        List<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployee(int employeeNumber);
        bool IsEmployeeNumberPresent(int employeeNumber);        
    }
}
