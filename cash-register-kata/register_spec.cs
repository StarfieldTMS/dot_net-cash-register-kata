using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace cash_register_kata
{
    [TestClass]
    public class register_spec
    {
        private DateTime Monday = new DateTime(2014, 12, 1);
        private DateTime Tuesday = new DateTime(2014, 12, 2);
        private DateTime Wednesday = new DateTime(2014, 12, 3);
        private DateTime Thursday = new DateTime(2014, 12, 4);
        private DateTime Friday = new DateTime(2014, 12, 5);
        private DateTime Saturday = new DateTime(2014, 12, 6);
        private DateTime Sunday = new DateTime(2014, 12, 7);

        static void Main()
        {

        }

        [TestMethod]
        public void FrozenPizza()
        {
            var TestRegister = new register();
            TestRegister.addItems();

            var expectedResult = 5;
            TestRegister.cart.Add("Frozen Pizza", 1);
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 10;
            TestRegister.cart["Frozen Pizza"] +=  1;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);
        }

        [TestMethod]
        public void Corn()
        {
            var TestRegister = new register();
            TestRegister.addItems();

            var expectedResult = 0.5;
            TestRegister.cart.Add("Corn", 1);
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 2;
            TestRegister.cart["Corn"] = 5;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 2.5;
            TestRegister.cart["Corn"] += 1;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);
        }

        [TestMethod]
        public void GroundBeef()
        {
            var TestRegister = new register();
            TestRegister.addItems();

            var expectedResult = 4.99;
            TestRegister.cart.Add("Ground Beef", 1);
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 2.5;
            TestRegister.cart["Ground Beef"] = 0.5;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);
        }

        [TestMethod]
        public void ChocolateMayfieldIceCream()
        {
            var TestRegister = new register();
            TestRegister.addItems();
            TestRegister.date = Monday;

            var expectedResult = 5.99;
            TestRegister.cart.Add("Chocolate Mayfield Ice Cream", 1);
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            TestRegister.date = Wednesday;

            TestRegister.cart["Chocolate Mayfield Ice Cream"] = 2;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 11.98;
            TestRegister.cart["Chocolate Mayfield Ice Cream"] += 1;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            TestRegister.date = Monday;

            TestRegister.cart["Chocolate Mayfield Ice Cream"] = 2;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);
        }

        [TestMethod]
        public void VanillaMayfieldIceCream()
        {
            var TestRegister = new register();
            TestRegister.addItems();

            var expectedResult = 5.99;
            TestRegister.cart.Add("Vanilla Mayfield Ice Cream", 1);
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 11.98;
            TestRegister.cart["Vanilla Mayfield Ice Cream"] = 2;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);
        }

        [TestMethod]
        public void Mango()
        {
            var TestRegister = new register();
            TestRegister.addItems();
            TestRegister.date = Sunday;

            var expectedResult = 1.00;
            TestRegister.cart.Add("Mango", 1);
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 5;
            TestRegister.cart["Mango"] = 5;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            TestRegister.date = Monday;

            expectedResult = 2.5;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);

            expectedResult = 0.5;
            TestRegister.cart["Mango"] = 1;
            Assert.AreEqual(TestRegister.checkOut(), expectedResult);
        }
    }
}
