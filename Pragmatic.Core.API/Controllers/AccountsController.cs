using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pragmatic.Core.API.Models;
using System.Collections.Generic;

namespace Pragmatic.Core.API.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        List<ValueModel> valuesList;
        public AccountsController()
        {
            valuesList = new List<ValueModel>
            {
                new ValueModel(1, "account1" ),
                new ValueModel(2, "account2" ),
                new ValueModel(3, "account3" )
            };
        }
        // GET: api/accounts
        [HttpGet("get")]
        public ActionResult<IEnumerable<ValueModel>> Get()
        {
            return valuesList;
        }

        // POST api/accounts/register
        [HttpPost("register")]
        public ActionResult<ValueModel> Register([FromBody] ValueModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 4;
                model.Name = "This is the reply";
            }
            return model;
        }

    }
}
