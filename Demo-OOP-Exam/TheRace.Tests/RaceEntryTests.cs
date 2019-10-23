using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitMotorcycle motorcycle;
        private UnitRider rider;

        private UnitRider secondRider;
        private UnitMotorcycle secondMotorcycle;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();

            this.motorcycle = new UnitMotorcycle("BMW", 30, 10);
            this.secondMotorcycle = new UnitMotorcycle("Suzuki", 30, 10);
            this.secondRider = new UnitRider("Gosho", this.motorcycle);
            this.rider = new UnitRider("Pesho", this.motorcycle);
        }

        [Test]
        public void TestIfAddRiderWorksCorrectly()
        {
            string actualMessage = this.raceEntry.AddRider(this.rider);

            string expectedMessage = "Rider Pesho added in race.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void TestIfAddRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(null);
            });
        }

        [Test]
        public void AddRiderIfAlreadyExist()
        {
            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(rider);
            });
        }

        [Test]
        public void CannotStartWithoutMinParticipans()
        {
            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void IfCalculateAverageHorsePowerWorksCorrectly()
        {
            double expectedAvgHorsePower = 30;

            raceEntry.AddRider(rider);
            raceEntry.AddRider(secondRider);

            double actualMessage = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAvgHorsePower, actualMessage);
        }
    }
}