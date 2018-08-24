using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Problem1.Test
{
    /*
        1. The distance of the route A-B-C. 
        2. The distance of the route A-E-B-C-D.
        3. The distance of the route A-E-D.

        4. The number of trips starting at C and ending at C with a maximum of 3 stops.In the sample data below, there are two such trips: C-D-C(2 stops) and C-E-B-C(3 stops).
        5. The number of trips starting at A and ending at C with exactly 4 stops.In the sample data below, there are three such trips: A to C(via B, C, D); A to C(via D, C, D); and A to C(via D, E, B).
            
        6. The length of the shortest route(in terms of distance to travel) from A to C.
        7. The length of the shortest route (in terms of distance to travel) from B to B.
        
        8. The number of different routes from C to C with a distance of less than 30. In the sample data, the trips are: CDC, CEBC, CEBCDC, CDCEBC, CDEBC, CEBCEBC, CEBCEBCEBC.
    */

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_WhenABC_Return9()
        {
            string input = "A-B-C";
            string output = Logic.Problem1.GetDistance(input);
            Assert.AreEqual("9", output);
        }

        [TestMethod]
        public void Test_WhenAEBCD_Return22()
        {
            string input = "A-E-B-C-D";
            string output = Logic.Problem1.GetDistance(input);
            Assert.AreEqual("22", output);
        }

        [TestMethod]
        public void Test_WhenAED_ReturnNOSUCHROUTE()
        {
            string input = "A-E-D";
            string output = Logic.Problem1.GetDistance(input);
            Assert.AreEqual("NO SUCH ROUTE", output);
        }

        [TestMethod]
        public void Test_WhenA_ReturnArgumentException()
        {
            string input = "A";
            try
            {
                string output = Logic.Problem1.GetDistance(input);
                Assert.Fail("Argument exception is expected.");
            }
            catch(ArgumentException ex)
            {
                if (ex.ParamName != input)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void Test_WhenCCWith3Stops_Return2()
        {
            Tuple<string, string, int> input = new Tuple<string, string, int>("C", "C", 3);
            string output = Logic.Problem1.GetNumberOfRoutesWithMaximum(input);
            Assert.AreEqual("2", output);
        }

        [TestMethod]
        public void Test_WhenACWith4Stops_Return3()
        {
            Tuple<string, string, int> input = new Tuple<string, string, int>("A", "C", 4);
            string output = Logic.Problem1.GetNumberOfRoutesWithExact(input);
            Assert.AreEqual("3", output);
        }

        [TestMethod]
        public void Test_Shortest_RouteWhenAC_Return9()
        {
            Tuple<string, string> input = new Tuple<string, string>("A", "C");
            string output = Logic.Problem1.GetShortestRouteLength(input);
            Assert.AreEqual("9", output);
        }

        [TestMethod]
        public void Test_Shortest_RouteWhenBB_Return9()
        {
            Tuple<string, string> input = new Tuple<string, string>("B", "B");
            string output = Logic.Problem1.GetShortestRouteLength(input);
            Assert.AreEqual("9", output);
        }

        [TestMethod]
        public void TestDifferentRoutes_WhenRouteCC_Return7()
        {
            Tuple<string, string, int> input = new Tuple<string, string, int>("C", "C", 30);
            string output = Logic.Problem1.GetNumberOfRoutesWithDistance(input);
            Assert.AreEqual("7", output);
        }
    }
}
