using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;

namespace UnitTests.Pages.Startup
{
    /// <summary>
    /// Unit test for StartUp.cs file
    /// </summary>
    public class StartupTests
    {
        #region TestSetup


        /// <summary>
        /// Initializing the test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }


        /// <summary>
        /// Configure Startup test
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup


        /// <summary>
        /// Testing that startup configure services valid should pass
        /// </summary>
        #region ConfigureServices
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices


        /// <summary>
        /// Testing that startup configure valid default should pass
        /// </summary>
        #region Configure
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }

}