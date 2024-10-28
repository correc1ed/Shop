namespace Shop.Abstractions.Products.Models;
public class ProductViewModel
{
    public required Guid Id { get; init; }
    public required string? Name { get; init; }
    public required string? Description { get; init; }
    public required decimal Price { get; init; }
    public required int CountInStorage { get; init; }
    public required string? Category { get; init; }
}
