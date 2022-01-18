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
        [HttpPost]
        public ActionResult<ExpenseEntryDto> CreateExpenseEntry(CreateExpenseEntryDto entryDto)
        {
            ExpenseEntry entry = new()
            {
                Id = Guid.NewGuid(),
                Name = entryDto.Name,
                Amount = entryDto.Amount,
                Category = entryDto.Category,
                Date = DateTimeOffset.UtcNow
            };

            repository.CreateEntry(entry);

            return Ok(CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, entry.AsDto()));
        }

        //Delete Entry
        [HttpDelete("{id}")]
        public ActionResult DeleteExpenseEntry(Guid id)
        {
            var existingEntry = repository.GetEntry(id);

            if (existingEntry is null)
            {
                return NotFound();
            }

            repository.DeleteEntry(id);

            return NoContent();
        }

        //Update Entry
        [HttpPut("{id}")]
        public ActionResult UpdateExpenseEntry(Guid id, UpdateExpenseEntryDto entryDto)
        {
            var existingEntry = repository.GetEntry(id);

            if (existingEntry is null)
            {
                return NotFound();
            }

            existingEntry.Name = entryDto.Name;
            existingEntry.Amount = entryDto.Amount;
            existingEntry.Category = entryDto.Category; 

            repository.UpdateEntry(existingEntry);

            return NoContent();
        }
        #endregion
    }
}
