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
using Practice.Domain.Core;
using Practice.Domain.Interfaces;
using Practice.Infrastructure.Data;

namespace SomeWebApi.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        IEmployeeRepository repository = new EmployeeRepository();

        //public ValuesController(IEmployeeRepository r)
        //{
        //    repository = r;
        //}

        // GET api/values
        public JsonResult<IEnumerable<Employee>> Get()
        {
            return Json(repository.GetEmployeesList());
        }

        // GET api/values/5
        public Employee GetEmployee(int id)
        {
            Employee employee = repository.GetEmployee(id);
            return employee;
        }

        // POST api/values
        [HttpPost]
        public void CreateEmployee([FromBody]Employee employee)
        {
            repository.Create(employee);
            repository.Save();
        }

        // PUT api/values/5
        [HttpPut]
        public void EditEmployee(int id, [FromBody]Employee employee)
        {
            if (id == employee.Id)
            {
                repository.Update(employee);
                repository.Save();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Employee employee = repository.GetEmployee(id);

            if (employee != null)
            {
                repository.Delete(id);
                repository.Save();
            }
        }
    }
}
