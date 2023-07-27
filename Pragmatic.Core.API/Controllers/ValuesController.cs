using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Web.Resource;
using Pragmatic.Core.API.Models;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Pragmatic.Core.API.Controllers
{
    public class ValuesController : ApiControllerBase
    {
        List<ValueModel> valuesList;
        public ValuesController(/* IValueRepository repository */)
        {
            valuesList = new List<ValueModel>
            {
                new ValueModel(1, "value1" ),
                new ValueModel(2, "value2" ),
                new ValueModel(3, "value3" )
            };
        }


        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<ValueModel>> Get()
        {
            return valuesList;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ValueModel> Get(int id)
        {
            return valuesList.Where(i => i.Id == id).FirstOrDefault();
        }


        // POST api/values/create
        [HttpPost("create")]
        public ActionResult<ValueModel> Create([FromBody] ValueModel value)
        {
            if (ModelState.IsValid)
            {
                value.Id = 4;
                valuesList.Add(value);
            }
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<ValueModel> Edit(int id, [FromBody] ValueModel value)
        {
            value.Id = id;
            // return value;
            return value;
        }
        
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            var item = valuesList.Find(i => i.Id == id);
            return valuesList.Remove(item) ? Ok() : NotFound();
        }
        
    }
}

