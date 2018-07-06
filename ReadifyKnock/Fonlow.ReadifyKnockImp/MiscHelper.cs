using System;
using System.Text;

namespace Fonlow.ReadifyKnock
{
    public static class MiscHelper
    {
        /// <summary>
        /// Receives three integer inputs for the lengths of the sides of a triangle and returns one of four values to determine the triangle type.
        /// </summary>
        public static TriangleType GetTriangleType(int side1, int side2, int side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                return TriangleType.Error;
            }

            long s1 = side1;
            long s2 = side2;
            long s3 = side3;

            if ((s1 + s2 <= s3) || (s1 + s3 <= s2) || (s2 + s3 <= s1))
            {
                return TriangleType.Error;
            }

            bool e1 = s1 == s2;
            bool e2 = s1 == s3;

            if (e1 && e2)
            {
                return TriangleType.Equilateral;
            }

            bool e3 = s2 == s3;

            if (e1 || e2 || e3)
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }

        public static long CalculateFibonacciSeries(long n)
        {
            if (n == 0) return 0;   
            if (n == 1) return 1; 
            if (n == -1) return -1; 

            var a = Math.Abs(n);
            bool negative = n < 0;
            if (a>92)
            {
                throw new ArgumentOutOfRangeException("n", "Fib does not like number larger than 92 for int64.");
            }
            long firstnumber = 0, secondnumber = 1, result = 0;

            for (long i = 2; i <= a; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return negative ? -result : result;
        }


        /// <summary>
        /// Reverse the words in a string, for example “cat and dog” becomes “tac dna god”.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null or empty.</exception>
        public static string ReverseWords(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text", "Text cannot be null or empty.");
            }

            var builder = new StringBuilder(text.Length);
            var charArray = text.ToCharArray();
            int lowBoundInclusive = 0;
            int highBoundInclusive = 0;
            bool literalFound = false;
            for (int i = 0; i <= charArray.Length; i++)//inclusive for loop
            {
                bool endOfText = i == charArray.Length;
                if (endOfText || Char.IsWhiteSpace(charArray[i]))
                {
                    if (literalFound && (highBoundInclusive >= lowBoundInclusive))
                    {
                        if (endOfText)
                        {
                            for (int j = charArray.Length - 1; j >= lowBoundInclusive; j--)//inclusive for loop
                            {
                                builder.Append(charArray[j]);
                            }

                            break;
                        }
                        else
                        {
                            for (int j = highBoundInclusive; j >= lowBoundInclusive; j--)//inclusive for loop
                            {
                                builder.Append(charArray[j]);
                            }
                        }
                    }

                    if (endOfText)
                    {
                        break;
                    }

                    builder.Append(charArray[i]);

                    lowBoundInclusive = i + 1;
                    highBoundInclusive = i;
                    literalFound = false;
                }
                else
                {
                    highBoundInclusive = i;
                    literalFound = true;
                }
            }

            return builder.ToString();

        }

    }

}
