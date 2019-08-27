using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Domain
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string FirstName { get; set; }

        public string Name
        {
            get
            {
                return (LastName + " " + FirstName);
            }
        }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public Contact()
        {
            DateCreated = DateTime.UtcNow;
        }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
