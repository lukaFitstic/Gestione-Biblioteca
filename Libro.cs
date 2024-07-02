using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    public class Libro
    {
        // define the variables
        public string ISBN { get; set; } //recognise code
        public string Titolo { get; set; } //title
        public string Autore { get; set; } //author
        public int AnnoDiPubblicazione { get; set; } // published year
        public bool Disponibile { get; set; } = true; // disponibility 
        public int NumeroCopie { get; set; } // enable copy
        public int CopieBorrowed { get; set; } // boorow copy

        // method that permit the configuration of a book
        public void Edit()
        {
            Console.Write("Inserisci il Codice ISBN: ");
            ISBN = Console.ReadLine().ToUpper();
            Console.Write("insert the Title: ");
            Titolo = Console.ReadLine();
            Console.Write("insert the Autore: ");
            Autore = Console.ReadLine();
            Console.Write("insert the publish year: ");
            AnnoDiPubblicazione = Convert.ToInt32(Console.ReadLine());
            Console.Write("insert the number of book copy enable: ");
            NumeroCopie = Convert.ToInt32(Console.ReadLine());
            
        }
        // method that print the book data
        public void Print()
        {
            string disponibilita = Disponibile ? "Disponibile" : "NON Disponibile";
            
            Console.WriteLine($"the {Titolo} is a book wrote from {Autore} in the {AnnoDiPubblicazione} \nis actually {disponibilita} with {CopieBorrowed} borrowed and {NumeroCopie} enable");
        }

        // method that permit the book borrow, updating the "db" 

        public void BookBorrow()
        {
            if (NumeroCopie > 0)
            {
                CopieBorrowed++;
                NumeroCopie--;

                Console.WriteLine($"Una copia del libro '{Titolo}' è stata prestata.");
            }
            else
            {
                Disponibile = false;
                Console.WriteLine($"Tutte le copie del libro '{Titolo}' sono attualmente in prestito.");
            }


        }
        
        // method that permit the returnig of a book, updating the "db"
        public void GiveItBack()
        {
            
            if (CopieBorrowed > 0)
            {
                CopieBorrowed--;
                NumeroCopie++;
                
                Console.WriteLine($"Una copia del libro '{Titolo}' è stata restituita.");
            }
            else
            {
                Console.WriteLine($"Non ci sono copie del libro '{Titolo}' attualmente in prestito.");
            }
            Disponibile = true;
            //Console.WriteLine($"Il libro {Titolo} è stato restituito ed è ora Disponibile");
        }
        
    }
}
