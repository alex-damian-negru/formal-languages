using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FormalLanguages
{
    internal class GrammarBuilder
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ShowRules();

            while (true)
            {
                var input = GetInput();
                if (input == "3") return;
                BuildGrammar(input);
                Console.WriteLine("Doriți o altă opțiune? (1, 2, 3)");
            }
        }

        private static void ShowRules() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Primul simbol din prima producție reprezintă axioma (simbolul de start)");
            Console.WriteLine("2. Simbolul de separare dintre producții este $");
            Console.WriteLine("3. Simbolurile neterminale sunt scrise cu litere mari");
            Console.WriteLine("4. Simbolurile terminale sunt scrise cu litere mici");
            Console.WriteLine("5. Secvența vidă va fi @");
            Console.WriteLine("6. Simbolul care marchează sfârșitul gramaticii este &");
            AddLine();
            Console.WriteLine("Selectați opțiunea: ");
            Console.WriteLine("1. Citire de la tastatură");
            Console.WriteLine("2. Citire din fișier");
            Console.WriteLine("3. Ieșire");
            AddLine();
        }

        private static string GetInput()
        {
            var choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Opțiunile permise sunt 1, 2, sau 3.");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    Console.Write("Input: ");
                    var input = Console.ReadLine();

                    while (!input.StartsWith("S"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Primul simbol trebuie să fie întotdeauna 'S'");
                        Console.ResetColor();
                        Console.Write("Reintroduceți: ");
                        input = Console.ReadLine();
                    }

                    while (!input.EndsWith("&"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Simbolul care marchează sfârșitul gramaticii trebuie să fie '&'");
                        Console.ResetColor();
                        Console.Write("Reintroduceți: ");
                        input = Console.ReadLine();
                    }

                    return input;

                case "2":
                    var fileInput = File.ReadAllText("./ProductionExample.txt");
                    Console.WriteLine("Input din fișier: " + fileInput);
                    return fileInput;

                case "3":
                    return "3";

                default:
                    return "3";
            }
        }

        private static void BuildGrammar(string input)
        {
            var terminal = new HashSet<char>();
            var nonTerminal = new HashSet<char>();
            var charArray = input.ToCharArray();

            Console.Write($"{charArray[0]} --> ");
            for (var i = 1; i < charArray.Length; i++)
            {
                if (char.IsUpper(charArray[i]))
                {
                    nonTerminal.Add(charArray[i]);
                    Console.Write(charArray[i]);
                    continue;
                }

                if (char.IsLower(charArray[i]))
                {
                    terminal.Add(charArray[i]);
                    Console.Write(charArray[i]);
                    continue;
                }

                switch (charArray[i])
                {
                    case '$':
                        Console.Write($"; {charArray[++i]} --> ");
                        nonTerminal.Add(charArray[i]);
                        continue;
                    case '@':
                        terminal.Add('λ');
                        Console.Write("λ");
                        continue;
                    case '&':
                        Console.WriteLine();
                        break;
                    default:
                        Console.Write(charArray[i]);
                        break;
                }
            }

            PrintList(nonTerminal, "V_N");
            PrintList(terminal, "V_T");
            AddLine();
        }

        private static void PrintList(IEnumerable<char> list, string type)
        {
            Console.Write($"{type} = {{");
            foreach (var entry in list)
                Console.Write($"{entry}, ");
            Console.WriteLine("\b\b}");
        }

        private static void AddLine()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------");
            Console.ResetColor();
        }
    }
}