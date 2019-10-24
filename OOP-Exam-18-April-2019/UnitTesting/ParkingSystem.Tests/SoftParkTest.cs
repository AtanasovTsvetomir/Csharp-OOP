namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;
        private Car secondCar;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.car = new Car("Volvo", "P3435P");
            this.secondCar = new Car("BMW", "P5555P");
        }

        [Test]
        public void IfConstructorWorksCorrectly()
        {
        }

        [Test]  
        public void ParkCarIfParkSpotDoesntExist()
        {
            string parkSpot = "C5";

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar(parkSpot, car);
            });
        }

        [Test] 
        public void ParkIfParkSpotAlreadyExist()
        {
            string parkSpot = "A1";

            softPark.ParkCar(parkSpot, car);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar(parkSpot, secondCar);
            });
        }

        [Test]
        public void ParkIfCarAlreadyExist()
        {
            string parkSpot = "A1";

            softPark.ParkCar(parkSpot, car);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar(parkSpot, car);
            });
        }

        [Test]
        public void IfParkCarSuccessfully()
        {
            string expectedMessage = $"Car:P3435P parked successfully!";

            string parkSpot = "A1";
            string actualMessage = softPark.ParkCar(parkSpot, car);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void IfRemovingCarDoesntExist()
        {
            string parkSpot = "A1";

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar(parkSpot, car);
            });
        }

        [Test]
        public void IfCarRemovingSuccessfully()
        {
            string expectedMessage = $"Remove car:P3435P successfully!"; ;

            string parkSpot = "A1";

            softPark.ParkCar(parkSpot, car);

            string actualMessage = softPark.RemoveCar(parkSpot, car);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void ConstucturIfWorksCorrectly()
        {
            int actualCount = this.softPark.Parking.Count;
            int expectedCount = 12;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}