using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using SomeWebApi.Models;

namespace SomeWebApi.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        EmployeeContext db = new EmployeeContext();

        // GET api/values
        public JsonResult<DbSet<Employee>> GetEmployees()
        {
            return Json(db.Employees);
        }

        // GET api/values/5
        public Employee GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            return employee;
        }

        // POST api/values
        [HttpPost]
        public void CreateEmployee([FromBody]Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void EditEmployee(int id, [FromBody]Employee employee)
        {
            if (id == employee.Id)
            {
                db.Entry(employee).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);

            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
