using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClasses
{
    public class Libro
    {
        // definisco le variabili
        public string ISBN { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public int AnnoDiPubblicazione { get; set; }
        public bool Disponibile { get; set; } = true;
        public int NumeroCopie { get; set; }
        public int CopieBorrowed { get; set; }

        // metodo che permette la modifica/compilazione del libro
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
        // metodo che stampa i dati del libro
        public void Print()
        {
            string disponibilita = Disponibile ? "Disponibile" : "NON Disponibile";
            
            Console.WriteLine($"the {Titolo} is a book wrote from {Autore} in the {AnnoDiPubblicazione} \nis actually {disponibilita} with {CopieBorrowed} borrowed and {NumeroCopie} enable");
        }

        // metodo che imposta la disponibilità a false --> ossia non disponibile

        public void BookBorrow()
        {
            if (NumeroCopie > 1)
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
        /*
        public void BookBorrow()
        { 
            if (CopieBorrowed < NumeroCopie)
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
        */
        // metodo che imposta la disponibilità a true --> ossia disponibile
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
        /*public void NumeroCopieEnable()
        {
            if((NumeroCopie -= CopieBorrowed) > 0)
            {
                NumeroCopie -= CopieBorrowed;
            }
            else
            {
                CopieBorrowed -= NumeroCopie;
            }
            
            Console.WriteLine($"{Titolo} ha disponibili {NumeroCopie} copie");
        }*/
        /*
        public void NumeroCopieBorrowed()
        {
            if ((NumeroCopie += CopieBorrowed) > 0)
            {
                NumeroCopie -= CopieBorrowed;
            }
            else
            {
                CopieBorrowed -= NumeroCopie;
            }
            Console.WriteLine($"{Titolo} copie prestate: {CopieBorrowed}");
        }*/
    }
}
