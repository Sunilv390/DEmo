using BussinessLayer.Interface;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System.Collections.Generic;

namespace BussinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL empRL;
        public EmployeeBL(IEmployeeRL _empRL)
        {
            empRL = _empRL;
        }

        public EmployeeData AddEmployee(EmployeeData employee)
        {
            var data = empRL.AddEmployee(employee);
            return data;
        }

        public List<EmployeeData> GetAllEmployees()
        {
            var data = empRL.GetAllEmployees();
            return data;
        }

        public object UpdateData(int empId, EmployeeData update)
        {
            var data = empRL.UpdateData(empId,update);
            return data;
        }

        public object DeleteData(int empId)
        {
            var data = empRL.DeleteData(empId);
            return data;
        }
    }
}
