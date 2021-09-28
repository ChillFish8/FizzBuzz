using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] cliOptions)
        {
            Console.Write("Enter a maximum number >>> ");
            var line = Console.ReadLine();

            if (line is null)
            {
                Console.WriteLine("You must specify a input.");
                return;
            }

            var fizzer = new FizzBuzz(int.Parse(line), cliOptions);
            
            foreach (var value in fizzer)
                Console.WriteLine(value);
        }
    }

    class FizzBuzz: IEnumerable
    {
        private int _n;
        private int _start;
        private readonly List<Tuple<int, string>> _options;

        public FizzBuzz(int n, string[] cliOptions)
        {
            var options = GetOptions();
            var validOptions = new List<Tuple<int, string>>();

            if (cliOptions.Length > 0)
            {
                var allowedOptions = cliOptions.ToArray();

                var collection = options
                    .Where(option => allowedOptions.Contains(option.Item1.ToString()));
                validOptions.AddRange(collection);
            }

            _n = n;
            _start = 1;
            _options = validOptions;
        }
        
        public IEnumerator GetEnumerator()
        {
            while (_start <= _n)
            {
                yield return RunFizzBuzz(_start);
                _start++;
            }
        }
        
        private static IEnumerable<Tuple<int, string>> GetOptions()
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
                    insertAt = i;

                if (option.Item2 != "Fezz")
                    continue;

                options.RemoveAt(i);
                options.Insert(insertAt, option);
            }

            return options;
        }

        private string RunFizzBuzz(int i)
        {
            var messages = new List<string>();
            var matched = false;
            foreach (var option in _options
                .Where(option => i % option.Item1 == 0))
            {
                if (option.Item2 != "_")
                {
                    matched = true;
                    messages.Add(option.Item2);
                }

                if (CheckSpecialCase(option, messages))
                    break;
            }

            if (!matched)
                messages.Add(i.ToString());

            return string.Join("", messages);
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
                messages.Reverse();

            return breakLoop;
        }
    }
}