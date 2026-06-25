using NUnit.Framework;
using FastXBusBooking.Services.Implementations;

namespace FastXBusBooking.Tests
{
    public class ServicesNUnitTests
    {
        [Test]
        public void UserService_ShouldExist()
        {
            Assert.That(typeof(UserService), Is.Not.Null);
        }

        [Test]
        public void BusOperatorService_ShouldExist()
        {
            Assert.That(typeof(BusOperatorService), Is.Not.Null);
        }

        [Test]
        public void BusService_ShouldExist()
        {
            Assert.That(typeof(BusService), Is.Not.Null);
        }

        [Test]
        public void RouteService_ShouldExist()
        {
            Assert.That(typeof(RouteService), Is.Not.Null);
        }

        [Test]
        public void BookingService_ShouldExist()
        {
            Assert.That(typeof(BookingService), Is.Not.Null);
        }

        [Test]
        public void PaymentService_ShouldExist()
        {
            Assert.That(typeof(PaymentService), Is.Not.Null);
        }

        [Test]
        public void AdminService_ShouldExist()
        {
            Assert.That(typeof(AdminService), Is.Not.Null);
        }
    }
}