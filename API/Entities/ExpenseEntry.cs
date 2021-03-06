using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enums;

namespace API.Entities
{
    public class ExpenseEntry
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset Date { get; set; }
        public Categories Category { get; set; }
    }
}