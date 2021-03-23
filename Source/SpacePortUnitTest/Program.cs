using SpacePort;
using System;
using Xunit;

namespace SpacePortUnitTest
{
    public class Program
    {

        [Fact]
        public void APITest()
        {
            bool result = Api.ValidateName("Boba Fett").Result;

            Assert.Equal(result, true);
        }







        [Fact]
        public void CorrectVIPName()
        {


        }
    }
}
