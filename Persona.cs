using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    public class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set;}
        public int Eta { get; set; }


        public void Resume()
        {
            Console.Write($"Hello my name is {Nome} {Cognome} and i'm {Eta}");
        }
    }
}
