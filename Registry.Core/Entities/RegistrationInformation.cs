using System.ComponentModel.DataAnnotations;

namespace Registry.Core.Entities
{
    public class RegistrationInformation
    {
        public int Id { get; set; }

        [StringLength(13)]
        [Required]
        public required string IdNo { get; set; }

        [StringLength(50)]
        [Required]
        public required string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public required string LastName { get; set; }
        
        [StringLength(50)]
        [Required]
        public required string StreetAddress { get; set; }
        
        [StringLength(50)]
        [Required]
        public required string Suburb { get; set; }

        [StringLength(50)]
        [Required]
        public required string City { get; set; }
        
        [StringLength(15)]
        [Required]
        public required string Province { get; set; } //Possibly add a drop down menu
        
        [EmailAddress]
        [Required]
        public required string Email { get; set; }

        [Phone]
        [Required]
        public required string Phone { get; set; }
    }
}
