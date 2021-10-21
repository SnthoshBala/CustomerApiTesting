using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAPI.Controllers;
using CustomerAPI.FiberConnection;
using CustomerAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CustomerTestAPI
{
    class UnitiControllerTest
    {
        public Customer c;
        public CustomerController cc;
        public Mock<ICustomerServ<Customer>> cs;
        [SetUp]
        public void Setup()
        {
            cs = new Mock<ICustomerServ<Customer>>();
            c = new Customer();
        }
        [Test]
        public void ValidGetTest()
        {
            cs.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            cc = new CustomerController(cs.Object);
            var res=cc.GetCustomer().Result as OkObjectResult;
            Assert.AreEqual(200,res.StatusCode);
        }
        [Test]
        public void InValidGetTest()
        {
            cs.Setup(G => G.GetCustomer().Result).Returns(c.GetCustomer().Result);
            cc = new CustomerController(cs.Object);
            var res = cc.GetCustomer().Result as OkObjectResult;
            Assert.AreEqual(500, res.StatusCode);
        }
        [Test]
        public void ValidGetByIdTest()
        {
            cs.Setup(G => G.GetByCustomer(101).Result).Returns(c.GetByCustomer(101).Result);
            cc = new CustomerController(cs.Object);
            var res = cc.GetByCustomer(101).Result as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
        [Test]
        public void InVaildGetByIdTest()
        {
            cs.Setup(G => G.GetByCustomer(120).Result).Returns(c.GetByCustomer(120).Result);
            cc = new CustomerController(cs.Object);
            var res = cc.GetByCustomer(120).Result as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
    }
}
