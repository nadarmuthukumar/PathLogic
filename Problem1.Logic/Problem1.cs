using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1.Logic
{
    public static class Problem1
    {
        static List<Tuple<string, string, int>> routesWithDistance = new List<Tuple<string, string, int>>();

        /// <summary>
        /// Constuctor of the class to load all constant values.
        /// Contstant values are nothing but the data points, methods in this class will give outputs basis these data points
        /// </summary>
        static Problem1()
        {
            routesWithDistance.Add(new Tuple<string, string, int>("A", "B", 5));
            routesWithDistance.Add(new Tuple<string, string, int>("B", "C", 4));
            routesWithDistance.Add(new Tuple<string, string, int>("C", "D", 8));
            routesWithDistance.Add(new Tuple<string, string, int>("D", "C", 8));
            routesWithDistance.Add(new Tuple<string, string, int>("D", "E", 6));
            routesWithDistance.Add(new Tuple<string, string, int>("A", "D", 5));
            routesWithDistance.Add(new Tuple<string, string, int>("C", "E", 2));
            routesWithDistance.Add(new Tuple<string, string, int>("E", "B", 3));
            routesWithDistance.Add(new Tuple<string, string, int>("A", "E", 7));
        }

        /// <summary>
        /// Give distance of the route
        /// </summary>
        /// <param name="route">A-B-C</param>
        /// <returns>The method returns an string.</returns>
        public static string GetDistance(string route)
        {
            int distance = 0;
            string[] routePoint = route.Split('-');

            if (routePoint.Length <= 1)
            {
                throw new ArgumentException("Invalid route data", route);
            }

            int i = 0;
            while (i < routePoint.Length - 1)
            {
                var result = routesWithDistance.FirstOrDefault(r => r.Item1 == routePoint[i] && r.Item2 == routePoint[i + 1]);
                if (result != null)
                {
                    distance += result.Item3;
                    i++;
                }
                else
                {
                    return "NO SUCH ROUTE";
                }
            }

            return distance.ToString();
        }

        public static string GetNumberOfRoutesWithExact(Tuple<string, string, int> route)
        {
            List<Tuple<string, int, int>> routes = GetAllPaths(route);
            return routes.Where(r => r.Item3 == route.Item3).ToList().Count.ToString();
        }

        private static List<Tuple<string, int, int>> GetAllPaths(Tuple<string, string, int> route)
        {
            string startPoint = route.Item1, endPoint = route.Item2;
            int stops = route.Item3;

            List<Tuple<string, int, int>> routes = new List<Tuple<string, int, int>>();
            List<Tuple<string, int, int>> temp1 = new List<Tuple<string, int, int>>();
            List<Tuple<string, int, int>> temp2 = new List<Tuple<string, int, int>>();
            int tempStops = 0;

            var result = routesWithDistance.Where(r => r.Item1 == startPoint).ToList();
            if (result != null)
            {
                tempStops += 1;
                foreach (var item in result)
                {
                    temp1.Add(new Tuple<string, int, int>(item.Item1 + "-" + item.Item2, item.Item3, 1));
                    routes.AddRange(temp1.Where(r => r.Item1.EndsWith(endPoint) && r.Item3 == tempStops).ToList());
                }

                while (temp1.Count != 0)
                {
                    tempStops += 1;
                    for (int i = 0; i < temp1.Count; i++)
                    {
                        string routeEndPoint = temp1[i].Item1.Split('-').Last();
                        var result1 = routesWithDistance.Where(r => r.Item1 == routeEndPoint).ToList();
                        if (result1 != null)
                        {
                            string t = temp1[i].Item1;
                            int t2 = temp1[i].Item2;
                            int t1 = temp1[i].Item3;
                            temp1[i] = new Tuple<string, int, int>(t + "-" + result1[0].Item2, t2 + result1[0].Item3, t1 + 1);

                            for (int j = 1; j < result1.Count; j++)
                            {
                                temp2.Add(new Tuple<string, int, int>(t + "-" + result1[j].Item2, t2 + result1[j].Item3, t1 + 1));
                            }
                        }
                    }
                    routes.AddRange(temp1.Where(r => r.Item1.EndsWith(endPoint) && r.Item3 == tempStops).ToList());
                    routes.AddRange(temp2.Where(r => r.Item1.EndsWith(endPoint) && r.Item3 == tempStops).ToList());
                    
                    temp1.AddRange(temp2.ToList());
                    temp2.Clear();

                    if (stops == tempStops)
                    {
                        break;
                    }
                }
            }

            return routes.ToList(); 
        }

        public static string GetNumberOfRoutesWithMaximum(Tuple<string, string, int> route)
        {
            List<Tuple<string, int, int>> routes = GetAllPaths(route);
            return routes.Where(r => r.Item3 <= route.Item3).ToList().Count.ToString();
        }

        public static string GetNumberOfRoutesWithDistance(Tuple<string, string, int> route)
        {
            List<Tuple<string, int, int>> routes = GetAllPaths(new Tuple<string, string, int>(route.Item1, route.Item2, 5));
            return routes.Where(r => r.Item3 < route.Item3).ToList().Count.ToString();
        }

        public static string GetShortestRouteLength(Tuple<string, string> route)
        {
            List<Tuple<string, int, int>> routes = GetAllPaths(new Tuple<string, string, int>(route.Item1, route.Item2, 5));
            return routes.Min(r => r.Item2).ToString();
        }
    }
}
