using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    public class Luka : Persona
    {
        public string hairColor { get; set; }
        public string height { get; set;}
        public double width { get; set;}

        public void LukaData()
        {
            Resume();
            Console.Write($" my hair are {hairColor} and i am {height} x {width}");
        }
    }
}
