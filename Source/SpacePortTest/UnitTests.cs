using System;
using SpacePort;
using Xunit;
using System.Linq;

namespace SpacePortTest
{
    public class UnitTests
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

        [Fact]
        public void ParkingSpacesLeft()
        {

            var result = DBMethods.EmptySpaces();

            Assert.True(result);
        }

        [Fact]
        public void CheckIfParkDataBaseIsNotEmpty()
        {
            using (var db = new MyContext())
            {
                var query = (from p in db.Park
                             select p).Count();

                Assert.True(query > 0);
            }

        }
    }
}
