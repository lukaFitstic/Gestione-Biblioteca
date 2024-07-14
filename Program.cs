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


            bool continua = true; //define the bool variable used after to permit the exit from the
            int numeroLibri = 0;
            bool inputValido = false;
            Console.Write("Imposta quanti libri vuoi inserire nel registro: ");
            while (!inputValido)
            {
                string n = Console.ReadLine();
                if (int.TryParse(n, out numeroLibri) && numeroLibri > 0)
                {
                    inputValido = true;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserisci un altro numero");
                    Console.Write("->");
                }
            }

            //   based on how many book/s i decide to configurate i'll enter the require information


            Libro[] libri = new Libro[numeroLibri];
            for (int i = 0; i < libri.Length; i++)
            {
                libri[i] = new Libro();
                Console.WriteLine($"Inserisci i dettagli del libro {i + 1}");
                //libri[i].Edit();
                try
                {
                    using (var context = new LibraryContext())
                    {
                        var autore = new Author
                        {
                            AuthorName = "Nome Autore"
                        };



                        /*var libro = new Libro();
                        libri[i].Edit(); // Chiamata al metodo per configurare il libro

                        context.Libri.Add(libro);
                        context.SaveChanges();

                        Console.WriteLine("Libro salvato correttamente.");*/

                        var libro = new Libro
                        {
                            ISBN = "1234567890123",
                            Titolo = "Titolo del Libro",
                            AutoreId = autore.AuthorId,  // Associa l'ID dell'autore al libro
                            AnnoDiPubblicazione = 2021,
                            NumeroCopie = 10
                        };
                        context.Libri.Add(libro);
                        context.SaveChanges();

                        Console.WriteLine("Libro salvato con successo nel database.");
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Errore interno: {ex.InnerException.Message}");
                        if (ex.InnerException.InnerException != null)
                        {
                            Console.WriteLine($"Errore interno più dettagliato: {ex.InnerException.InnerException.Message}");
                        }
                    }
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                }

                Console.WriteLine("Premi un tasto per terminare...");
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

            }
            //loop that permit to use the application until u push E(Exit)

            while (continua)
            {
                Console.WriteLine();
                Console.WriteLine("Digita un dei seguinti numeri per eseguire una delle seguenti azioni: \n" +
                    "V: Visualizza tutti i libri \n" +
                    "S: Cerca il libro che vuoi visualizzare\n" +
                    "P: Presta un libro \n" +
                    "R: Riconsiglia un libro \n" +
                    "E: Esci");
                string scelta = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (scelta)
                {
                    case "V":
                        Console.WriteLine("Visualizza i libri:");
                        foreach (var libro in libri)
                        {
                            libro.Print();

                        }
                        break;
                    case "S":
                        Console.WriteLine("Inserisci il codice ISBN del libro che vuoi visualizzare");
                        string isbnVisualizzare = Console.ReadLine().ToUpper();
                        var libroDaCercare = Array.Find(libri, libro => libro.ISBN == isbnVisualizzare);
                        if (libroDaCercare != null)
                        {
                            libroDaCercare.Print();

                        }
                        else
                        {
                            Console.WriteLine("Libro non trovato");
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

            /* try
             {
                 using (var context = new LibraryContext())
                 {
                     var libro = new Libro();
                     libro.Print();

                     context.Libri.Add(libro);
                     context.SaveChanges();
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Errore: {ex.Message}");
                 Console.WriteLine($"Stack Trace: {ex.StackTrace}");
             }

             Console.WriteLine("Premi un tasto per terminare...");
             Console.ReadKey();
         }

     }*/
        }
    }
}
