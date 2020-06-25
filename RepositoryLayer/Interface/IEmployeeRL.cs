using CommonLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        EmployeeData AddEmployee(EmployeeData employee);
        List<EmployeeData> GetAllEmployees();
        object UpdateData(int empId, EmployeeData update);
        object DeleteData(int empId);
    }
}
