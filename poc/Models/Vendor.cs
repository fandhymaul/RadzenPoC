using System.ComponentModel.DataAnnotations;

namespace poc.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string VendorCode { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "Vendor name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Business type is required")]
        public string? BusinessType { get; set; }

        public string? TaxId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow.Date;

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public string? BankName { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? Currency { get; set; }
        public string? PaymentTerms { get; set; }
        public string? Comments { get; set; }

        public string DisplayLabel => $"{VendorCode} - {Name}";
    }
}
