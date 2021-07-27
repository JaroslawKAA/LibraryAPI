using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        [Required]
        public User Client { get; set; }
        [Required]
        public User Borrower { get; set; }
        public int BookId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
