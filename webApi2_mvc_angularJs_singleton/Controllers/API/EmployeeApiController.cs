using Api.model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.model.EntityModel;
using Api.DataAccess.services;

namespace webApi2_mvc_angularJs_singleton.Controllers.API
{
    public class EmployeeApiController : ApiController
    {
        public EmployeeApiController()
        {
            
        }
        [Route("Employee/GetAllEmployee/")]
        [HttpGet]
        public IHttpActionResult GetAllEmployee()
        {
            CommonResponse res = new CommonResponse();

            var result = DataAccess.Instance.EmployeeService.GetAll().ToList();

            if (result.Count > 0)
            {
                res.results = result;
                res.httpStatusCode = HttpStatusCode.OK;
                return Json(res);
            }
            else
            {
                return BadRequest(Constant.INVAILD_DATA);
            }
        }




        [Route("Employee/AddE/")]
        [HttpPost]
        public IHttpActionResult AddE(Employee employee)
        {

            CommonResponse cr = new CommonResponse();
            try
            {

                var res = DataAccess.Instance.EmployeeService.Add(employee);
                cr.httpStatusCode = res ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                cr.message = res ? Constant.SAVED : Constant.SAVED_ERROR;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Json(cr);


        }



        [Route("Employee/UpE/")]
        [HttpPut]
        public IHttpActionResult UpE(Employee employee)
        {
            

            CommonResponse cr = new CommonResponse();
            try
            {
                var vers = DataAccess.Instance.EmployeeService.Get(employee.Id); 
                vers.Name = employee.Name;
                vers.Email = employee.Email;
                vers.Phone = employee.Phone;
                var res = DataAccess.Instance.EmployeeService.Update(vers);
                cr.httpStatusCode = res ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                cr.message = res ? Constant.UPDATED : Constant.FAILED;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Json(cr);
        }




        [Route("Employee/DeleteE/")]
        [HttpPost]
        public IHttpActionResult DeleteE(Employee employee)
        {

            CommonResponse cr = new CommonResponse();

            var res = false;
            try
            {
                res = DataAccess.Instance.EmployeeService.Remove(employee);
                cr.httpStatusCode = res ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                cr.message = res ? Constant.SAVED : Constant.SAVED_ERROR;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Json(cr);
        }
    }
}
