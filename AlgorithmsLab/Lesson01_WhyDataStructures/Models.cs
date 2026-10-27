namespace AlgorithmsLab.Lesson01_WhyDataStructures
{
    public record Product(int Id, decimal Price);

    public record OrderItem(int ProductId, int Quantity);
}
