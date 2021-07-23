using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Models
{
    public class User : IdentityUser
    {
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [MaxLength(128)]
        public string Localization { get; set; }
        [Required]
        public bool TermsAccepted { get; set; }

        public List<User> Friends { get; set; } = new List<User>();
        public byte[] Photo { get; set; }
    }
}
