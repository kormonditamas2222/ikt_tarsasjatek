using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsasjatek
{
    internal class Tabla
    {
        static Random random = new Random();
        int akadaly_pos;
        int bonusz_pos;
        int random_pos;
        int halal_pos;
        int kviz_pos;
        int max_pos;

        public Tabla()
        {
            max_pos = random.Next(10, 50);
            akadaly_pos = 0;
            bonusz_pos = 0;
            random_pos = 0;
            halal_pos = 0;
            kviz_pos = 0;
        }

        public int Akadaly_pos { get => akadaly_pos;  }
        public int Bonusz_pos { get => bonusz_pos; }
        public int Random_pos { get => random_pos; }
        public int Halal_pos { get => halal_pos; }
        public int Kviz_pos { get => kviz_pos; }
        public int Max_pos { get => max_pos;  }

        public void Generalas()
        {
            do
            {
                akadaly_pos = random.Next(1, max_pos);
                bonusz_pos = random.Next(1, max_pos);
                random_pos = random.Next(1, max_pos);
                halal_pos = random.Next(1, max_pos);
                kviz_pos = random.Next(1, max_pos);
            } while (akadaly_pos != bonusz_pos && akadaly_pos != random_pos && akadaly_pos != halal_pos && akadaly_pos != kviz_pos && bonusz_pos != random_pos && bonusz_pos != halal_pos && bonusz_pos != kviz_pos && random_pos != halal_pos && random_pos != kviz_pos && halal_pos != kviz_pos);
        }
        public void Akadaly(Jatekos jatekos)
        {
            int vissza = 3;
            if (jatekos.Pos - vissza < 0)
            {
                jatekos.Pos = 0;
            }
            else
            {
                jatekos.Pos -= vissza;
            }
        }
        public void Bonusz(Jatekos jatekos)
        {
            jatekos.Pos += 3;
        }
        public void Random(Jatekos jatekos)
        {
            int barmi = random.Next(0,3);
            switch (barmi)
            {
                case 0: jatekos.Pos = barmi; break;
                case 1: jatekos.Pos += random.Next(1, 7); break;
                case 2: Console.WriteLine("Skibidi toilet Xd!"); break;
                default: Console.WriteLine("rósz"); break;
            }
        }
        public void Halal(List<Jatekos> jatekosok, Jatekos jatekos) 
        {
            foreach (Jatekos item in jatekosok)
            {
                if (item.Equals(jatekos))
                {
                    jatekosok.Remove(item);
                    Console.WriteLine("a létezésed megszűnt :>");
                }
            }
        }
        public void Kviz(Jatekos jatekos)
        {
            int barmi = random.Next(0, 3);
            switch (barmi)
            {
                case 0: Console.WriteLine("Hány évig tartott a száz éves háború?"); if (int.Parse(Console.ReadLine()) == 116) { Console.WriteLine("Helyes válasz!"); Bonusz(jatekos); } else { Console.WriteLine("Rossz válasz!"); }; break;
                case 1: Console.WriteLine("Hány proton található egy asztácium atomban?"); if (int.Parse(Console.ReadLine()) == 85) { Console.WriteLine("Helyes válasz!"); Bonusz(jatekos); } else { Console.WriteLine("Rossz válasz!"); }; ; break;
                case 2: Console.WriteLine("Melyik a világ leghosszab folyója?"); if (Console.ReadLine() == "Amazonas") { Console.WriteLine("Helyes válasz!"); Bonusz(jatekos); } else { Console.WriteLine("Rossz válasz!"); }; ; break;
                default: Console.WriteLine("kvíz rósz"); break;
            }
        }
    }
}
