using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tatais.Models
{
	public class History_encrypted
	{
        
        
        public DateTime date { get; set; } = DateTime.Now;
        public string original_text { get; set; }
        public string encrypted_text { get; set; }
        public int Id { get; set; }

        
    }
}


