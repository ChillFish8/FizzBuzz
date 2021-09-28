using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] _)
        {
            Tuple<int, string>[] options =
            {
                Tuple.Create(3, "Fizz"),
                Tuple.Create(5, "Buzz"),
                Tuple.Create(7, "Bang")
            };

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