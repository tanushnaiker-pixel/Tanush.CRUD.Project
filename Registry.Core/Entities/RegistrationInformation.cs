using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Core.Entities
{
    public class RegistrationInformation
    {
        public required string Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string StreetAddress { get; set; }

        public required string Suburb { get; set; }

        public required string City { get; set; }

        public required string Province { get; set; } //Possibly add a drop down menu

        public required string Email { get; set; }

        public required string Phone { get; set; }
    }
}
