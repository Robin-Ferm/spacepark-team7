using System;
using SpacePort;
using Xunit;

namespace SpacePortUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool result = Api.ValidateName("Boba Fett").Result;

            Assert.Equal(result, true);
        }
    }
}
