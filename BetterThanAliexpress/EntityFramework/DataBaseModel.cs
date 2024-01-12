namespace BetterThanAliexpress.EntityFramework;

/// <summary>
/// DataBase class for buyer
/// </summary>
public sealed class Buyer
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required DateTime DateOfBirthday { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public ICollection<Product>? ProductBasket { get; set; }
}

public sealed class Seller
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Inn { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string CompanyAddress { get; set; }
    public ICollection<Product>? Products { get; set; }
}

public sealed class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Seller Seller { get; set; }
    public required int Price { get; set; }
    public required ProductCategory ProductCategory { get; set; }
}

public sealed class ProductCategory
{
    public int Id { get; set; }
    public required string Name;
    public ICollection<Product>? Products;
}

public sealed class Admin
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Login { get; set; }
    public required string PhoneNumber { get; set; }
}
