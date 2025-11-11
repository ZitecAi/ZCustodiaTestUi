using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.locators.Importation;
using zCustodiaUi.locators.modules;
using zCustodiaUi.pages.importation;
using zCustodiaUi.pages.login;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.importation
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    [AllureSuite("Billing File UI")]
    public class BillingFileTests : TestBase
    {
        private IPage page;
        ModulesElements mod = new ModulesElements();
        BillingFileElements el = new BillingFileElements();

        Utils util;
        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            util = new Utils(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Click on Main menu to extend page Options");
            await util.Click(mod.ImportationPage, "Click on Importation Page to navigate on options page");
            await util.Click(el.BillingFilePage, "Click on Shipping File page to navigate on the page");

        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }
        [Test, Order(1)]
        [AllureName("Should Import a New Billing File")]
        public async Task Should_Import_a_New_Billing_File()
        {
            var billingFile = new BillingFilePage(page);
            await billingFile.SendBillingFile();
        }
    }
}
