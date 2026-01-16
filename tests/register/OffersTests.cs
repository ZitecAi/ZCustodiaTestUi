using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using zCustodiaUi.builders.register;
using zCustodiaUi.data.register;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.register;
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.register;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.register
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Regression Tests")]
    [AllureSuite("Offers UI")]

    public class OffersTests : TestBase
    {

        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        private readonly OffersElements _el = new OffersElements();
        private readonly OffersData data = new OffersData();

        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            _page = await OpenBrowserAsync();
            _util = new Utils(_page);
            var login = new LoginPage(_page);
            await login.DoLogin();
            await _util.Click(_mod.MainMenu, "Click on main menu to expando pages list");
            await _util.Click(_mod.RegisterPage, "Open Register Page");
            await _util.Click(_el.OffersPage, "Go to Offers Page");
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test(Description = "Register a new offer successfully")]
        [AllureName("Should Register a new offer successfully")]
        public async Task Shoud_Register_A_New_Offer_Succesfully()
        {
            var offersPage = new OffersPage(_page);
            await new OffersBuilder(offersPage)
                .ClickOnNewButton()
                .FillFormNewOffer()
                .ClickOnSaveButton()
                .Execute();
        }





    }
}
