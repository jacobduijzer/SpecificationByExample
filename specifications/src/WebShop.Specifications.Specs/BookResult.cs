using TechTalk.SpecFlow.Assist.Attributes;

namespace WebShop.Specifications.Specs;

public class BookResult
{
    [TableAliases("Titel")]
    public string Title { get; set; }
    [TableAliases("Auteur")]
    public string Author{ get; set; }
    [TableAliases("Formaat")]
    public string Format { get; set; }
    public int Amount { get; set; }
}