using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RegressionSuite
{
    public class GenericFunction
    {
        public static ArrayList GetIterations(string sIteration)
        {
            //ArrayList arrRange=null;
            int min=0, max=0, i=0, j=0;
            ArrayList arrIterations = new ArrayList();
            char[] spliter = new char[1];
            spliter[0] = ',';
            string[] arrTmp = sIteration.Split(spliter);

            for ( i = 0; i <= arrTmp.Length-1; i++)
            {
                spliter[0] = '-';
                string[] arrRange = arrTmp[i].Split(spliter);
                if (arrRange.Length-1 == 1)
                {
                    min = Convert.ToInt32 (arrRange[0]);
                    max = Convert.ToInt32(arrRange[1]);

                    if (min > max)
                    {
                        SwapArgs(ref min, ref max);

                    }

                    for (j = min; j <= max; j++)
                    {
                        arrIterations.Add(j);
                    }
                }
                else
                {
                    arrIterations.Add(Convert.ToInt32 (arrTmp[i]));
                }
                arrRange = null;
            }

            return arrIterations;

            }

        private static void SwapArgs(ref int min, ref int max)
        {
            int temp;
            temp = min;
            min = max;
            max = temp;            
        }

        public static string GetString(ArrayList lst)
        {
            string s="";
            ArrayList a;


            foreach (int v in lst)
            {
                s = s + v + ",";
            }
            s = s.Substring(0, s.Length - 1);
            return s;
        }
      
    }
}
