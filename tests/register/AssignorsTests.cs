// AssignorsTests

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

        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        private readonly AssignorsElements _el = new AssignorsElements();

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

            await _util.Click(_el.AssignorPage, "Click on assignor page to visit page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register Assignors")]
        public async Task Should_Register_Assignor()
        {
            var assignorsPage = new AssignorsPage(_page);
            await assignorsPage.RegisterAssignor();
        }

        [Test, Order(2)]
        [AllureName("Should Update Assignor")]
        public async Task Should_Update_Assignor()
        {
            var assignorsPage = new AssignorsPage(_page);
            await assignorsPage.UpdateAssignor();
        }
        [Test, Order(3)]
        [AllureName("Should Consult and Delete Assignor")]
        public async Task Should_Consult_And_Delete_Assignor()
        {
            var assignorsPage = new AssignorsPage(_page);
            await assignorsPage.ConsultAssignorAndDelete();
        }




    }
}
