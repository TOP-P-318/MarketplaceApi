namespace ProductsApi.Core.Utils;

public static class StringEx
{
    public static Uri? ToUri(this string str) =>
        Uri.TryCreate(str, UriKind.RelativeOrAbsolute, out var uri) ? uri : null;
}