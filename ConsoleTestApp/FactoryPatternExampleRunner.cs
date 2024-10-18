using FactoryPatternExample;

namespace TestConsoleApp
{
    public static class FactoryPatternExampleRunner
    {
        public static void Run()
        {
            List<ProductBase> products = new List<ProductBase>();
            List<CategoryBase> categories = new List<CategoryBase>();

            ProductBase digitalBook = FactoryPattern<DigitalBook, ProductBase>.GetInstance();

            AddPropertiesToProduct(digitalBook, 1, "1984", 1);

            products.Add(digitalBook);

            ProductBase movie = FactoryPattern<Movie, ProductBase>.GetInstance();

            AddPropertiesToProduct(movie, 2, "Inception", 2);

            products.Add(movie);

            movie = FactoryPattern<Movie, ProductBase>.GetInstance();

            AddPropertiesToProduct(movie, 3, "The Matrix", 2);

            products.Add(movie);

            ProductBase album = FactoryPattern<MusicRecording, ProductBase>.GetInstance();

            AddPropertiesToProduct(album, 4, "Abbey Road", 3);

            products.Add(album);

            CategoryBase digitalBookCategory = FactoryPattern<DigitalBookCategory, CategoryBase>.GetInstance();

            AddPropertiesToCategory(digitalBookCategory, 1, "Book", "Books digitized for download");

            categories.Add(digitalBookCategory);

            CategoryBase movieCategory = FactoryPattern<MovieCategory, CategoryBase>.GetInstance();

            AddPropertiesToCategory(movieCategory, 2, "Movie", "Movies digitized for download");

            categories.Add(movieCategory);

            CategoryBase musicCategory = FactoryPattern<MusicCategory, CategoryBase>.GetInstance();

            AddPropertiesToCategory(musicCategory, 3, "Music", "Music digitized for download");

            categories.Add(musicCategory);

            var queryResults = GetProducts(products, categories);

            foreach (var result in queryResults)
            {
                Console.WriteLine($"Product Id: {result.ProductId}");
                Console.WriteLine($"Title: {result.Title}");
                Console.WriteLine($"Category: {result.Category}");
                Console.WriteLine($"Category Description: {result.CategoryDescription}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static IEnumerable<ProductViewModel> GetProducts(List<ProductBase> products, List<CategoryBase> categories)
        {
            return products
                .Join(categories, p => p.CategoryId, c => c.Id, (p, c) => new ProductViewModel
                {
                    ProductId = p.Id,
                    Title = p.Title,
                    Category = c.Title,
                    CategoryDescription = c.Description
                });
        }

        private static void AddPropertiesToCategory(CategoryBase category, int id, string title, string description)
        {
            category.Id = id;
            category.Title = title;
            category.Description = description;
        }

        private static void AddPropertiesToProduct(ProductBase product, int id, string title, int categoryId)
        {
            product.Id = id;
            product.Title = title;
            product.CategoryId = categoryId;
        }
    }
}
