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
                Console.WriteLine("1. Slicing a word or a sentence      4.RPG Game(Classes and Objects)");
                Console.WriteLine("2. Array Tutorial Example            ");
                Console.WriteLine("3. Calculator                        ");
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
                        
                        ConsoleKeyInfo userFunctionChoice;
                        List<string> exampleArray = new List<string>();
                        
                        
                        CalculatorStarts:
                        Console.Clear();
                        
                        if (!firstNum)  // when firstNum is false
                        {
                            Console.WriteLine("Type the first number");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Example: ");
                            string userChoice = Console.ReadLine();
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
                            Console.WriteLine("9. Remove Last Action");
                            
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
                            case ConsoleKey.D9:
                                bool isOperator = false;
                                string[] operatorsArray = {"+", "-", "*", "/"};
                                int ph = exampleArray.Count;
                                string findOperator = string.Empty;
            
                                List<string> operators = new List<string>(operatorsArray);
                                while (!isOperator) //this while loop ends when it finds any operator
                                {
                                    if (ph == 0) goto CalculatorStarts;
                                    // when you got only starting number and want to remove last action, it will automatically go to start
                                    findOperator = exampleArray[ph - 1]; //ph - placeholder
                                    foreach (string i in operators)
                                    {
                                        if (findOperator == i)  //if it is one of the operators, findOperator will be that operator and ends the loop
                                        {
                                            findOperator = i;
                                            isOperator = true;
                                        }
                                    }
                                    ph--;
                                }

                                double numToRemove = Convert.ToDouble(exampleArray[^1]); // last index in list
                                
                                result = findOperator switch
                                {
                                    "+" => result - numToRemove,
                                    "-" => result + numToRemove,
                                    "*" => result / numToRemove,
                                    "/" => result * numToRemove,
                                    _ => 0
                                };

                                exampleArray.RemoveAt(exampleArray.Count-1);
                                exampleArray.RemoveAt(exampleArray.Count-1);
                                goto CalculatorStarts;
                            
                            default:
                                Console.WriteLine("Invalid Input..");
                                Thread.Sleep(2000);
                                goto CalculatorStarts;
                        }

                        double userInputNumber;
                        try
                        {
                            userInputNumber = Convert.ToDouble(Console.ReadLine());
                        }
                        catch(FormatException e)  // catches when user will type anything that cannot be converted to double variable
                        {
                            Console.WriteLine(e.Message);
                            Thread.Sleep(2000);
                            exampleArray.RemoveAt(exampleArray.Count-1);
                            // need to remove last index in array because it causes operator duplication like 50+++++++5 = 55
                            goto CalculatorStarts;
                        }
                        
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
                        
                    case ConsoleKey.D4:
                        ClassAndObject();
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
                    count = Convert.ToInt32(countInput);
                    break;
                }
                catch (FormatException e) // if entered value cannot be parsed to int, it throws FormatException
                {
                    Console.WriteLine(e.Message);
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

        private static void ClassAndObject()
        {
            Console.Clear();

            PlayerInfo P1 = new PlayerInfo();

            Console.Write("Welcome to Rocket Propelled Grenade RPG - by wouris" +
                              "\nYour name: ");
            P1.PlayerName = Console.ReadLine();
            
            Console.Clear();
            Console.WriteLine($"Welcome {P1.PlayerName}, to Rocket Propelled Grenade RPG! - by wouris");
            Console.WriteLine("Choose a class:");
            Console.WriteLine("1. Knight        2.Mage      3.Assassin" +
                              "\n   DMG: 24       DMG: 35       DMG: 13" +
                              "\n   HP: 120       HP: 65        HP: 80");
            ConsoleKeyInfo userClass = Console.ReadKey();
            switch (userClass.Key)
            {
                case ConsoleKey.D1:
                    P1.PlayerClass = "Knight";
                    P1.PlayerHP = 120;
                    P1.PlayerDMG = 24;
                    break;
                case ConsoleKey.D2:
                    P1.PlayerClass = "Mage";
                    P1.PlayerHP = 65;
                    P1.PlayerDMG = 35;
                    break;
                case ConsoleKey.D3:
                    P1.PlayerClass = "Assassin";
                    P1.PlayerHP = 80;
                    P1.PlayerDMG = 13;
                    break;
                    
            }
            
            int damageTaken = 0;
            while (P1.PlayerHP >= 1) // game loop until player dies
            {
                Console.Clear();
                Console.WriteLine(P1.PlayerName + 
                                  " | Class: " + P1.PlayerClass + 
                                  " | HP: " + (P1.PlayerHP)+
                                  " | Damage: " + P1.PlayerDMG);
            

                Console.WriteLine("\nWhat do you want to choose");
                Console.WriteLine("1. Self Damage (-20 HP)");
                Console.WriteLine("2. Change class");

                ConsoleKeyInfo userChange = Console.ReadKey();
                switch (userChange.Key)
                {
                    case ConsoleKey.D1:
                        damageTaken += 20;
                        P1.PlayerHP -= 20;
                        break;
                    case ConsoleKey.D2:
                        ConsoleKeyInfo userClassChange;
                        Console.Clear();
                        Console.WriteLine("Choose a class: \n1.Knight\n2.Mage\n3.Assassin");
                        userClassChange = Console.ReadKey();
                        switch (userClassChange.Key)
                        {
                            case ConsoleKey.D1:
                                P1.PlayerClass = "Knight";
                                if (P1.PlayerHP <= 120)
                                    P1.PlayerHP = Convert.ToInt32(120 * (double)P1.PlayerHP / 120);
                                P1.PlayerDMG = 24;
                                break;
                            case ConsoleKey.D2:
                                P1.PlayerClass = "Mage";
                                P1.PlayerHP = Convert.ToInt32(65 * (double)P1.PlayerHP / 65);
                                P1.PlayerDMG = 35;
                                break;
                            case ConsoleKey.D3:
                                P1.PlayerClass = "Assassin";
                                P1.PlayerHP = Convert.ToInt32(80 * (double)P1.PlayerHP / 80);
                                P1.PlayerDMG = 13;
                                break;
                        }
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("You Died!" +
                              "\nYour score: 0");
            Console.ReadKey();
        }
    }
}
