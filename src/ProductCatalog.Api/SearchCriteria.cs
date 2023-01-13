using System.Reflection;

namespace ProductCatalog.Api;

public class SearchCriteria
{
    public string? Author { get; set; }
    public string? Title { get; set; }
    public BookFormat? Format { get; set; }
    public Category? Category { get; set; }

    public static ValueTask<SearchCriteria?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        string author = context.Request.Query["Author"];
        string titleContains = context.Request.Query["TitleContains"];
        Enum.TryParse(context.Request.Query["Format"], out BookFormat bookFormat);
        Enum.TryParse(context.Request.Query["Category"], out Category category);

        var result = new SearchCriteria
        {
            Author = author,
            Title = titleContains,
            Format = bookFormat,
            Category = category
        };

        return ValueTask.FromResult<SearchCriteria?>(result);
    }
}