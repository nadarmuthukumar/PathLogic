using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "", result = "";
            Tuple<string, string, int> input1 = null;
            Tuple<string, string> input2 = null;

            Console.WriteLine("~~~~Get distance of the route~~~~");
            Console.WriteLine("");

            input = "A-E-B-C-D";
            result = Logic.Problem1.GetDistance(input);
            Console.WriteLine($"Input is {input}");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            input = "A-B-C";
            result = Logic.Problem1.GetDistance(input);
            Console.WriteLine($"Input is {input}");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            input = "A-E-D";
            result = Logic.Problem1.GetDistance(input);
            Console.WriteLine($"Input is {input}");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            Console.WriteLine("~~~~Get number of routes with exacty condition~~~~");
            Console.WriteLine("");

            input1 = new Tuple<string, string, int>("A", "C", 4);
            result = Logic.Problem1.GetNumberOfRoutesWithExact(input1);
            Console.WriteLine($"Input is start-point {input1.Item1} end-point {input1.Item2} exact stop {input1.Item3} ");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            input1 = new Tuple<string, string, int>("C", "C", 3);
            result = Logic.Problem1.GetNumberOfRoutesWithMaximum(input1);
            Console.WriteLine($"Input is start-point {input1.Item1} end-point {input1.Item2} maximum stop {input1.Item3} ");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            Console.WriteLine("~~~~Get shortest routes length~~~~");
            Console.WriteLine("");

            input2 = new Tuple<string, string>("A", "C");
            result = Logic.Problem1.GetShortestRouteLength(input2);
            Console.WriteLine($"Input is start-point {input2.Item1} end-point {input2.Item2}");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            input2 = new Tuple<string, string>("C", "C");
            result = Logic.Problem1.GetShortestRouteLength(input2);
            Console.WriteLine($"Input is start-point {input2.Item1} end-point {input2.Item2}");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            Console.WriteLine("~~~~Get routes with distance~~~~");
            Console.WriteLine("");

            input1 = new Tuple<string, string, int>("C", "C", 30);
            result = Logic.Problem1.GetNumberOfRoutesWithDistance(input1);
            Console.WriteLine($"Input is start-point {input1.Item1} end-point {input1.Item2} distance {input1.Item3}");
            Console.WriteLine($"Output is {result}");
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
