using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3TobogganTrajectory
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Day 3 Toboggan Trajectory");
            var input = await GetInput();
            int numberOfTrees = Navigate(3, 1, input);
            Console.WriteLine($"Number of trees encountered: {numberOfTrees}");
            var numberOfTressPerRoute = NavigateRoutes(
                new RouteCoordinates[]
                {
                    new RouteCoordinates(1, 1),
                    new RouteCoordinates(3, 1),
                    new RouteCoordinates(5, 1),
                    new RouteCoordinates(7, 1),
                    new RouteCoordinates(1, 2)
                }, input);
            Console.WriteLine($"Number of trees encountered over all routes: {numberOfTressPerRoute.Sum()}");
            Int64 result = 1;
            foreach (var number in numberOfTressPerRoute)
            {
                result *= number;
            }
            Console.WriteLine($"Result: {result}");
            return 0;
        }


        private static IEnumerable<int> NavigateRoutes(IEnumerable<RouteCoordinates> routes, string[] input)
        {
            return routes.Select(r => Navigate(r.rightMove, r.downMove, input));
        }

        private static int Navigate(int rightMove, int downMove, string[] input)
        {
            var yPosition = downMove;
            var xPosition = rightMove;
            var numberOfTrees = 0;
            while (true)
            {
                var line = input[yPosition];
                if (xPosition > line.Length - 1)
                    xPosition -= (line.Length);

                if (line[xPosition] == '#')
                    numberOfTrees++;

                yPosition += downMove;
                xPosition += rightMove;

                if (yPosition > input.Length - 1)
                    return numberOfTrees;
            }
        }

        private static async Task<string[]> GetInput()
        {
            return await System.IO.File.ReadAllLinesAsync("Input.txt");
        }

        private class RouteCoordinates
        {
            internal int rightMove;
            internal int downMove;

            internal RouteCoordinates(int rightMove, int downMove)
            {
                this.rightMove = rightMove;
                this.downMove = downMove;
            }
        }
    }
}
