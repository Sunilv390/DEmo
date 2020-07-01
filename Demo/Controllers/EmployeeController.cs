using BussinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL empBL;
        private readonly ILogger logger;

        public EmployeeController(IEmployeeBL _empBL,ILogger<EmployeeController>_logger)
        {
            empBL = _empBL;
            logger = _logger;
        }

        /// <summary>
        /// Get All Employee Data
        /// </summary>
        /// <returns>smd format data in which All employee data is present</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var data = empBL.GetAllEmployees();
                bool success = true;
                string message;
                if (data != null)
                {
                    message = "All Employee Details";

                    //Getting The Record In the form of Object From Getrecord Method and Storing It into Data variable
                    logger.LogInformation("Log message");
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = false;
                    message = "No Data found";
                    return BadRequest(new { success, message });
                }
            }
            catch(Exception e)
            {
                bool success = false;
                string message = e.Message;
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// Add Employee data according to the table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>employee data</returns>
        [HttpPost]
        [Route("{AddEmployee}")]
        public IActionResult AddEmployee(EmployeeData employee)
        {
            try
            {
                var data = empBL.AddEmployee(employee);
                bool success = true;
                string message;
                if (data != null)
                {
                    message = "Employee Added Successfully";

                    //Getting The Record In the form of Object From Getrecord Method and Storing It into Data variable
                    logger.LogInformation("Log message");
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = false;
                    message = "Employee not Added";
                    return BadRequest(new { success, message });
                }
            }
            catch(Exception e)
            {
                bool success = false;
                string message = e.Message;
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// Make changes to the Existing Data
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="employee"></param>
        /// <returns>Updates Data</returns>
        [HttpPut]
        [Route("{empId}/Update")]
        public IActionResult UpdateData(int empId,EmployeeData employee)
        {
            try
            {
                var data = empBL.UpdateData(empId,employee);
                bool success = true;
                string message;
                if (data != null)
                {
                    message = "Employee Updated Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = false;
                    message = "No Such Employee";
                    return BadRequest(new { success, message });
                }
            }
            catch(Exception e)
            {
                bool success = false;
                string message = e.Message;
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// Delete Data according to ther Id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>message</returns>
        [HttpDelete]
        [Route("{empId}/Delete")]
        public IActionResult DeleteData(int empId)
        {
            try
            {
                var data = empBL.DeleteData(empId);
                bool success = true;
                string message;
                if (data != null)
                {
                    message = "Data Deleted Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = false;
                    message = "No Such Employee";
                    return BadRequest(new { success, message });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                string message = e.Message;
                return BadRequest(new { success, message });
            }
        }
    }
}
