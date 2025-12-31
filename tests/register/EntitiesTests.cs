using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using zCustodiaUi.data.register;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.register;
using zCustodiaUi.pages.login;
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
    [AllureSuite("Entities UI")]
    public class EntitiesTests : TestBase
    {
        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        private readonly EntitiesElements _el = new EntitiesElements();
        private readonly EntitiesData _data = new EntitiesData();

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
            await _util.Click(_el.EntitiesPage, "Open Entities page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test(Description = "Create a new entity with valid data"), Order(1)]
        [AllureName("Should Register a new entity with valid data")]
        public async Task Should_Register_New_Entity_With_Valid_Data()
        {
            var entityBuilder = new builders.register.EntitiesBuilder(_page);
            await entityBuilder
                .ClickOnButtonNew()
                .FillMainData()
                .SetFunctionOfEntity()
                .GoToForm("Conta Corrente Consultoria")
                .ClickOnButtonNew()
                .FillAccountData()
                .CLickOnAddButton()
                .GoToForm("Representantes")
                .ClickOnButtonNew()
                .FillRepresentativeData()
                .SetAssign()
                .CLickOnAddButton()
                .CLickOnSaveButton()
                .Execute();
            await _util.ValidateTextIsVisibleOnScreen(_data.SuccessMessageWhenRegisterEntity, "Validate success message is present, given that I registered a new entity with valid data");
        }
    }
}
