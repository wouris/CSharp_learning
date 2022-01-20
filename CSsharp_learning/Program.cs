﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace CSsharp_learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type any sentence or a word:");
            var uInput = Console.ReadLine();
            var typeOfUInput = "word";
            if (uInput.Contains(" "))
            {
                typeOfUInput = "sentence";
            }
            Console.WriteLine($"The {typeOfUInput} \"{uInput}\" contains {uInput.Length} letters in it!");

            int count = 0;
            while (true)
            {
                Console.WriteLine($"After how many letters do you want to split this {typeOfUInput}");
                var count_input = Console.ReadLine();

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

            String uInputWithoutSpaces = String.Empty;
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

            EndOfApplication: ;

        }
    }
}
