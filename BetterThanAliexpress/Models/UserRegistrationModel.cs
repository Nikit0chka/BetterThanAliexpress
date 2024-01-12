namespace BetterThanAliexpress.Models;

using System.ComponentModel.DataAnnotations;

public sealed class UserRegistrationModel
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    [EmailAddress(ErrorMessage = "Not correct email address")] public required string Email { get; set; }
    public required DateTime DateOfBirthday { get; set; }
    public required string Login { get; set; }

    [Compare(nameof(UserRegistrationModel.SubmitPassword), ErrorMessage = "Passwords not match!")]
    public required string Password { get; set; }

    public required string SubmitPassword { get; set; }

    [Phone(ErrorMessage = "Phone number is not valid")] public required string PhoneNumber { get; set; }
}
