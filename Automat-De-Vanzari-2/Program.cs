using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_De_Vanzari_2
{
    class Program
    {
        static bool menuiesire() // un simplu menu de iesire sau intrare in program
        {
            string raspuns;
            Console.WriteLine("0-Exit program \n1-Enter program\n");
            Console.Write(">>> ");
            raspuns=Console.ReadLine();
            if (raspuns == "1")
                return true;
            else if(raspuns!="0") //daca inputul nu este nici 0 atuncea programul va reafisa menu-ul prin auto apelare
            {
                Console.WriteLine("Wrong input. Try again. ");
                return menuiesire(); 
            }    
            return false;
        }

        static string inserare_monede() //returneaza tipul de moneda care este inserat de user
        {
            string raspuns;
            Console.WriteLine("Please insert a coin. \n0-Nickel \n1-Dime \n2-Quarter\n");
            Console.Write(">>> ");
            raspuns=Console.ReadLine();
            if(raspuns != "0") //verifica daca nu a introdus nicio moneda corecta
                if(raspuns!="1")
                    if(raspuns!="2") //atunci cand gaseste ca nicio moneda nu e valida, da mesaj de eroare si se auto apeleaza functia
                    {
                        Console.WriteLine("Wrong input. Try again. ");
                        return inserare_monede();
                    }
            return raspuns;
        }
        static void livrare(string proprietate)//livreaza si returneaza restul, primeste doar string-uri de 000,001,011 etc.
        {
            char[] functie;
            functie= proprietate.ToCharArray();
            if (functie[0].Equals('1'))//daca nu e 1 nu livreaza
                Console.WriteLine("Product dispensed. ");
            if (functie[1].Equals('1'))//daca nu e 1 nici nu returneaza nickel
                Console.WriteLine("Returned nickel. ");
            if (functie[2].Equals('1'))//daca nu e 1 nici nu returneaza un dime
                Console.WriteLine("Returned dime. ");
        }

        static void stare(string tip, string proprietate)
        {
            livrare(proprietate);
            string moneda;
            moneda = inserare_monede();
            switch (tip)
            {
                case "a": //cazul cand aparatul are 0 monede
                    switch (moneda)
                    {
                        case "0"://user-ul a adaugat 5 monede
                            stare("b", "000");//aparatul are 5 monede deci nu livreaza si nu da rest
                            break;
                        case "1"://user-ul a daugat 10 monede
                            stare("c", "000");//aparatul are 10 monede deci nu livreaza si nu da rest
                            break;
                        case "2"://user-ul a daugat 25 de monede
                            stare("a", "110");//aparatul are 25 de monede deci livreaza si da rest de 5
                            break;
                    }
                    break;
                case "b"://cazul cand aparatul are 5 monede
                    switch (moneda)
                    {
                        case "0"://user-ul a adaugat 5 monede
                            stare("c", "000");//aparatul are 10 monede deci nu livreaza nici nu da rest
                            break;
                        case "1"://user-ul a adaugat 10 monede
                            stare("d", "000");//aparatul are 15 monede deci nu livreaza nici nu da rest
                            break;
                        case "2"://user-ul a adaugat 25 de monede
                            stare("a", "101");//aparatul are 30 de monede deci se livreaza si de rest de 5
                            break;
                    }
                    break;
                case "c"://cazul cand aparatul are 10 monede
                    switch (moneda)
                    {
                        case "0"://se adauga 5 monede
                            stare("d", "000");//aparatul are 15 monede deci nu livreaza nici nu da rest
                            break;
                        case "1"://user-ul a daugat 10 monede
                            stare("a", "100");//aparatul are exact 20 de monede deci livreaza dar nu da rest
                            break;
                        case "2"://user-ul adaugat 25 monede
                            stare("a", "111");//aparatul are 35 de monede deci livreaza si da rest de 5 si 10
                            break;
                    }
                    break;
                case "d"://aparatul are 15 monede
                    switch (moneda)
                    {
                        case "0"://se adauga 5 monede
                            stare("a", "100");//aparatul are exact 20 de monede deci livreaza dar nu da rest
                            break;
                        case "1"://user-ul a daugat 10 monede
                            stare("a", "110");//aparatul are exact 25 de monede deci livreaza si da rest de 5
                            break;
                        case "2"://user-ul adaugat 25 monede
                            stare("b", "111");//aparatul are 40 de monede deci livreaza si da rest de 5 si 10 si in aparat sunt 5 monede
                            break;
                    }
                    break;
            }
        }
        static void Main(string[] args)
        {
            if (menuiesire() == true)
                stare("a", "000");
            Console.WriteLine("Exiting program. ");
            Console.ReadLine();
        }
    }
}
