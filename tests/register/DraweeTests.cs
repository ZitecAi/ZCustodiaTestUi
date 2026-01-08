using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using zCustodiaUi.builders.register;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.register;
using zCustodiaUi.pages.login;
using zCustodiaUi.Pages.register;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.register
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    [AllureSuite("Drawee UI")]
    public class DraweeTests : TestBase
    {
        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        DraweeElements _el = new DraweeElements();
        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            _page = await OpenBrowserAsync();
            _util = new Utils(_page);
            var login = new LoginPage(_page);
            await login.DoLogin();
            await _util.Click(_mod.MainMenu, "Open main menu to extend options");
            await _util.Click(_mod.RegisterPage, "Open Register module");
            await _util.Click(_el.DraweePage, "Click on drawee page to visit page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register New Drawee")]
        public async Task Should_Register_New_Drawee()
        {
            var draweePage = new DraweePage(_page);
            var random = new Random();
            int uniqueNumber = random.Next(0, 9999);
            string draweeName = $"Sacado Test {uniqueNumber}";

            await new DraweeBuilder(draweePage)
                .ClickOnNewDraweeButton()
                .FillFund()
                .FillDraweeName(draweeName)
                .FillEmail()
                .FillCPF()
                .FillRelationshipDates()
                .FillAnnualRevenue()
                .FillEconomicConglomerate()
                .FillSize()
                .FillRiskClassification()
                .FillSocietyType()
                .FillStateRegistration()
                .FillAddress()
                .ClickOnSaveButton()
                .ValidateSuccessMessage()
                .FilterAndValidateDrawee(draweeName)
                .Execute();
        }



    }
}
