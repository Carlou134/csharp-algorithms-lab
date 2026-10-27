using System.Diagnostics;

namespace AlgorithmsLab.Lesson01_WhyDataStructures
{
    public static class Exercise02
    {
        private const int ProductCount = 10_000;
        private const int ItemCount = 40_000;

        public static void Run()
        {
            var (items, products) = GenerateData();
            Console.WriteLine($"Productos: {products.Count:N0} | Ítems: {items.Count:N0}");

            Measure("Lenta (List + First)", () => CalculateTotalSlow(items, products));

            try
            {
                Measure("Rápida (tu versión)", () => CalculateTotalFast(items, products));
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Rápida: todavía no la implementaste.");
            }
        }

        public static decimal CalculateTotalSlow(List<OrderItem> items, List<Product> products)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                var product = products.First(p => p.Id == item.ProductId);
                total += product.Price * item.Quantity;
            }
            return total;
        }

        public static decimal CalculateTotalFast(List<OrderItem> items, List<Product> products)
        {
            decimal total = 0;
            var pricesByProductId = products.ToDictionary(p => p.Id, p => p.Price);

            foreach (var item in items)
            {
                var price = pricesByProductId[item.ProductId];
                total += price * item.Quantity;
            }
            return total;
        }

        private static void Measure(string label, Func<decimal> calculate)
        {
            var stopwatch = Stopwatch.StartNew();
            var total = calculate();
            stopwatch.Stop();
            Console.WriteLine($"{label}: total = {total:N2} | {stopwatch.ElapsedMilliseconds:N0} ms");
        }

        private static (List<OrderItem> Items, List<Product> Products) GenerateData()
        {
            // Semilla fija: mismos datos en cada corrida, así comparás tiempos de forma justa.
            var random = new Random(42);

            var products = Enumerable.Range(1, ProductCount)
                .Select(id => new Product(id, random.Next(1, 1_000)))
                .ToList();

            var items = Enumerable.Range(0, ItemCount)
                .Select(_ => new OrderItem(random.Next(1, ProductCount + 1), random.Next(1, 10)))
                .ToList();

            return (items, products);
        }
    }
}
