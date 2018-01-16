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
        public IHttpActionResult Get()
        {
            if (repository.GetEmployeesList() != null)
            {
                return Ok(repository.GetEmployeesList());
            }
            return NotFound();
        }

        // GET api/values/5
        public IHttpActionResult GetEmployee(int id)
        {
            if (repository.GetEmployee(id) != null)
            {
                return Ok(repository.GetEmployee(id));
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IHttpActionResult CreateEmployee([FromBody]Employee employee)
        {
            repository.Create(employee);
            repository.Save();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        public IHttpActionResult EditEmployee(int id, [FromBody]Employee employee)
        {
            if (id == employee.Id)
            {
                repository.Update(employee);
                repository.Save();
                return Ok();
            }
            return BadRequest();
        }

        //DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            Employee employee = repository.GetEmployee(id);

            if (repository.Delete(employee))
            {
                repository.Save();
                return Ok();
            }
            return NotFound();
        }

    }
}
