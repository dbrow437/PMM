using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories
{
    public interface IExpenseEntriesRepository
    {
        IEnumerable<ExpenseEntry> GetEntries();
        ExpenseEntry GetEntry(Guid id);
    }
}