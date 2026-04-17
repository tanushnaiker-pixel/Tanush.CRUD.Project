using System.ComponentModel.DataAnnotations;

namespace Registry.Core.Entities
{
    public class RegistrationInformation
    {
        public Guid Id { get; set; }

        [StringLength(13)]
        [Required(AllowEmptyStrings =false)]
        public required string IdNo { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public required string FirstName { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public required string LastName { get; set; }
        
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public required string StreetAddress { get; set; }
        
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public required string Suburb { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public required string City { get; set; }
        
        [StringLength(15)]
        [Required(AllowEmptyStrings = false)]
        public required string Province { get; set; } //Possibly add a drop down menu
        
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public required string Email { get; set; }

        [Phone]
        [Required(AllowEmptyStrings = false)]
        public required string Phone { get; set; }
    }
}
