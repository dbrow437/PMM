using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseEntriesController : ControllerBase
    {
        #region Private
        private readonly InMemExpenseEntriesRepository repository;
        #endregion

        #region Constructor
        public ExpenseEntriesController()
        {
            repository = new InMemExpenseEntriesRepository();
        }
        #endregion

        #region Public Methods
        //Get Entries
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseEntry>> GetEntries()
        {
            var expenseEntries = repository.GetEntries();
            return Ok(expenseEntries);
        }

        //Get Entry
        [HttpGet("{id}")]
        public ActionResult<ExpenseEntry> GetEntry(Guid id)
        {
            var entry = repository.GetEntry(id);

            if (entry is null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        

        //Create Entry

        //Delete Entry

        //Update Entry
        #endregion
    }
}
