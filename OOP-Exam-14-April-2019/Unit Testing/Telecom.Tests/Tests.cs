namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private const string make = "Samsung";
        private const string model = "S10+";

        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(make, model);
        }

        [Test]  
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(make, this.phone.Make);
            Assert.AreEqual(model, this.phone.Model);
        }

        [Test]
        public void TestWithLikeEmptyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(string.Empty, model);
            });
        }

        [Test]
        public void TestWithLikeEmptyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, string.Empty);
            });
        }
        
        [Test] 
        public void InitialCountShouldBeZero()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        public void TestIdAddWorksCorrectly()
        {
            int expectedCount = 2;

            this.phone.AddContact("Pesho", "+359888888888");

            this.phone.AddContact("Gosho", "+359888888883");

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestAddingExistingPerson()
        {
            this.phone.AddContact("Pesho", "+359888888888");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Pesho", "+359888888888");
            });
        }

        [Test]
        public void AddShouldAddCallableNumber()
        {
            string name = "Pesho";
            string number = "+359888888888";

            string expectedOutput = $"Calling {name} - {number}...";

            this.phone.AddContact("Pesho", "+359888888888");

            string actualOutput = this.phone.Call(name);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestCallingNonExistingPerson()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Pesho");
            });
        }
    }
}