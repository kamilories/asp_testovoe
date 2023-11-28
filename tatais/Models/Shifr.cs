using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace tatais.Models
{
    
    public class Shifr
	{
        [Key]
        public string old_symbol { get; set; }
        public string new_symbol { get; set; }
    }
}

