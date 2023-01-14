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
}
