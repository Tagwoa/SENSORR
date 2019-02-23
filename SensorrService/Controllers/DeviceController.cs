using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SensorrService.Model;

namespace SensorrService.Controllers
{    
        [Route("api/[controller]")]       
        public class DeviceController : Controller
        {
        // Create a repository here
        private Repository _repository;
        public DeviceController(Repository repository)
        {
            _repository = repository;
        }
        
            // GET api/Device
            [HttpGet]
            public IEnumerable<Device> Get()
            {
                return _repository.Get();
            }

            // GET api/Device/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/Device
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT api/Device/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }        
    }
}
