namespace ProductsApi.Core.Constants.Responses;

public static class ResponseMessages
{
    public static class Products
    {
        public static class BadRequest
        {
            public const string AlreadyExists = "Product with same name already exists";
        }
    }
}