namespace ProductsApi.Core.Constants;

public static class Config
{
    public static class Envs
    {
        public static class Db
        {
            public const string Connection = "DB_CONNECTION";
        }  
        
        public static class Environment
        {
            public const string Local = "Local";
            public const string Development = "Development";
            public const string Production = "Production";
        }
    }
}