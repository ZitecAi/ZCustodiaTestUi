using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
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
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    [AllureSuite("Assignors UI")]
    public class AssignorsTests : TestBase
    {

        private Utils util;
        private readonly ModulesElements mod = new ModulesElements();
        private readonly AssignorsElements el = new AssignorsElements();

        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            util = new Utils(page);
            var login = new LoginPage(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Open main menu to extend options");
            await util.Click(mod.RegisterPage, "Open Register module");

            await util.Click(el.AssignorPage, "Click on assignor page to visit page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Do Valid CRUD Of Assignors")]
        //[Ignore("Esse teste está em espera para fluxo de exclusão")]
        public async Task Should_Do_Valid_CRUD_Of_Assignors()
        {
            var assignorsPage = new AssignorsPage(page);
            await assignorsPage.CRUD_Assignors();
        }



    }
}
