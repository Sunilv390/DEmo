using CommonLayer.DBContext;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly EmployeeContext database;
        public EmployeeRL(EmployeeContext _database)
        {
            database = _database;
        }

        /// <summary>
        /// Add new Employee in which Email should not repeat based on our database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public EmployeeData AddEmployee(EmployeeData employee)
        {
            try
            {
                var check = database.EmployeeDatas.Where(exist => exist.Email == employee.Email).FirstOrDefault();
                if (check == null)
                {
                    database.Add(employee);
                    database.SaveChanges();
                    return employee;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get all employee details where employeeId shoud be greater than 0
        /// </summary>
        /// <returns></returns>
        public List<EmployeeData> GetAllEmployees()
        {
            try
            {
                List<EmployeeData> employee = database.EmployeeDatas.
                    Where(emp => emp.EmployeeId > 0).
                    Select(emp => new EmployeeData
                    {
                        EmployeeId = emp.EmployeeId,
                        Name = emp.Name,
                        Email = emp.Email,
                        Contact = emp.Contact
                    }).ToList();
                return employee;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Update the employee Records based on there empId
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public object UpdateData(int empId,EmployeeData update)
        {
            try
            {
                bool condition = database.EmployeeDatas.Any(emp => emp.EmployeeId == empId);
                if (condition)
                {
                    var data = database.EmployeeDatas.Where(emp => emp.EmployeeId == empId).FirstOrDefault();
                    data.Name = update.Name;
                    data.Email = update.Email;
                    data.Contact = update.Contact;
                    database.Update(data);
                    database.SaveChanges();
                    return data;
                }
                else
                {
                    throw new Exception("Update Fail");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Delete specific Employee Details on the basis of ther ID
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public object DeleteData(int empId)
        {
            try
            {
                var data = database.EmployeeDatas.FirstOrDefault(table => table.EmployeeId == empId);
                database.Remove(data);
                database.SaveChanges();
                return data;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
