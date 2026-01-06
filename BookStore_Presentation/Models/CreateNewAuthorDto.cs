using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_Presentation.Models;

namespace BookStore_Presentation.Models
{
    public class CreateNewAuthorDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateOnly? BirthDay { get; set; }
    }
}
