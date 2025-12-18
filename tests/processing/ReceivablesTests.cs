using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
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
        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        ReceivablesElements _el = new ReceivablesElements();

        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            _page = await OpenBrowserAsync();
            _util = new Utils(_page);
            var login = new LoginPage(_page);
            await login.DoLogin();
            await _util.Click(_mod.MainMenu, "Open main menu to extend options");
            await _util.Click(_mod.ProcessingPage, "Open Receivables module");
            await _util.Click(_el.ReceivablesPage, "Click on Receivables page to navigate on the page");
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
            var receivablesPage = new ReceivablesPage(_page);
            await receivablesPage.ProcessReceivable();
        }
        [Test, Order(2)]
        [AllureName("Should Process Receivable Partial")]
        public async Task Should_Process_Receivable_Partial()
        {
            var receivablesPage = new ReceivablesPage(_page);
            await receivablesPage.ProcessReceivablePartial();
        }
        [Test, Order(3)]
        [AllureName("Should Process Receivable Prorrogation")]
        [Ignore("This test is ignored temporarily, to wait build procedure")]
        public async Task Should_Process_Receivable_Prorrogation()
        {
            var receivablesPage = new ReceivablesPage(_page);
            await receivablesPage.ProcessProrrogation();
        }

    }
}
