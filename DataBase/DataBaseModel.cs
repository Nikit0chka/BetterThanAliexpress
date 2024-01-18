namespace DataBase;

/// <summary>
///     DataBase class for buyer
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
    public ICollection<Product> ProductBasket { get; set; } = new List<Product>();
}

public sealed class Seller
{
    public int Id { get; set; }
    public required bool IsAdminConfirmed { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Inn { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string CompanyAddress { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public sealed class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Seller Seller { get; set; }
    public required string Description { get; set; }
    public required int Count { get; set; }
    public required int Price { get; set; }
    public required ProductCategory ProductCategory { get; set; }
}

public sealed class ProductCategory
{
    public required string Name;
    public ICollection<Product> Products = new List<Product>();
    public int Id { get; set; }
}

public sealed class Admin
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}
