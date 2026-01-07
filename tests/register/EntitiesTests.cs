using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using zCustodiaUi.data.register;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.register;
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.register;
using zCustodiaUi.runner;
using zCustodiaUi.utils;
using zCustodiaUi.workflows.register;

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
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteStandardFlow();
        }
        [Test, Order(2)]
        [AllureName("Should´t Register a new entity with CNPJ already exist´s")]
        public async Task Shouldnt_Register_a_New_Entity_With_CNPJ_Already_Exists()
        {
            var dataTest = new EntitiesData { EntityCnpj = "52721175000191" };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteStandardFlowAndClickSave();
            await entityPage.ValidateErrorMessage("Já existe uma entidade cadastrada com este CPF/CNPJ.");
        }

        [Test, Order(3)]
        [AllureName("Should´t Register a new entity with CNPJ already exist´s")]
        public async Task Shouldnt_Register_a_New_Entity_With_Empty_CNPJ()
        {
            var dataTest = new EntitiesData { EntityCnpj = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteStandardFlowAndValidateSaveButtonDisabled();
        }
        [Test, Order(4)]
        [AllureName("Should´t Register a new entity with Empty Name")]
        public async Task Shouldnt_Register_a_New_Entity_With_Empty_Name()
        {
            var dataTest = new EntitiesData { EntityName = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteStandardFlowAndValidateSaveButtonDisabled();
        }
        [Test, Order(5)]
        [AllureName("Should´t Register a new entity without Function")]
        public async Task Shouldnt_Register_a_New_Entity_Without_Function()
        {
            var entityPage = new EntitiesPage(_page);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteWithoutPermissionAndClickSave();
            await entityPage.ValidateErrorMessage(_data.ErrorMessageWhitoutFunction);
        }
        [Test, Order(6)]
        [AllureName("Should´t Register a new entity without Account")]
        public async Task Shouldnt_Register_a_New_Entity_Without_Account()
        {
            var entityPage = new EntitiesPage(_page);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteWithoutAccount();
            await entityPage.CLickOnSaveButton();
            await entityPage.ValidateErrorMessage(_data.ErrorMessageWhitoutAccount);
        }
        [Test, Order(7)]
        [AllureName("Should´t Register a new entity with Bank field empty")]
        public async Task Shouldnt_Register_a_New_Entity_With_Bank_Field_Empty()
        {
            var dataTest = new EntitiesData { BankName = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteWithBankFieldEmpty();
        }
        [Test, Order(8)]
        [AllureName("Should´t Register a new entity with Agency field empty")]
        public async Task Shouldnt_Register_a_New_Entity_With_Agency_Field_Empty()
        {
            var dataTest = new EntitiesData { NumberAgency = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNegativeAccount();
        }
        [Test, Order(9)]
        [AllureName("Should´t Register a new entity with Number Account empty")]
        public async Task Shouldnt_Register_a_New_Entity_With_Number_Account_Empty()
        {
            var dataTest = new EntitiesData { NumberAccount = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNegativeAccount();
        }
        [Test, Order(10)]
        [AllureName("Should´t Register a new entity with Number Account empty")]
        public async Task Shouldnt_Register_a_New_Entity_With_Description_Of_Account_Empty()
        {
            var dataTest = new EntitiesData { Description = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNegativeAccount();
        }
        [Test, Order(11)]
        [AllureName("Should´t Register a new entity without Representative")]
        public async Task Shouldnt_Register_a_New_Entity_Without_Representative()
        {
            var entityPage = new EntitiesPage(_page);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNoRepresentativeAndValidateErrorMessage(_data.ErrorMessageWhitoutRepresentative);
        }
        [Test, Order(12)]
        [AllureName("Should´t Register a new entity without Name of Representative")]
        public async Task Shouldnt_Register_a_New_Entity_Without_Name_Representative()
        {
            var dataTest = new EntitiesData { RepresentativeName = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNegativeRepresentative();
        }
        [Test, Order(13)]
        [AllureName("Should´t Register a new entity without CPF of Representative")]
        public async Task Shouldnt_Register_a_New_Entity_Without_CPF_Representative()
        {
            var dataTest = new EntitiesData { RepresentativeCpf = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNegativeRepresentative();
        }
        [Test, Order(14)]
        [AllureName("Should´t Register a new entity without Email of Representative")]
        public async Task Shouldnt_Register_a_New_Entity_Without_Email_Representative()
        {
            var dataTest = new EntitiesData { RepresentativeEmail = string.Empty };
            var entityPage = new EntitiesPage(_page, dataTest);
            var entityWorkflow = new EntitiesWorkflow(entityPage);
            await entityWorkflow.ExecuteNegativeRepresentative();
        }

    }
}
