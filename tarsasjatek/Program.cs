namespace tarsasjatek
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            Tabla tabla = new();
            tabla.Generalas();

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
            Console.WriteLine($"Az elérendő mező: {tabla.Max_pos}");
            Console.WriteLine("Dobni ENTER gombbal lehet.");
            bool vege = false;
            do
            {
                for (int i = 0; i < jatekosok_szama; i++)
                {
                    jatekos[i].Dobas();
                    if (jatekos[i].Pos > tabla.Max_pos)
                    {
                        jatekos[i].Pos = tabla.Max_pos - (jatekos[i].Pos - tabla.Max_pos);
                    }
                    Console.WriteLine(jatekos[i]);

                    if (jatekos[i].Pos == tabla.Akadaly_pos)
                    {
                        Console.WriteLine($"{jatekos[i].Name} akadály mezőre lépett");
                        tabla.Akadaly(jatekos[i]);
                        Console.WriteLine(jatekos[i]);
                    }
                    else if (jatekos[i].Pos == tabla.Bonusz_pos)
                    {
                        Console.WriteLine($"{jatekos[i].Name} bónusz mezőre lépett");
                        tabla.Bonusz(jatekos[i]);
                        Console.WriteLine(jatekos[i]);
                    }
                    else if (jatekos[i].Pos == tabla.Halal_pos)
                    {
                        Console.WriteLine($"{jatekos[i].Name} halál mezőre lépett");
                        tabla.Halal(jatekos, jatekos[i]);
                        if (jatekos.Count == 1)
                        {
                            vege = true;
                            Console.WriteLine($"{jatekos[0].Name} megnyerte a játékot.");
                            break;
                        }
                    }
                    else if (jatekos[i].Pos == tabla.Kviz_pos)
                    {
                        Console.WriteLine($"{jatekos[i].Name} kvíz mezőre lépett");
                        tabla.Kviz(jatekos[i]);
                        Console.WriteLine(jatekos[i]);
                    }
                    else if (jatekos[i].Pos == tabla.Max_pos)
                    {
                        vege = true;
                        Console.WriteLine($"{jatekos[i].Name} megnyerte a játékot.");
                        break;
                    }
                    //Console.WriteLine(jatekos[i]);
                    Console.ReadLine();
                }
            }
            while (vege == false);

        }
    }
}