namespace Shared.Constants;

public static class Config
{
    public static class Values
    {
        public const string True = "true";
        public const string False = "false";

        public static class Environment
        {
            public const string Local = "Local";
            public const string Development = "Development";
            public const string Production = "Production";
        }
    }

    public static class Envs
    {
        public static class Db
        {
            public const string Connection = "DB_CONNECTION";
        }

        public static class Container
        {
            public const string IsRunning = "DOTNET_RUNNING_IN_CONTAINER";
        }
    }
}