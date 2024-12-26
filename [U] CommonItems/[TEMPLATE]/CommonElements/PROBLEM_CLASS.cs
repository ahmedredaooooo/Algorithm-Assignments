using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class PROBLEM_CLASS
    {
        #region YOUR CODE IS HERE 

        enum SOLUTION_TYPE { NAIVE, EFFICIENT };
        static SOLUTION_TYPE solType = SOLUTION_TYPE.EFFICIENT;

        //Your Code is Here:
        //==================
        /// <summary>
        /// Find common elements between the given arrays (if any) 
        /// If not found, return an empty array (i.e. new int[] { })
        /// </summary>
        /// <param name="arr1">1st array </param>
        /// <param name="arr2">2nd array </param>
        /// <returns>array of common element (if any) or empty array if no common elements. </returns>
        static public int[] RequiredFuntion(int[] arr1, int[] arr2)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int N = arr1.Length, M = arr2.Length;
            List<int> l = new List<int>();
            if (N < M)
            {
                Array.Sort<int>(arr1);
                for (int i = 0, s, e; i < M; i++)
                {
                    s = 0;
                    e = N - 1;
                    int t = arr2[i];
                    while (s <= e)
                    {
                        int m = s + e >> 1;
                        if (arr1[m] == t)
                        {
                            l.Add(t);
                            break;
                        }
                        else if (t < arr1[m])
                            e = m - 1;
                        else
                            s = m + 1;
                    }
                }
            }
            else
            {
                Array.Sort<int>(arr2);
                for (int i = 0, s, e; i < N; i++)
                {
                    s = 0;
                    e = M - 1;
                    int t = arr1[i];
                    while (s <= e)
                    {
                        int m = s + e >> 1;
                        if (arr2[m] == t)
                        {
                            l.Add(t);
                            break;
                        }
                        else if (t < arr2[m])
                            e = m - 1;
                        else
                            s = m + 1;
                    }
                }
            }
            return l.ToArray();
        }


        #endregion
    }
}
