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
            var entityPage = new EntitiesPage(_page);
            await entityPage.ExecuteStandardFlow();
        }
        [Test, Order(2)]
        [AllureName("Should´t Register a new entity with CNPJ already exist´s")]
        public async Task Shouldnt_Register_a_New_Entity_With_CNPJ_Already_Exists()
        {
            var dataTest = new EntitiesData { EntityCnpj = "52721175000191" };
            await EntitiesBuilder.CreateForSave(_page, dataTest)
                .ValidateErrorMessage("Já existe uma entidade cadastrada com este CPF/CNPJ.");
        }

        [Test, Order(3)]
        [AllureName("Should´t Register a new entity with CNPJ already exist´s")]
        public async Task Shouldnt_Register_a_New_Entity_With_Empty_CNPJ()
        {
            var dataTest = new EntitiesData { EntityCnpj = string.Empty };
            await EntitiesBuilder.CreateForValidation(_page, dataTest)
                .ValidateButtonSaveDisable();
        }
        [Test, Order(4)]
        [AllureName("Should´t Register a new entity with Empty Name")]
        public async Task Shouldnt_Register_a_New_Entity_With_Empty_Name()
        {
            var dataTest = new EntitiesData { EntityName = string.Empty };
            await EntitiesBuilder.CreateForValidation(_page, dataTest)
                .ValidateButtonSaveDisable();
        }

    }
}
