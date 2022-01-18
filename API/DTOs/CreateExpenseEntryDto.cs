using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Enums;

namespace API.DTOs
{
    public class CreateExpenseEntryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Amount { get; set; }
        [Required]
        [Range(0, 6)]
        public Categories Category { get; set; }
    }
}