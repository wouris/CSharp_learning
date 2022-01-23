using System;
using System.Collections.Generic;
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
                        double result = 0;
                        bool firstNum = false;
                        string userChoice = "";
                        ConsoleKeyInfo userFunctionChoice;
                        List<string> exampleArray = new List<string>();
                        
                        
                        CalculatorStarts: ;
                        Console.Clear();
                        
                        if (firstNum == false)
                        {
                            Console.WriteLine("Type the first number");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Example: ");
                            userChoice = Console.ReadLine();
                            exampleArray.Add(userChoice);
                            result = Convert.ToDouble(userChoice);
                            firstNum = true;
                            goto CalculatorStarts;
                        }
                        else
                        {
                            Console.WriteLine("1. +");
                            Console.WriteLine("2. -");
                            Console.WriteLine("3. *");
                            Console.WriteLine("4. /");
                            
                            string example = "";
                            foreach (string i in exampleArray)
                                example += i;
                            
                            Console.WriteLine("Example: " + example + " = "+ result);    
                            userFunctionChoice = Console.ReadKey();
                            
                            if (userFunctionChoice.Key == ConsoleKey.Q)
                            {
                                Environment.Exit(1);
                            }
                        }
                        
                        Console.Write("\b");
                        switch (userFunctionChoice.Key)
                        {
                            case ConsoleKey.D1:
                                Console.Write(result+"+");
                                exampleArray.Add("+");
                                break;
                            case ConsoleKey.D2:
                                Console.Write(result+"-");
                                exampleArray.Add("-");
                                break;
                            case ConsoleKey.D3:
                                Console.Write(result+"*");
                                exampleArray.Add("*");
                                break;
                            case ConsoleKey.D4:
                                Console.Write(result+"/");
                                exampleArray.Add("/");
                                break;
                            default:
                                Console.WriteLine("Invalid Input..");
                                Thread.Sleep(2000);
                                goto CalculatorStarts;
                        }
                        double userInputNumber = Convert.ToDouble(Console.ReadLine());
                        exampleArray.Add(Convert.ToString(userInputNumber));

                        result = userFunctionChoice.Key switch
                        {
                            ConsoleKey.D1 => Calculator(userInputNumber, result, "+"),
                            ConsoleKey.D2 => Calculator(userInputNumber, result, "-"),
                            ConsoleKey.D3 => Calculator(userInputNumber, result, "*"),
                            ConsoleKey.D4 => Calculator(userInputNumber, result, "/"),
                            _ => 0
                        };

                        goto CalculatorStarts;
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

        private static double Calculator(double value,double result, string operatorType)
        {
            result = operatorType switch
            {
                "+" => result + value,
                "-" => result - value,
                "/" => result / value,
                "*" => result * value,
                _ => 0
            };

            return result;
        }
    }
}
