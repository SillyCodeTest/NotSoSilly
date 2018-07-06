using System;
using System.ServiceModel;

namespace Fonlow.ReadifyKnock
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>implement IServiceBehavior, IErrorHandler in production</remarks>
    public class ReadifyKnockImp : IRedPill
    {
        static readonly Guid myToken = Guid.Parse("8fdfdeb2-050c-4aa4-ab23-f349ab3cedff");

        public Guid WhatIsYourToken()
        {
            return myToken;
        }

        public long FibonacciNumber(long n)
        {
            if (n>92 || n< -92)
            {
                throw new FaultException<ArgumentOutOfRangeException>(new ArgumentOutOfRangeException("n", "Fib does not like number larger than 92 or smaller than 92 for int64."));
            }
            return MiscHelper.CalculateFibonacciSeries(n);
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            return MiscHelper.GetTriangleType(a, b, c);
        }

        public string ReverseWords(string s)
        {
            return MiscHelper.ReverseWords(s);
        }

   
    }
}
