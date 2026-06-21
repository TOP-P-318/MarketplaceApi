namespace ProductsApi.Core.Constants;

public static class Limits
{
    public static class Product
    {
        public static class Name
        {
            public const int MaxLength = 63;
            public const int MinLength = 7;
        }
        
        public static class Description
        {
            public const int MaxLength = 2047;
        }
    }
}