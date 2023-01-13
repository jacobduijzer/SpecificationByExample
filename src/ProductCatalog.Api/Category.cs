using System.Text.Json.Serialization;

namespace ProductCatalog.Api;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Category
{
    SoftwareDevelopment,
    Testing,
    AgileMethodology
}