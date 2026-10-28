namespace AlgorithmsLab.Lesson03_Nodes
{
    public static class Exercise01
    {
        public static void Run()
        {
            var d = new Node<string>("d");
            var c = new Node<string>("c", d);
            var b = new Node<string>("b", c);
            var a = new Node<string>("a", b);
            var x = new Node<string>("x");

            Print("Antes", a);

            // TODO 1: insertá x entre a y b. Cuidá el orden de las asignaciones.
            x.Next = a.Next;
            a.Next = x;

            // TODO 2: sacá c sin perder d.
            b.Next = c.Next;

            Print("Después", a);
            Console.WriteLine("Esperado: a → x → b → d → null");
        }

        private static void Print<T>(string label, Node<T>? head)
        {
            Console.Write($"{label}: ");
            for (var current = head; current is not null; current = current.Next)
                Console.Write($"{current.Data} → ");
            Console.WriteLine("null");
        }
    }
}
