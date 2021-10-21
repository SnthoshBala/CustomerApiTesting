using NUnit.Framework;
using CustomerAPI.FiberConnection;
using CustomerAPI.Service;
using Moq;

namespace CustomerTestAPI
{
    public class Tests
    {
        public Mock<ICustomerServ<Customer>> cmock;
        public Customer c;
        public Customer cadd;
        public Customer cinadd;
        public Customer cput;
        public Customer cinput;
        public Customer clogin;
        public Customer ctest;
        [SetUp]
        public void Setup()
        {
            c = new Customer();
            cadd = new Customer
            {
                CustomerName = "Test",
                CustomerAadharNo = "TestAadhar",
                CustomerMailId = "test@gmail.com",
                CustomerPassword="pass",
                CustomerPhoneNumber="787898767"
            };
            cinadd = new Customer
            {
                CustomerId = 101,
                CustomerName = "Test",
                CustomerAadharNo = "TestAadhar",
                CustomerMailId = "test@gmail.com",
                CustomerPassword = "pass",
                CustomerPhoneNumber = "787898767"
            };
            ctest = new Customer
            {
                CustomerId=101,
                CustomerName="BALASUBRAMANIYAN R",
                CustomerMailId="balasb00714@gmail.com",
                CustomerPassword="raguraman12"
            };
            cput = new Customer
            {
                CustomerId=109,
                CustomerName = "Test1",
                CustomerAadharNo = "TestAadhar",
                CustomerMailId = "test@gmail.com",
                CustomerPassword = "pass",
                CustomerPhoneNumber = "787898767"
            };
            cinput = new Customer
            {
                CustomerName = "Test",
                CustomerAadharNo = "TestAadhar",
                CustomerMailId = "test@gmail.com",
                CustomerPassword = "pass",
                CustomerPhoneNumber = "787898767"
            };
            clogin = new Customer
            {
                CustomerMailId = "test@gmail.com",
                CustomerPassword = "pass",
            };
            cmock = new Mock<ICustomerServ<Customer>>();
        }

        [Test]
        public void ValidGetCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.GetByCustomer(101).Result;
            Assert.AreEqual(res.CustomerMailId, ctest.CustomerMailId);
        }
        [Test]
        public void InValidGetCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.GetByCustomer(101).Result;
            Assert.AreEqual(res.CustomerMailId, cadd.CustomerMailId);
        }
        [Test]
        public void ValidAddCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.AddCustomer(cadd).Result;
            Assert.AreEqual(1, res);
        }
        [Test]
        public void InVaidAddCutsomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.AddCustomer(cinadd).Result;
            Assert.AreEqual(1, res);
        }
        [Test]
        public void ValidLoginCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.GetLoginDetails(clogin);
            Assert.AreEqual(cadd.CustomerName, res.CustomerName);
        }
        [Test]
        public void InvalidLoginCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.GetLoginDetails(ctest);
            Assert.AreEqual(cadd.CustomerName, res.CustomerName);
        }
        [Test]
        public void ValidPutCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.EditCustomer(cput,108).Result;
            Assert.AreEqual(res, 1);
        }
        [Test]
        public void InValidPutCustomer()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.EditCustomer(cinput, 101).Result;
            Assert.AreEqual(res,1);
        }
        [Test]
        public void ValidDelete()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.DeleteCustomer(109).Result;
            Assert.AreEqual(res, 1);
        }
        [Test]
        public void InValidDelete()
        {
            cmock.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            var res = c.DeleteCustomer(110).Result;
            Assert.AreEqual(res, 1);
        }
    }
}