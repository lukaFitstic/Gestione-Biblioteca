using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            /*
             * publish the class in the main, configuring how many book/s i want configure, 
             * i enter the require information and i follow the instruction.
             */
            bool continua = true; //define the bool variable used after to permit the exit from the loop
            Console.Write("Imposta quanti libri vuoi inserire nel registro: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Libro[] libri = new Libro[n];
            /*
             * based on how many book/s i decide to configurate i'll enter the require information
             */
            for (int i = 0; i < libri.Length; i++) 
            {
                libri[i] = new Libro();
                Console.WriteLine($"Inserisci i dettagli del libro {i + 1}");
                libri[i].Edit();

            }
            /*
             * loop that permit to use the application until u push E(Exit)
             * 
             */
            while (continua)
            {
                Console.WriteLine("Digita un dei seguinti numeri per eseguire una delle seguenti azioni: \n " +
                    "V: Visualizza tutti i libri \n" +
                    "P: Presta un libro \n" +
                    "R: Riconsiglia un libro \n" +
                    "E: Esci");
                string scelta = Console.ReadLine().ToUpper();

                switch (scelta)
                {
                    case "V":
                        Console.WriteLine("Visualizza i libri:");
                        foreach (var libro in libri)
                        {
                            libro.Print();
                        }
                        break;
                    case "P":
                        Console.WriteLine("Inserisci il codice ISBN del libro che vuoi cercare");
                        string isbnPrestare = Console.ReadLine().ToUpper();
                        var libroDaPrestare = Array.Find(libri, libro => libro.ISBN == isbnPrestare);
                        if (libroDaPrestare != null)
                        {
                            libroDaPrestare.BookBorrow();
                        }
                        else
                        {
                            Console.WriteLine("Libro non trovato");
                        }
                        break;
                    case "R":
                        Console.WriteLine("Inserisci il codice ISBN del libro che vuoi restituire");
                        string isbnRestituire = Console.ReadLine().ToUpper();
                        var libroDaRestituire = Array.Find(libri, libro => libro.ISBN == isbnRestituire);
                        if (libroDaRestituire != null)
                        {
                            libroDaRestituire.GiveItBack();
                        }
                        else
                        {
                            Console.WriteLine("Azione non riuscita");
                        }
                        break;
                    case "E":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Azione non valida");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
