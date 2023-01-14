using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guy jacek = new Guy() { Name = "Jacek", Cash = 50 };
            Guy bartek = new Guy() { Name = "Bartek", Cash = 100 };

            while (true)
            {
                bartek.WriteMyInfo();
                jacek.WriteMyInfo();
                Console.Write("Podaj kwotę: ");
                string howMuch = Console.ReadLine();
                if(howMuch == "")
                {
                    return;
                }
                if (int.TryParse(howMuch, out int howMuchInt))
                {
                    Console.Write("Pieniądze ma przekazać: ");
                    string whichGuy = Console.ReadLine();
                    if(whichGuy == jacek.Name)
                    {
                        jacek.GiveCash(howMuchInt);
                        bartek.ReceiveCash(howMuchInt);
                    }else if(whichGuy == bartek.Name)
                    {
                        jacek.ReceiveCash(howMuchInt);
                        bartek.GiveCash(howMuchInt);
                    }
                    else
                    {
                        Console.WriteLine("Wpisz 'Jacek' lub 'Bartek'");
                    }
                }
                else
                {
                    Console.WriteLine("Wpisz kwotę (lub pozostaw pusty wiersz, aby zakończyć).");
                }
            }
            
        }
    }

    class Guy
    {
        public string Name;
        public int Cash;
        /// <summary>
        /// Wyświetla w konsoli imię i posiadaną kwotę
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " ma " + Cash + " zł.");
        }
        /// <summary>
        /// Przekazuje pieniądze i usuwa je z portfela (lub wyświetla w konsoli komunikat o braku środków).
        /// </summary>
        /// <param name="amount">Przekazywana kwota</param>
        /// <returns>
        /// Ilość pieniędzy wyjmowanych z portfela lub 0, jeśli dostępne środki są za małe (lub parametr jest nieprawidłowy)
        /// </returns>
        public int GiveCash(int amount) {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " mówi: " + amount + " nie jest poprawną kwotą.");
                return 0;
            }
            if(amount > Cash)
            {
                Console.WriteLine(Name + " mówi:" + " nie mam wystarczających środków, aby dać ci " + amount + " zł.");
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        public void ReceiveCash(int amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine(Name + " mówi: " + "nie przyjmuję " + amount + " zł.");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}
