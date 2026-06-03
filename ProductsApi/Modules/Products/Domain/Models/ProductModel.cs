namespace ProductsApi.Modules.Products.Domain.Models;

public sealed class ProductModel : IComparable<ProductModel>
{
    public string Name { get; init; } = string.Empty;

    public override bool Equals(object? obj) =>
        ReferenceEquals(this, obj) || 
        obj is ProductModel other
        && Name == other.Name;

    public override int GetHashCode() => Name.GetHashCode();

    public int CompareTo(ProductModel? other)
    {
        if (Equals(other)) return 0;
        return other is null ? 1 : string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}