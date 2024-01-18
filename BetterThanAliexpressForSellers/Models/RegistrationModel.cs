namespace BetterThanAliexpressForSellers.Models;

using System.ComponentModel.DataAnnotations;

public sealed class RegistrationModel
{
    public required string Login { get; set; }
    public required string Name { get; set; }
    public required string Inn { get; set; }
    [EmailAddress] public required string Email { get; set; }
    [Phone] public required string PhoneNumber { get; set; }
    public required string CompanyAddress { get; set; }
    [Compare(nameof(RegistrationModel.SubmitPassword))] public required string Password { get; set; }
    public required string SubmitPassword { get; set; }

    public required IFormFile PassportPhoto { get; set; }
    public required IFormFile InnPhoto { get; set; }
    public required IFormFile CompanyCertificatePhoto { get; set; }
}
