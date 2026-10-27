namespace AlgorithmsLab.Lesson02_DataStructureApi
{
    public class UniqueVisitorCounter
    {
        // TODO: elegí la colección privada.

        public void RegisterVisit(int userId)
        {
            throw new NotImplementedException();
        }

        public int UniqueVisitors => throw new NotImplementedException();
    }

    public static class Exercise01
    {
        public static void Run()
        {
            var counter = new UniqueVisitorCounter();

            counter.RegisterVisit(1);
            counter.RegisterVisit(2);
            counter.RegisterVisit(1); // el mismo usuario vuelve a entrar
            counter.RegisterVisit(3);
            counter.RegisterVisit(2);

            Console.WriteLine($"Visitantes distintos: {counter.UniqueVisitors} (esperado: 3)");
        }
    }
}
