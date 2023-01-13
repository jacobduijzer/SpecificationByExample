using System.Text.Json.Serialization;

namespace ProductCatalog.Api;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BookFormat
{
    PDF,
    Epub,
    Paperback,
    Hardcover
}