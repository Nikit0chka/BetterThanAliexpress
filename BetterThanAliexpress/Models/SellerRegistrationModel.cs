namespace BetterThanAliexpress.Models;

using System.ComponentModel.DataAnnotations;

public sealed class SellerRegistrationModel
{
    public required string Login { get; set; }
    public required string Name { get; set; }
    public required string Inn { get; set; }
    [EmailAddress] public required string Email { get; set; }
    [Phone] public required string PhoneNumber { get; set; }
    public required string CompanyAddress { get; set; }
    [Compare(nameof(SellerRegistrationModel.SubmitPassword))] public required string Password { get; set; }
    public required string SubmitPassword { get; set; }
}
