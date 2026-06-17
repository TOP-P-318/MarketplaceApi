namespace ProductsApi.Core.Constants;

public static class Routes
{
    public static class Product
    {
        public static class Name
        {
            public const string Get = "GetProduct";
            public const string Update = "UpdateProduct";
            public const string Delete = "DeleteProduct";
            public const string Create = "CreateProduct";
        }
    }

    public static class Products
    {
        public static class Name
        {
            public const string GetAll = "GetAllProducts";
        }
    }
}