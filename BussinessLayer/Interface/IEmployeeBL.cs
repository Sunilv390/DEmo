using CommonLayer.Models;
using System.Collections.Generic;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBL
    {
        EmployeeData AddEmployee(EmployeeData employee);
        List<EmployeeData> GetAllEmployees();
        object UpdateData(int empId, EmployeeData update);
        object DeleteData(int empId);
    }
}
