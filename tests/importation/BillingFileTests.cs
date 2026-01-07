using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using zCustodiaUi.locators.Importation;
using zCustodiaUi.locators.modules;
using zCustodiaUi.pages.importation;
using zCustodiaUi.pages.login;
using zCustodiaUi.runner;
using zCustodiaUi.utils;
using zCustodiaUi.workflows.importation;

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
        ModulesElements mod = new ModulesElements();
        BillingFileElements el = new BillingFileElements();

        Utils util;
        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            _page = await OpenBrowserAsync();
            var login = new LoginPage(_page);
            util = new Utils(_page);
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
            var billingFilePage = new BillingFilePage(_page);
            var billingFileWorkflow = new BillingFileWorkflow(billingFilePage);
            await billingFileWorkflow.SendBillingFile();
        }

    }
}
