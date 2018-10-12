using System;
using System.Text;

namespace FormalLanguages
{
    internal class GrammarBuilder 
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var fileGrammar = GetFileGrammar();
          
            ShowRules();
            Console.WriteLine("Exemplu citit din fișier: " + fileGrammar);
            BuildGrammar(fileGrammar);

            Console.ReadKey();
        }

        private static void ShowRules()
        {
            Console.WriteLine("1. Primul simbol (S) din prima producție reprezintă axioma (simbolul de start)");
            Console.WriteLine("2. Simbolul de separare dintre producții este $");
            Console.WriteLine("3. Simbolurile neterminale sunt scrise cu litere mari");
            Console.WriteLine("4. Simbolurile terminale sunt scrise cu litere mici");
            Console.WriteLine("5. Secvența vidă va fi @");
            Console.WriteLine("6. Simbolul care marchează sfârșitul gramaticii este &");
            Console.WriteLine("-----------------------------------------------------");
        }

        private static string GetFileGrammar()
        {
            return System.IO.File.ReadAllText(@"..\..\ProductionExample.txt");
        }

        private static void BuildGrammar(string input)
        {
            var terminal = "";
            var nonTerminal = "";
            var charArray = input.ToCharArray();

            Console.Write($"{charArray[0]} --> ");
            for (var i = 1; i < charArray.Length; i++)
            {
                if (char.IsUpper(charArray[i]))
                {
                    nonTerminal += charArray[i] + ", ";
                    Console.Write(charArray[i]);
                    continue;
                }

                if (char.IsLower(charArray[i]))
                {
                    terminal += charArray[i] + ", ";
                    Console.Write(charArray[i]);
                    continue;
                }

                switch (charArray[i])
                {
                    case '$':
                        Console.Write($"\n{charArray[++i]} --> ");
                        continue;
                    case '@':
                        terminal += "lambda, ";
                        Console.Write("lambda");
                        continue;
                    case '&':
                        Console.WriteLine("\n-----------------------------------------------------");
                        break;
                    default:
                        Console.Write(charArray[i]);
                        break;
                }
            }
        }
    }
}
