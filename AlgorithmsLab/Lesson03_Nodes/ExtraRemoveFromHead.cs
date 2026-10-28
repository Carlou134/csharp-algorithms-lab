namespace AlgorithmsLab.Lesson03_Nodes
{
    // EXTRA para estudiar en la lección de listas enlazadas.
    // Sacar un nodo teniendo solo la cabeza, incluido el caso de sacar la cabeza misma.
    // Preguntas para investigar:
    //   1. ¿Por qué EqualityComparer<T>.Default.Equals y no ==? (probá con != y mirá el error)
    //   2. ¿Por qué head = Remove(...) y no solo Remove(...)? (quitá el "head =" al sacar "a")
    //   3. ¿Cómo quedaría con un nodo centinela (dummy) para evitar el caso especial?
    public static class ExtraRemoveFromHead
    {
        public static void Run()
        {
            var d = new Node<string>("d");
            var c = new Node<string>("c", d);
            var b = new Node<string>("b", c);
            var x = new Node<string>("x", b);
            Node<string>? head = new Node<string>("a", x);

            Print("Antes", head);

            head = Remove(head, "c");
            Print("Sin c", head);
            Console.WriteLine("Esperado: a → x → b → d → null");

            // Caso especial: sacar la cabeza.
            head = Remove(head, "a");
            Print("Sin a", head);
            Console.WriteLine("Esperado: x → b → d → null");

            // Caso borde: el valor no existe.
            head = Remove(head, "z");
            Print("Sin z", head);
            Console.WriteLine("Esperado: x → b → d → null");
        }

        // Devuelve la cabeza porque, si se saca la primera, cambia.
        private static Node<T>? Remove<T>(Node<T>? head, T value)
        {
            var comparer = EqualityComparer<T>.Default;

            // La cabeza no tiene nodo anterior: se mueve la referencia al segundo.
            if (head is not null && comparer.Equals(head.Data, value))
                return head.Next;

            // Para el resto: buscar el ANTERIOR al que se quiere sacar.
            var previous = head;
            while (previous?.Next is not null && !comparer.Equals(previous.Next.Data, value))
                previous = previous.Next;

            if (previous?.Next is not null)
                previous.Next = previous.Next.Next;

            return head;
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
