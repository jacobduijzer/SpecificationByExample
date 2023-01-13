namespace ProductCatalog.Api;

public static class Products
{
    public static List<Book> Books = new()
    {
        new Book(
            new Guid("54C77AB9-02E5-4043-830C-E1703A852B4A"),
            "Specification By Example",
            "Gojko Adzic",
            BookFormat.PDF,
            new() {Category.Testing, Category.SoftwareDevelopment},
            22.67m),
        new Book(
            new Guid("45C36988-29FE-4432-8D57-DEE7627737F1"),
            "Specification By Example",
            "Gojko Adzic",
            BookFormat.Hardcover,
            new() {Category.Testing, Category.SoftwareDevelopment},
            31.49m),
        new Book(
            new Guid("5DF16698-7930-4AB9-83E1-CF8FE1806003"),
            "Writing Great Specifications",
            "Kamil Nicieja",
            BookFormat.Epub,
            new() {Category.Testing, Category.SoftwareDevelopment},
            22.67m),
        new Book(
            new Guid("FB9D59A6-9F79-426E-BD9D-D039610DC6FF"),
            "Writing Great Specifications",
            "Kamil Nicieja",
            BookFormat.Paperback,
            new() {Category.Testing, Category.SoftwareDevelopment},
            28.34m),
        new Book(
            new Guid("2D02AB87-8132-4AD7-8FD6-36639EECC7E2"),
            "Code That Fits In Your Head",
            "Mark Seeman",
            BookFormat.PDF,
            new() {Category.SoftwareDevelopment},
            23.99m),
        new Book(
            new Guid("92D59619-21DE-46FD-8B91-79A18E2678BC"),
            "Code That Fits In Your Head",
            "Mark Seeman",
            BookFormat.Hardcover,
            new() {Category.SoftwareDevelopment},
            35.99m),
    };
}