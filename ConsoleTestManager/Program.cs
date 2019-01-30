using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegressionSuite;
namespace ConsoleTestManager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmokeTests test1 = new SmokeTests();
                test1.MainSequentialMethod();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
