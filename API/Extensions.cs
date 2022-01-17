using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API
{
    public static class Extensions
    {
        public static ExpenseEntryDto AsDto(this ExpenseEntry entry)
        {
            return new ExpenseEntryDto
            {
                Id = entry.Id,
                Name = entry.Name,
                Amount = entry.Amount,
                Date = entry.Date,
                Category = entry.Category
            };
        }
    }
}