using System;
using System.Text;

namespace FormalLanguages
{
    internal class GrammarBuilder 
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var grammar = new GrammarBuilder();
            grammar.BuildGrammar("");

            ShowRules();

            Console.WriteLine("Exemplu citit din fișier: " + GetFileGrammar());
            Console.ReadKey();
        }

        private string BuildGrammar(string input)
        {
            return "";
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
    }
}
