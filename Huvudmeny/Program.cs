using System;

namespace Huvudmeny
{
    class Program
    {
        static void Main(string[] args)
        {

            int age;
            String wordToLoop;
           
            do
            {
                Console.Clear();
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("Type 0. to exit");
                Console.WriteLine("Menyval 1: Ungdom eller pensionär");
                Console.WriteLine("Menyval 2: Upprepa tio gånger");
                Console.WriteLine("Menyval 3: Det tredje ordet");
                
                switch (Console.ReadLine()) 
                {
                    case "0":
                        Environment.Exit(1); //Avslutar programmet
                        break;
                    case "1":
                        Console.WriteLine("Ange ålder i siffror");
                        string ageStr = Console.ReadLine();
                        age = ValidateImput( ageStr);  //Kollar im inmatning är korrekt
                        
                        if ((age <= 5) && (age != 0))
                        {
                            Console.WriteLine("Barn under fem år går in gratis");
                            Console.ReadLine();
                            break;
                        }

                        if ((age <= 20) && (age >= 5))
                        {
                            Console.WriteLine("Ungdomspris: 80kr");
                            Console.ReadLine();
                            break;
                        }
                        if ((age >= 64)  && (age <= 99))
                        {
                            Console.WriteLine("Pensionärspris: 90kr");
                            Console.ReadLine();
                            break;
                        }
                        if (age >= 100)
                        {
                            Console.WriteLine("pensionärer över 100 går in gratis");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Standardpris: 120kr");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Console.WriteLine("Mata in ett ord");
                        wordToLoop = Console.ReadLine();
                        for(int i = 0; i <= 9; i++ )
                        {
                            Console.Write($"{ i + 1}. { wordToLoop }, ");                            
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Mata in en mening med minst 3 ord");
                        string wordsToSeparate = Console.ReadLine();
                        string[] wordList = wordsToSeparate.Split(" ",StringSplitOptions.RemoveEmptyEntries); //  StringSplitOptions.RemoveEmptyEntries tar bort alla extra mellanslag    

                        Console.WriteLine(wordList[2]);
                        Console.ReadLine();
                        break;
                    default:
                        bool hastaLaVista = false;
                        string stop = " " ;                       
                        do
                        {
                            Console.Beep();
                            Console.WriteLine("felaktig input");
                            Console.WriteLine("Type 9. to return to \"Huvudmeny\" 0 to exit");
                            stop = Console.ReadLine();
                            if (stop == "9")
                                hastaLaVista = true;
                            if(stop == "0")
                                Environment.Exit(1); //Avslutar programmet
                        } while (!hastaLaVista);                        
                        break;
                }
            } while ( true );
            
        }

        static int ValidateImput(string v)
        {
            int vInt = 0;
            do
            {
                bool isParsable = Int32.TryParse(v, out vInt);
                if (isParsable)
                {
                    Console.WriteLine(vInt);
                    return vInt;
                }
                else
                {
                    Console.WriteLine("felaktig input");
                    Console.WriteLine("Ange ålder i siffror");
                    string ageStr = Console.ReadLine();
                    ValidateImput(ageStr);                    
                    return 0;
                }
            } while (true);            
        }
    }
}
