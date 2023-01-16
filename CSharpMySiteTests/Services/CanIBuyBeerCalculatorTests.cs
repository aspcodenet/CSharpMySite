using CSharpMySite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMySiteTests.Services
{
    [TestClass]
    public class CanIBuyBeerCalculatorTests
    {
        private CanIBuyBeerCalculator sut; 
        public CanIBuyBeerCalculatorTests()
        {
            sut = new CanIBuyBeerCalculator();
        }

        [TestMethod]
        public void When_on_krogen_and_19_but_too_drunk_no_beer_will_be_served()
        {
            // Arrange
            float promille = 2.0f;
            int age = 19;
            var location = Location.Krogen;

            // Act
            var result = sut.CanIBuyBeer(location, age, promille);

            // Assert 
            Assert.AreEqual(false, result);
        }
    }

}
