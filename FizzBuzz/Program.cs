using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static List<Tuple<int, string>> GetOptions()
        {
            var options = new List<Tuple<int, string>>();
            {
                options.Add(Tuple.Create(3, "Fizz"));
                options.Add(Tuple.Create(5, "Buzz"));
                options.Add(Tuple.Create(7, "Bang"));
                options.Add(Tuple.Create(11, "Bong"));
                options.Add(Tuple.Create(13, "Fezz"));
                options.Add(Tuple.Create(17, "_"));
            }
            ;

            var insertAt = 0;
            for (var i = 0; i < options.Count; i++)
            {
                var option = options[i];

                if (option.Item2.StartsWith("B"))
                {
                    insertAt = i;
                }

                if (option.Item2 != "Fezz")
                {
                    continue;
                }

                options.RemoveAt(i);
                options.Insert(insertAt, option);
            }

            return options;
        }

        private static bool CheckSpecialCase(Tuple<int, string> option, List<string> messages)
        {
            var breakLoop = false;
            if (option.Item2 == "bong")
            {
                messages.Clear();
                messages.Add(option.Item2);
                breakLoop = true;
            }

            if (option.Item1 == 17)
            {
                messages.Reverse();
            }

            return breakLoop;
        }

        private static void RunFizzBuzz(int n, List<Tuple<int, string>> options)
        {
            for (var i = 1; i <= n; i++)
            {
                var messages = new List<string>();
                var matched = false;
                foreach (var option in options)
                {
                    if (i % option.Item1 != 0)
                    {
                        continue;
                    }

                    if (option.Item2 != "_")
                    {
                        matched = true;
                        messages.Add(option.Item2);
                    }

                    if (CheckSpecialCase(option, messages))
                    {
                        break;
                    }
                }

                if (!matched)
                {
                    messages.Add(i.ToString());
                }

                Console.WriteLine(string.Join("", messages));
            }
        }

        static void Main(string[] cliOptions)
        {
            Console.Write("Enter a maximum number >>> ");
            var line = Console.ReadLine();

            if (line is null)
            {
                Console.WriteLine("You must specify a input.");
                return;
            }

            var options = GetOptions();
            var validOptions = new List<Tuple<int, string>>();

            if (cliOptions.Length > 0)
            {
                var allowedOptions = cliOptions.ToArray();

                for (var i = 0; i < options.Count; i++)
                {
                    var option = options[i];

                    if (allowedOptions.Contains(option.Item1.ToString()))
                    {
                        validOptions.Add(option);
                    }
                }
            }

            RunFizzBuzz(int.Parse(line), validOptions);
        }
    }
}