namespace AlgorithmsLab.Lesson02_DataStructureApi
{
    public class ShoppingCart
    {
        private readonly List<CartItem> _items = new();
        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();
        public decimal Total => _items.Sum(i => i.Price * i.Quantity);

        public void AddItem(CartItem item)
        {
            _items.Add(item);
        }
    }

    public static class Exercise02
    {
        public static void Run()
        {
            var cart = new ShoppingCart();
            cart.AddItem(new CartItem("Teclado", 50m, 1));
            cart.AddItem(new CartItem("Mouse", 20m, 2));

            Print("Uso correcto", cart);
        }

        private static void Print(string label, ShoppingCart cart)
        {
            var realTotal = cart.Items.Sum(i => i.Price * i.Quantity);
            var status = cart.Total == realTotal ? "OK" : "DESINCRONIZADO";
            Console.WriteLine($"{label}: Total = {cart.Total} | Suma real = {realTotal} | {status}");
        }
    }
}
