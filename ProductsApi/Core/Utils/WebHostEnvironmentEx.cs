using ProductsApi.Core.Constants;

namespace ProductsApi.Core.Utils;

public static class WebHostEnvironmentEx
{
    public static bool IsLocal(this IWebHostEnvironment hostingEnvironment) =>
        hostingEnvironment.IsEnvironment(Config.Envs.Environment.Local);
}