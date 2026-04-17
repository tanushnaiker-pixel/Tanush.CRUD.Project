using System.ComponentModel.DataAnnotations;

namespace Registry.Core.Entities
{
    public class RegistrationInformation
    {
        public Guid Id { get; set; }

        [StringLength(13)]
        public required string IdNo { get; set; }

        [StringLength(50)]
        public required string FirstName { get; set; }

        [StringLength(50)]
        public required string LastName { get; set; }
        
        [StringLength(50)]
        public required string StreetAddress { get; set; }
        
        [StringLength(50)]
        public required string Suburb { get; set; }

        [StringLength(50)]
        public required string City { get; set; }
        
        [StringLength(15)]
        public required string Province { get; set; } //Possibly add a drop down menu
        
        [EmailAddress]
        public required string Email { get; set; }

        [Phone]
        public required string Phone { get; set; }
    }
}
