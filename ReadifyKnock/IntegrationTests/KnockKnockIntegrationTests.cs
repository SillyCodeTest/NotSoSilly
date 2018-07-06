using System;
using Xunit;
using Fonlow.ReadifyKnock;

namespace Fonlow.ReadifyKnockTests
{
    [Collection("IISExpress")]
    public class KnockKnockIntegrationTests
    {
        static readonly Guid myToken = Guid.Parse("8fdfdeb2-050c-4aa4-ab23-f349ab3cedff");
        [Fact]
        public void TestMyReadifyKnockLocal()
        {
            using (var client = new RedPillClient("knockEndpoint"))
            {
                var token = client.WhatIsYourToken();
                Assert.Equal(myToken, token);
            }
        }

        [Fact]
        public void TestMyReadifyKnockRemote()
        {
            using (var client = new RedPillClient("knockEndpoint", "http://misc.fonlow.com/ReadifyKnock/Knock.svc"))
            {
                var token = client.WhatIsYourToken();
                Assert.Equal(myToken, token);
            }
        }

        [Fact]
        public void TestReverseWords()
        {
                using (var client = new RedPillClient("knockEndpoint"))
                {
                    var r = client.ReverseWords("Cat and dog");
                    Assert.Equal("taC dna god", r);
                }

        }

        [Fact]
        public void TestFibonacciNumber()
        {
            using (var client = new RedPillClient("knockEndpoint"))
            {
                var r = client.FibonacciNumber(92);
                Assert.Equal(7540113804746346429, r);
            }


        }

        [Fact]
        public void TestFibExceedThrows()
        {
            Assert.Throws<System.ServiceModel.FaultException<ArgumentOutOfRangeException>>(() =>
            {
                using (var client = new RedPillClient("knockEndpoint"))
                {
                    var r = client.FibonacciNumber(9223372036854775807);
                }
            });

        }


        [Fact]
        public void TestNegativeFibExceedThrows()
        {
            Assert.Throws<System.ServiceModel.FaultException<ArgumentOutOfRangeException>>(() =>
            {
                using (var client = new RedPillClient("knockEndpoint"))
                {
                    var r = client.FibonacciNumber(-93);
                }
            });
        }


    }
}
