using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace CSsharp_learning
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo input;
            do
            {
                Console.Clear();
                Console.WriteLine("Select a program you want to run:");
                Console.WriteLine();    //insert [enter]
                Console.WriteLine("1. Slicing a word or a sentence");
                Console.WriteLine("2. Array Tutorial Example");
                Console.WriteLine();    //insert [enter]
                Console.WriteLine("Press 'q' to exit.");
                Console.Write(">> ");
                input = Console.ReadKey();
                    
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        SlicingWord();
                        break;
                    case ConsoleKey.D2:
                        ArrayTutorial();
                        break;
                }
            } while (input.Key != ConsoleKey.Q);

            Console.Write("\nGoodbye!");

        }

        private static void SlicingWord()
        {
            Console.Clear();
            Console.WriteLine("Type any sentence or a word:");
            string uInput = Console.ReadLine();
            string typeOfUInput = "word";
            if (uInput.Contains(" "))
            {
                typeOfUInput = "sentence";
            }
            Console.WriteLine($"The {typeOfUInput} \"{uInput}\" consists of {uInput.Length} letters!");

            int count = 0;
            while (true)
            {
                Console.WriteLine($"After how many letters do you want to split this {typeOfUInput}");
                string count_input = Console.ReadLine();

                try // need to check if entered value can be a number
                {
                    count = int.Parse(count_input);
                    break;
                }
                catch (FormatException) // if entered value cannot be parsed to int, it throws FormatException
                {
                    Console.WriteLine("Invalid input...");
                    Thread.Sleep(1000);
                }

            }

            string uInputWithoutSpaces = string.Empty;
            for (int ph = 0; ph < uInput.Length; ph++)
            {
                if (uInput[ph] == ' ')
                    continue;
                uInputWithoutSpaces += uInput[ph];
            }
            
            for (int i = 0; i <= uInputWithoutSpaces.Length; i += count)
            {
                for (int v = i; v < (count+i); v++)
                {
                    if (v == uInputWithoutSpaces.Length)
                        goto EndOfApplication;
                    Console.Write(uInputWithoutSpaces[v]);
                }
                Console.WriteLine();
            }


            EndOfApplication: 
            Console.ReadKey();
            Console.Clear();
        }

        private static void ArrayTutorial()
        {
            Console.Clear();
            Console.WriteLine("Welcome to array tutorial example!");
            int[] array = {23, 2, 199, 4818};
            string[] stringArray = new string[10]; //you need to specify empty arrays
            stringArray[0] = "Penaze";
            stringArray[1] = "Noaco";
            
            int i = 0;
            while (stringArray[i] != null)
            {
                Console.WriteLine($"This is {i+1}. element from string  " + stringArray[i]);
                i++;
            }

            Console.ReadKey();
        }
    }
}
