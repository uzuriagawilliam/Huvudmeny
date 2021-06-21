using System;
using System.Collections.Generic;

namespace Huvudmeny
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                ShowMeny();
                AskForChoice();                         
               
            } while ( true );            
        }

        private static void AskForChoice()
        {
            switch (Console.ReadLine())
            {
                case "0":
                    Environment.Exit(1); //Avslutar programmet
                    break;
                case "1":
                    UngdomEllerPens();
                    break;
                case "2":
                    loopTio();
                    break;
                case "3":
                    GroupPrice();
                    break;
                case "4":
                    trdjeOrdet();
                    break;
                default:
                    FelaktigInput();
                    break;
            }
        }

        private static void GroupPrice()//Get input and give an aswer
        {            
            int totalPrice = 0;
            int antal;
            string answer;            
            bool bio = true;          
            
            do
            {
                Console.WriteLine("Hur många ska gå in på bio?");
                string antalToInt = Console.ReadLine();
                bool isParsable = Int32.TryParse(antalToInt, out antal);
                if (isParsable)
                {
                    bio = false;
                }
            } while (bio == true);
            

            List<int> visitors = new();
            

            for (int i = 0; i < antal; i++)
            {
                int visitToint;
                bool flag = true;
                
                do
                {
                    Console.WriteLine($"Person {i + 1}.");
                    answer = Console.ReadLine();
                    bool isParsable = Int32.TryParse(answer, out visitToint);
                    if (isParsable) flag = false;

                } while (flag == true);
                         
                visitors.Add(visitToint);
            }
            foreach (var num in visitors)
            {
                if (num <= 5)
                {
                    totalPrice += 0;                    
                }
                if ((num <= 20) && (num >= 5))
                {
                    totalPrice += 80;                    
                }
                if ((num >= 65) && (num <= 99))
                {
                    totalPrice += 90;                    
                }
                if (num >= 100)
                {
                    totalPrice += 0;                    
                }

                if ((num > 20) && (num < 65))
                {
                    totalPrice += 120;
                }
            }
            Console.WriteLine($"Total prisset är { totalPrice}");
            Console.ReadLine();
        }

        private static void FelaktigInput()
        {
            bool hastaLaVista = false;
            string stop;
            do
            {
                Console.Beep();
                Console.WriteLine("felaktig input");
                Console.WriteLine("Type 9. to return to \"Huvudmeny\" 0 to exit");
                stop = Console.ReadLine();
                if (stop == "9")
                    hastaLaVista = true;
                if (stop == "0")
                    Environment.Exit(1); //Avslutar programmet
            } while (!hastaLaVista);
        }

        private static void trdjeOrdet()
        {
            Console.WriteLine("Mata in en mening med minst 3 ord");
            string wordsToSeparate = Console.ReadLine();
            string[] wordList = wordsToSeparate.Split(" ", StringSplitOptions.RemoveEmptyEntries); //  StringSplitOptions.RemoveEmptyEntries tar bort alla extra mellanslag    

            Console.WriteLine(wordList[2]);
            Console.ReadLine();
        }

        private static void loopTio()
        {
            Console.WriteLine("Mata in ett ord");
            string wordToLoop = Console.ReadLine();
            for (int i = 0; i <= 9; i++)
            {
                Console.Write($"{ i + 1}. { wordToLoop }, ");
            }
            Console.ReadLine();
        }

        private static void UngdomEllerPens()
        {
            Console.WriteLine("Ange ålder i siffror");
            string ageStr = Console.ReadLine();
            int age = ValidateImput(ageStr);  //Kollar att inmatning är korrekt

            if ((age <= 5) && (age != 0))   //Extra uppgift
            {
                Console.WriteLine("Barn under fem år går in gratis");
                Console.ReadLine();
            }

            if ((age <= 20) && (age >= 5))
            {
                Console.WriteLine("Ungdomspris: 80kr");
                Console.ReadLine();
            }
            if ((age >= 64) && (age <= 99))
            {
                Console.WriteLine("Pensionärspris: 90kr");
                Console.ReadLine();
            }
            if (age >= 100)     //Extra uppgift
            {
                Console.WriteLine("pensionärer över 100 går in gratis");
                Console.ReadLine();                
            }
            if ((age > 20) && (age < 65))
            {
                Console.WriteLine("Standardpris: 120kr");
                Console.ReadLine();
            }                 
        }

        private static void ShowMeny()
        {
            Console.Clear();
            Console.WriteLine("Huvudmeny");
            Console.WriteLine("Type 0. to exit");
            Console.WriteLine("Menyval 1: Ungdom eller pensionär");
            Console.WriteLine("Menyval 2: Upprepa tio gånger");
            Console.WriteLine("Menyval 3: Helt sällskaps pris.");
            Console.WriteLine("Menyval 4: Det tredje ordet");
        }

        static int ValidateImput(string v)
        {
                do
                {
                bool isParsable = Int32.TryParse(v, out int vInt);
                if (isParsable)
                {
                    return vInt;
                }
                else                
                {
                    FelaktigInput();                 
                    return 0;
                }
            } while (true);
        }
    }
}
