using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDoperation.Models;

namespace CRUDoperation.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class CRUDController : ApiController
    {
        //CRUDoperation objentities = new CRUDoperation();
        WEBAPIDBEntities objentities = new WEBAPIDBEntities();

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IQueryable<tblemployeedetail> GetEmployee()
        {
            try
            {
                return objentities.tblemployeedetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("GetEmployeeDetailsById/{employeeId}")]
        public IHttpActionResult GetEmployeeDetailsById(string employeeId)
        {
            tblemployeedetail objemp = new tblemployeedetail();
            int ID = Convert.ToInt32(employeeId);
            try
            {
                objemp = objentities.tblemployeedetails.Find(ID);
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Ok(objentities);
        }

         [HttpPost]
         [Route("InsertEmployeeDetails")]
         public IHttpActionResult PostEmployee(tblemployeedetail data)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                objentities.tblemployeedetails.Add(data);
                objentities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Ok(data);
         }

        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IHttpActionResult PutEmployeeMaster(tblemployeedetail employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                tblemployeedetail objemployee = new tblemployeedetail();
                objemployee = objentities.tblemployeedetails.Find(employee.EmployeeID);
                if(objemployee != null)
                {
                    objemployee.EmployeeName = employee.EmployeeName;
                    objemployee.Address = employee.Address;
                    objemployee.EmailId = employee.EmailId;
                    objemployee.DateOfBirth = employee.DateOfBirth;
                    objemployee.Gender = employee.Gender;
                    objemployee.PinCode = employee.PinCode;
                    objemployee.PinCode = employee.PinCode;
                }
                int i = this.objentities.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Ok(employee);
        }
         
        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public IHttpActionResult DeleteEmployeeDetails(int EmployeeID)
        {
            tblemployeedetail employee = objentities.tblemployeedetails.Find(EmployeeID);
            if(employee == null)
            {
                return NotFound();
            }
            objentities.tblemployeedetails.Remove(employee);
            objentities.SaveChanges();
            return Ok(employee);
        }
    }
}
