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

            /*var studente = new Luka
            {
                Nome = Console.ReadLine(),
                Cognome = Console.ReadLine(),
                Eta = Convert.ToInt32(Console.ReadLine()),
                hairColor = Console.ReadLine(),
                height = Console.ReadLine(),
                width = Convert.ToInt32(Console.ReadLine())
               
            };
            studente.LukaData();*/

            /*
             * pubblico la classe nel main, imposto la disponibilità di liviri da configurare
             * uso un ciclo for per configurare ogni libro diviso per numero
             * uso un foreach per stampare ogni libro in fila
             */
            bool continua = true;
            Console.Write("Imposta quanti libri vuoi inserire nel registro: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Libro[] libri = new Libro[n];
            for (int i = 0; i < libri.Length; i++)
            {
                libri[i] = new Libro();
                Console.WriteLine($"Inserisci i dettagli del libro {i + 1}");
                libri[i].Edit();

            }
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

           /* Console.Write("Imposta quanti libri vuoi inserire nel registro: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Libro[] libri = new Libro[n];
            for (int i = 0; i < libri.Length; i++)
            {
                libri[i] = new Libro();
                Console.WriteLine($"Inserisci i dettagli del libro {i + 1}");
                libri[i].Edit();
                
            }
            Console.WriteLine("Stampa dei Libri");
            foreach(var libro in libri)
            {
                libro.Print();
            }*/
            /*
             * testo i metodi di prestito e restituzione dei libri
             */
            /*
             * Controllare metodo disponibilità libri, non conta bene
             */
           /*
            libri[0].BookBorrow();
            libri[0].BookBorrow();
            libri[0].BookBorrow();
           // libri[0].NumeroCopieEnable();
           // libri[0].NumeroCopieBorrowed();
            libri[0].Print();
            libri[0].GiveItBack();
           //libri[0].NumeroCopieBorrowed();
            libri[0].Print();
           */
            Console.ReadKey();
        }
    }
}
