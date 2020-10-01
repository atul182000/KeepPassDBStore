using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeepPassDBStore.Models
{
    // Model class to manage your passwords for different sites
    // helps to remeber all passwords
    public class KeepPassword
    {
        [Key]
        public int Id { get; set; }
        // Username for site
        [Required(ErrorMessage = "Enter Username here")]
        public string Username { get; set; }
        // Password for site
        [Required(ErrorMessage = "Enter Password here")]
        public string  Password { get; set; }
        // URL of the site where these username and password are applicable
        [Required(ErrorMessage = "Enter URL here")]
        public string  URL { get; set; }
        // descriptio/note about the site or username or password
        [Required(ErrorMessage = "Enter any notes here related to credentials")]
        public string Notes { get; set; }
        // date of saving these credentials 
        // set to current date
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
