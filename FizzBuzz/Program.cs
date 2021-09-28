using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        
        
        static List<Tuple<int, string>> GetOptions()
        {
            List<Tuple<int, string>> options = new List<Tuple<int, string>>();
            {
                options.Add(Tuple.Create(3, "Fizz"));
                options.Add(Tuple.Create(5, "Buzz"));
                options.Add(Tuple.Create(7, "Bang"));
                options.Add(Tuple.Create(11, "Bong"));
                options.Add(Tuple.Create(13, "Fezz"));
            };

            var insertAt = 0;
            for (int i = 0; i < options.Count; i++)
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

        static bool CheckSpecialCase(Tuple<int, string> option, List<string> messages)
        {
            if (option.Item2 == "bong")
            {
                messages.Clear();
                messages.Add(option.Item2);
                return true;
            }
            
            if (option.Item1 == 17)
            {
                messages.Reverse();
                return false;
            }

            return false;
        }

        static void Main(string[] _)
        {
            var options = GetOptions();

            for (var i = 1; i <= 100; i++)
            {
                var matched = false;
                foreach (var (value, msg) in options)
                {
                    if (i % value == 0)
                    {
                        matched = true;
                        Console.Write(msg);
                    }
                }

                if (!matched)
                {
                    Console.Write(i);
                }
                
                Console.Write("\n");
            }
                
        }
    }
}