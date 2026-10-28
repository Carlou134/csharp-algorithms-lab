namespace AlgorithmsLab.Lesson03_Nodes
{
    public class Node<T>
    {
        public T Data { get; }
        public Node<T>? Next { get; set; }

        public Node(T data, Node<T>? next = null)
        {
            Data = data;
            Next = next;
        }
    }
}
