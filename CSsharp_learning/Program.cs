using System;
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
                Console.WriteLine("3. Calculator");
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
                    case ConsoleKey.D3:
                        CalculatorStarts: ;
                        Console.Clear();
                        Console.WriteLine("Choose a function (3 inputs, For example: 2 10 4, returns 6 because 10-4 is 6)");
                        Console.WriteLine("1. Plus");
                        Console.WriteLine("2. Minus");
                        Console.WriteLine("3. Times");
                        Console.WriteLine("4. Division");
                        string userChoice = Console.ReadLine();

                        string[] userChoiceWithoutSpace = userChoice.Split(' ');
                        double calcNum1 = Convert.ToDouble(userChoiceWithoutSpace[1]);
                        double calcNum2 = Convert.ToDouble(userChoiceWithoutSpace[2]);
                        
                        // int result = 0;
                        // switch (userChoiceWithoutSpace[0])
                        // {
                        //     case "1":
                        //         result = Calculator(calcNum, "+");
                        //         break;
                        //     case "2":
                        //         result = Calculator(calcNum, "-");
                        //         break;
                        //     case "3":
                        //         result = Calculator(calcNum, "/");
                        //         break;
                        //     case "4":
                        //         result = Calculator(calcNum, "*");
                        //         break;
                        //     default:
                        //         result = 1;
                        //         break;
                        // }
                        
                        double result = userChoiceWithoutSpace[0] switch
                        {
                            "1" => Calculator(calcNum1,calcNum2, "+"),
                            "2" => Calculator(calcNum1,calcNum2, "-"),
                            "3" => Calculator(calcNum1,calcNum2, "*"),
                            "4" => Calculator(calcNum1,calcNum2, "/"),
                            _ => 0
                        };

                        Console.WriteLine("Result: " + result);
                        Console.WriteLine("'A' - Calculator\t'Any' - Menu\t'Q' - Exit");
                        input = Console.ReadKey();
                        if (input.Key == ConsoleKey.A)
                        {
                            goto CalculatorStarts;
                        }
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

            int count;
            while (true)
            {
                Console.WriteLine($"After how many letters do you want to split this {typeOfUInput}");
                string countInput = Console.ReadLine();

                try // need to check if entered value can be a number
                {
                    count = int.Parse(countInput);
                    break;
                }
                catch (FormatException) // if entered value cannot be parsed to int, it throws FormatException
                {
                    Console.WriteLine("Invalid input...");
                    Thread.Sleep(1000);
                }

            }

            string uInputWithoutSpaces = string.Empty;
            foreach (var ph in uInput)
            {
                if (ph == ' ')
                    continue;
                uInputWithoutSpaces += ph;
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

        private static double Calculator(double value1,double value2, string operatorType)
        {
            double result = operatorType switch
            {
                "+" => value1 + value2,
                "-" => value1 - value2,
                "/" => value1 / value2,
                "*" => value1 * value2,
                _ => 0
            };

            return result;
        }
    }
}
