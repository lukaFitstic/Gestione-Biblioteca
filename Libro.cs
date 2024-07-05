using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    public class Libro
    {
        // define the variables
        public string ISBN { get; set; } //recognise code
        public string Titolo { get; set; } //title
        public string Autore { get; set; } //author
        public int AnnoDiPubblicazione { get; set; } // publish year
        public bool Disponibile { get; set; } = true; // disponibility 
        public int NumeroCopie { get; set; } // enable copy
        public int CopieBorrowed { get; set; } // boorow copy
        private bool inputValido { get; set; } = false;
        

        // method that permit the configuration of a book
        public void Edit()
        {
            Console.Write("Inserisci il Codice ISBN: ");
            while (!inputValido)
            {
                ISBN = Console.ReadLine().ToUpper();
                if (Regex.IsMatch(ISBN, @"^[A-Z0-9]{12,}$")) //the check used here check that the user insertion is composed only of: Upper letters, number and the max lenght of this mix is 11 (At least 12)
                {
                    inputValido = true;
                }
                else
                {
                    Console.WriteLine("Input non valido. \nL'ISBN deve essere una sequenza di numeri e lettere con lunghezza maggiore di 11.");
                    Console.Write("->");
                }
            }
            inputValido = false;
            Console.Write("insert the Title: ");
            while (!inputValido)
            {
                Titolo = Console.ReadLine();
                if(Regex.IsMatch(Titolo, @"[a-z0-9]")) 
                {
                    inputValido = true;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserisci un input valido");
                    Console.Write("->");
                }
            }

            inputValido = false;

            Console.Write("insert the Autore: ");
            Autore = Console.ReadLine();
            Console.Write("insert the publish year: ");
            while (!inputValido)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int anno ) && anno > 1449)
                {
                    AnnoDiPubblicazione = anno;
                    inputValido = true;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserisci un valore valido");
                    Console.Write("->");
                }
            }
            inputValido = false;
            Console.Write("insert the number of book copy enable: ");
            while (!inputValido)
            {
                string NCopie = Console.ReadLine();
                if(int.TryParse(NCopie, out int numero) &&  numero >= 0)
                {
                    NumeroCopie = numero;
                    inputValido = true;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserisci un valore valido");
                    Console.Write("->");
                }
                
            }
            /*
                private string PrimaLetteraMaiuscola(string input)
                {
                    if (string.IsNullOrEmpty(input))
                        return input;
        
                    return char.ToUpper(input[0]) + input.Substring(1).ToLower();
                }
             */
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
