using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pragmatic.Common.Entities.DTOs;
using Pragmatic.Common.Entities.Entities;
using Pragmatic.Core.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pragmatic.Core.API.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        //List<ValueModel> valuesList;
        //public AccountsController()
        //{
        //    valuesList = new List<ValueModel>
        //    {
        //        new ValueModel(1, "account1" ),
        //        new ValueModel(2, "account2" ),
        //        new ValueModel(3, "account3" )
        //    };
        //}


        // POST api/accounts/register
        [HttpPost("register")]
        public ActionResult<Account> Register([FromBody] AccountRegistrationDTO dto)
        {
            if (ModelState.IsValid)
            {
                // Change DTO to show new reply
                dto.AccountNumber = 321;
                dto.AccountName = "Reply Account";
            }
            var reply = new Account() { Id = 1, StepGrowthFactor = 1.00075M, StartingBalance = 2000, StartFactor = 1, AccountNumber = dto.AccountNumber, AccountName = dto.AccountName };
            
            // Return the part of the Account entity that is only stored in the database
            return reply;
        }

        //// GET: api/accounts
        //[HttpGet("get")]
        //public ActionResult<IEnumerable<int>> Get(int id)
        //{
        //    return new List<int> { 1 };
        //}


        // GET: api/accounts
        [HttpGet("last")]
        public ActionResult<IEnumerable<int>> GetLastClose(int accountId)
        {
            int lastClose = 0;
            // TODO: Get the last ClosedOrderTime for specific account (if it exisits), convert it to UNIX time and return it, otherwise return 0
            return new List<int> { lastClose };
        }

    }
}
