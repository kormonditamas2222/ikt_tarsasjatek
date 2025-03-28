namespace tarsasjatek
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            List<Jatekos> jatekos = new List<Jatekos>();
            Console.Write("Hány játékos vegyen részt a társasjátékban: ");
            int jatekosok_szama = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < jatekosok_szama; i++)
            {
                Console.Write($"Mi legyen {i + 1}. játékos neve:");
                string nev = Console.ReadLine();
                jatekos.Add(new Jatekos(nev));
            }

        }
    }
}
