using System;
using System.Collections.Generic;

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

        private static bool CheckSpecialCase(int value, Tuple<int, string> option, List<string> messages)
        {
            var breakLoop = false;
            if (option.Item2 == "bong")
            {
                messages.Clear();
                messages.Add(option.Item2);
                breakLoop = true;
            }

            if (value % 17 == 0)
            {
                messages.Reverse();
            }

            return breakLoop;
        }

        static void RunFizzBuzz(int n)
        {
            var options = GetOptions();

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

                    matched = true;
                    messages.Add(option.Item2);

                    if (CheckSpecialCase(i, option, messages))
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
        
        static void Main(string[] _)
        {
            
            Console.Write("Enter a maximum number >>> ");
            var line = Console.ReadLine();
            
            if (line is null)
            {
                Console.WriteLine("You must specify a input.");
                return;
            }
            
            RunFizzBuzz(int.Parse(line));
        }
    }
}