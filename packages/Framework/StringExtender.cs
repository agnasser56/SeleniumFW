using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public static class StringExtender
    {
        public static int CompareLevenshtein(this string A, string B)
        { return A.CompareLevenshtein(B, false); }

        public static int CompareLevenshtein(this string A, string B, bool CaseSensitive)
        {
            int LA = A.Length;
            int LB = B.Length;
            if (LA == 0)
                return LB;
            else if (LB == 0)
                return LA;
            else
            {
                string A1 = CaseSensitive ? A : A.ToUpperInvariant();
                string B1 = CaseSensitive ? B : B.ToUpperInvariant();
                int[,] D = new int[LA + 1, LB + 1];
                for (int i = 0; i <= LA; i++)
                    D[i, 0] = i;
                for (int i = 0; i <= LB; i++)
                    D[0, i] = i;
                for (int i = 1; i <= LA; i++)
                {
                    char AI = A1[i - 1];
                    for (int j = 1; j <= LB; j++)
                    {
                        char BJ = B1[j - 1];
                        int cost = (AI == BJ ? 0 : 1);
                        D[i, j] = MimumumOf3(D[i - 1, j] + 1,
                                             D[i, j - 1] + 1,
                                             D[i - 1, j - 1] + cost);
                    }
                }
                return D[LA, LB];
            }
        }

        private static int MimumumOf3(int i, int j, int k)
        { return Math.Min(Math.Min(i, j), k); }

        public static float CompareStringsRatcliff(this string A, string B)
        { return CompareStringsRatcliff(A, B, false); }

        public static float CompareStringsRatcliff(this string A, string B, bool CaseSensitive)
        {
            int LA = A.Length;
            int LB = B.Length;

            if ((LA == 0) || (LB == 0))
                return 0.0f;
            else
            {
                string A1 = (CaseSensitive ? A : A.ToUpperInvariant());
                string B1 = (CaseSensitive ? B : B.ToUpperInvariant());
                if (A1.Equals(B1))
                    return 100.0f;
                else
                    return CompareStringsRatcliffInternal(A1, 0, LA - 1, B1, 0, LB - 1) * 200.0f / (LA + LB);
            }
        }

        private static int CompareStringsRatcliffInternal(string A, int StartIndexA, int EndIndexA, string B, int StartIndexB, int EndIndexB)
        {
            if ((StartIndexA > EndIndexA) || (StartIndexB > EndIndexB))
                return 0;
            else
            {
                int NewStartIndexA = 0;
                int NewStartIndexB = 0;
                int BestMatches = 0;
                for (int Ai = StartIndexA; Ai <= EndIndexA; Ai++)
                    for (int Bi = StartIndexB; Bi <= EndIndexB; Bi++)
                    {
                        int i = 0;
                        int Matches = 0;
                        while ((Ai + i <= EndIndexA) && (Bi + i <= EndIndexB) && (A[Ai + i] == B[Bi + i]))
                        {
                            Matches++;

                            if (Matches > BestMatches)
                            {
                                NewStartIndexA = Ai;
                                NewStartIndexB = Bi;
                                BestMatches = Matches;
                            }
                            i++;
                        }
                    }

                if (BestMatches > 0)
                {
                    BestMatches += CompareStringsRatcliffInternal(A, NewStartIndexA + BestMatches, EndIndexA, B, NewStartIndexB + BestMatches, EndIndexB);
                    BestMatches += CompareStringsRatcliffInternal(A, StartIndexA, NewStartIndexA - 1, B, StartIndexB, NewStartIndexB - 1);
                }

                return BestMatches;
            }
        }
    }
}
