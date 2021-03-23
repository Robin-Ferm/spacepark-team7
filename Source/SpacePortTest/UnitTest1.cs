using System;
using SpacePort;
using Xunit;

namespace SpacePortTest
{
    public class UnitTest1
    {
        [Fact]
        public void RecievingNames()
        {
            bool result = Api.ValidateName("Boba Fett").Result;

            Assert.True(result);
        }

        [Fact]
        public void RecievingShipNames()
        {
            var result = Api.GetStarShips();

            Assert.NotNull(result);
        }

        [Fact]
        public void CheckWrongName()
        {
            bool result = Api.ValidateName("HejSvejs").Result;


            Assert.False(result);
        }

        [Fact]
        public void AlreadyParkedTest()
        {
            var result = DBMethods.AlreadyParked("Boba Fett");

            Assert.False(result);
        }
    }
}
