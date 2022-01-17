using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
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
        private readonly IExpenseEntriesRepository repository;
        #endregion

        #region Constructor
        public ExpenseEntriesController(IExpenseEntriesRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Public Methods
        //Get Entries
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseEntryDto>> GetEntries()
        {
            var expenseEntries = repository.GetEntries().Select( entry => entry.AsDto());

            return Ok(expenseEntries);
        }

        //Get Entry
        [HttpGet("{id}")]
        public ActionResult<ExpenseEntryDto> GetEntry(Guid id)
        {
            var entry = repository.GetEntry(id);

            if (entry is null)
            {
                return NotFound();
            }

            return Ok(entry.AsDto());
        }

        

        //Create Entry

        //Delete Entry

        //Update Entry
        #endregion
    }
}
