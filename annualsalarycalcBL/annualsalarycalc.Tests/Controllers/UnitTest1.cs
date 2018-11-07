using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using annualsalarycalcBL.Controllers;
using annualsalarycalcBL.BussinessLogic.Models;
using System.Web.Http;

namespace InsurranceApi.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
            EmployeeController controller = new EmployeeController();
            EmployeeDTO employee = controller.Get(1);

            Assert.AreEqual(86400000, employee.salary);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //
            // TODO: Add test logic here
            //
            EmployeeController controller = new EmployeeController();
            EmployeeDTO employee = controller.Get(2);
            Assert.AreEqual(960000, employee.salary);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //
            // TODO: Add test logic here
            //
            try
            {
                EmployeeController controller = new EmployeeController();
                EmployeeDTO employee = controller.Get(3);
                Assert.Fail();
            }
            catch (HttpResponseException e)
            {
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
