using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsasjatek
{
    
    internal class Jatekos
    {
        static Random random = new Random();
        string name;
        int pos;

        public Jatekos(string name)
        {
            this.name = name;
            this.pos = 0;
        }

        public string Name { get => name; set => name = value; }
        public int Pos { get => pos; set => pos = value; }

        public override string? ToString()
        {
            return $"Jelenlegi pozíció {name} játékosnak: {pos}";
        }
        public void Dobas()
        {
            pos += random.Next(1, 7);
        }
    }
}
