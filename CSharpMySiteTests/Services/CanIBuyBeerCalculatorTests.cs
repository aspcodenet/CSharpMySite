using CSharpMySite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Frameworks;

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
        public void When_on_krogen_and_19_but_to_drunk_no_beer_will_be_served()
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

        [TestMethod]
        public void When_on_krogen_and_19_and_not_to_drunk_beer_will_be_served()
        {
            // Arrange
            float promille = 0.8f;
            int age = 19;
            var location = Location.Krogen;

            // Act
            var result = sut.CanIBuyBeer(location, age, promille);

            // Assert 
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void When_on_krogen_and_17_and_not_to_drunk_beer_will_not_be_served()
        {
            // Arrange
            float promille = 0.0f;
            int age = 17;
            var location = Location.Krogen;

            // Act
            var result = sut.CanIBuyBeer(location, age, promille);

            // Assert 
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void When_on_systemet_and_21_and_not_to_drunk_beer_will_be_served()
        {
            // Arrange
            float promille = 0.0f;
            int age = 21;
            var location = Location.Systemet;

            // Act
            var result = sut.CanIBuyBeer(location, age, promille);

            // Assert 
            Assert.AreEqual(true, result);
        }



        [TestMethod]
        public void When_on_systemet_and_19_and_not_to_drunk_beer_will_not_be_served()
        {
            // Arrange
            float promille = 0.0f;
            int age = 19;
            var location = Location.Systemet;

            // Act
            var result = sut.CanIBuyBeer(location, age, promille);

            // Assert 
            Assert.AreEqual(false, result);
        }




    }

}
