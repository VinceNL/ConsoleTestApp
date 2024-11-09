using ValidationComponent.CustomAttributes;

namespace ConsoleTestApp.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 2)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 5)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Field, {0}, must be a valid email address")]
        public string? EmailAddress { get; set; }

        [Required]
        [StringLength(7, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 6)]
        [RegularExpression(@"^\d{4}\s?[A-Za-z]{2}$", ErrorMessage = "Field, {0}, must be a valid Dutch postal code (e.g., 1234 AB)")]
        //[JsonIgnore]
        public string? PostCode { get; set; }

        [Required]
        [StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in length", 10)]
        [RegularExpression(@"^(\+31|0)[1-9]\d{8}$", ErrorMessage = "Field, {0}, must be a valid Dutch phone number (e.g., 0612345678 or +31612345678)")]
        //[JsonIgnore]
        public string? PhoneNumber { get; set; }
    }
}
