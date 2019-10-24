namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private int capacity = 2;
        private string name = "Ceco";
        private double oxygen = 5;

        private Astronaut astronaut;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship(name, capacity);
            this.astronaut = new Astronaut(name, oxygen);
        }

        [Test]
        public void If_Constructor_Works_Correctly()
        {
            Assert.AreEqual(capacity, this.spaceship.Capacity);
            Assert.AreEqual(name, this.spaceship.Name);
        }

        [Test]
        public void If_Name_Is_Null_Or_WhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.spaceship = new Spaceship(null, capacity);
            });
        }
            
        [Test]
        public void If_Capacity_Is_Below_Zero()
        {
            int invalidCapacity = -5;

            Assert.Throws<ArgumentException>(() =>
            {
                this.spaceship = new Spaceship(name, invalidCapacity);
            });
        }

        [Test]
        public void If_Count_Works_Correctly()
        {
            int expectedCount = 1;

            this.spaceship.Add(astronaut);

            int actualCount = spaceship.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void If_Capacity_Is_Full()
        {
            this.spaceship = new Spaceship(name, 1);

            this.spaceship.Add(astronaut);

            bool isEqual = spaceship.Count == spaceship.Capacity;

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(astronaut);
            });
        }

        [Test]
        public void If_Astronaut_Already_Exist()
        { 
            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(astronaut);
            });
        }
        [Test]
        public void If_Add_Correctly()
        {

            int expectedCount = 1;

            spaceship.Add(astronaut);

            Assert.AreEqual(expectedCount , spaceship.Count);
        }

        [Test]
        public void If_Remove_Command_Works_Correctly(string name)
        {
            bool isExist = true;

            this.spaceship.Add(astronaut);

            bool actualMessage = spaceship.Remove("Ceco");

            Assert.AreEqual(isExist, actualMessage);
        }
    }
}