using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.processing;
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.processing;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.processing
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    [AllureSuite("Receivables UI")]
    public class ReceivablesTests : TestBase
    {
        private IPage page;
        private Utils util;
        private readonly ModulesElements mod = new ModulesElements();
        ReceivablesElements el = new ReceivablesElements();

        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            util = new Utils(page);
            var login = new LoginPage(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Open main menu to extend options");
            await util.Click(mod.ProcessingPage, "Open Receivables module");
            await util.Click(el.ReceivablesPage, "Click on Receivables page to navigate on the page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Process Receivable")]
        public async Task Should_Process_Receivable()
        {
            var receivablesPage = new ReceivablesPage(page);
            await receivablesPage.ProcessReceivable();
        }
        [Test, Order(2)]
        [AllureName("Should Process Receivable Partial")]
        public async Task Should_Process_Receivable_Partial()
        {
            var receivablesPage = new ReceivablesPage(page);
            await receivablesPage.ProcessReceivablePartial();
        }
        [Test, Order(3)]
        [AllureName("Should Process Receivable Prorrogation")]
        public async Task Should_Process_Receivable_Prorrogation()
        {
            var receivablesPage = new ReceivablesPage(page);
            await receivablesPage.ProcessProrrogation();
        }

    }
}
