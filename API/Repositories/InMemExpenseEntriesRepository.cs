using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Enums;

namespace API.Repositories
{
    

    public class InMemExpenseEntriesRepository : IExpenseEntriesRepository
    {
        private readonly List<ExpenseEntry> entries = new()
        {
            new ExpenseEntry { Id = Guid.NewGuid(), Name = "Gas", Amount = 67.99, Date = DateTime.Now, Category = Categories.Auto },
            new ExpenseEntry { Id = Guid.NewGuid(), Name = "Rent", Amount = 1400, Date = DateTime.Now, Category = Categories.Rent },
            new ExpenseEntry { Id = Guid.NewGuid(), Name = "Joggers", Amount = 89.99, Date = DateTime.Now, Category = Categories.Retail }
        };

        public IEnumerable<ExpenseEntry> GetEntries()
        {
            return entries;
        }

        public ExpenseEntry GetEntry(Guid id)
        {
            return entries.Where(entry => entry.Id == id).SingleOrDefault();
        }
    }
}