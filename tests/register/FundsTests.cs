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
    [AllureSuite("Funds UI")]
    public class FundsTests : TestBase
    {
        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        private readonly FundsElements _el = new FundsElements();
        private readonly FundsData _data = new FundsData();


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
            await _util.Click(_el.FundsPage, "Open Funds page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test(Description = "Register a new Fund with valid data"), Order(1)]
        [AllureName("Should Register a New Fund")]
        [Ignore("ignored to not overload the system with new funds")]
        public async Task Should_Register_a_New_Fund()
        {
            var fundsPage = new FundsPage(_page);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator)
                .RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2)
                .RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3)
                .SaveFund()
                .Execute();
        }

        [Test, Order(2)]
        [AllureName("Should Consult a Fund")]
        public async Task Should_Consult_a_Fund()
        {
            var fundsPage = new FundsPage(_page);
            await new FundsBuilder(fundsPage)
                .ConsultFund()
                .Execute();
        }

        [Test, Order(3)]
        [AllureName("Shouldn´t Register a New Fund With Empty Fund Name")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_Fund_Name()
        {
            var testData = new FundsData { FundName = string.Empty };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator)
                .RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2)
                .RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3)
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(4)]
        [AllureName("Should´t Register a New Fund With ISIN code empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_ISIN_code_empty()
        {
            var testData = new FundsData { IsinCode = string.Empty };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator)
                .RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2)
                .RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3)
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(5)]
        [AllureName("Should´t Register a New Fund With Exist CNPJ")]
        public async Task Shouldnt_Register_a_New_Fund_With_Exist_CNPJ()
        {
            var testData = new FundsData { CnpjFund = "54.638.076/0001-76" };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator)
                .RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2)
                .RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3)
                .SaveFundNegative("Fundo já existente para o CNPJ '54638076000176'.")
                .Execute();
        }

        [Test, Order(6)]
        [AllureName("Should´t Register a New Fund With Empty CNPJ")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_CNPJ()
        {
            var testData = new FundsData { CnpjFund = string.Empty };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator)
                .RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2)
                .RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3)
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(7)]
        [AllureName("Should´t Register a New Fund With Max Percent empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Max_Percent_Empty()
        {
            var testData = new FundsData { MaxPercent = string.Empty };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator)
                .RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2)
                .RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3)
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(8)]
        [AllureName("Should´t Register a New Fund With Agency Number empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Number_Agency_Empty()
        {
            var testData = new FundsData { AgencyNumber = string.Empty };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .ValidateAddAccountButtonDisabled()
                .Execute();
        }

        [Test, Order(9)]
        [AllureName("Should´t Register a New Fund With Description account empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Description_Account_Empty()
        {
            var testData = new FundsData { Description = string.Empty };
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .ValidateAddAccountButtonDisabled()
                .Execute();
        }

        [Test, Order(10)]
        [AllureName("Should´t Register a New Fund Without type account ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Type_Account()
        {
            var fundsPage = new FundsPage(_page);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountFormNotypeAccount()
                .ValidateAddAccountButtonDisabled()
                .Execute();
        }

        [Test, Order(11)]
        [AllureName("Should´t Register a New Fund Without Consultant ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Consultant()
        {
            var fundsPage = new FundsPage(_page);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider("Administrador", "ORIGINADOR QA")
                .RegisterServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .SaveFundNegative("É obrigatório um 'Consultor' como prestador.")
                .Execute();
        }

        [Test, Order(12)]
        [AllureName("Should´t Register a New Fund Without Manager ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Managers()
        {
            var testData = new FundsData();
            var fundsPage = new FundsPage(_page, testData);
            await new FundsBuilder(fundsPage)
                .RegisterData()
                .Rules()
                .Representatives()
                .Liquidation()
                .FillAccountForm()
                .AddAccount()
                .Slack()
                .FileValidation()
                .GoToForm("Prestadores de Serviços")
                .RegisterServiceProvider("Administrador", "ORIGINADOR QA")
                .RegisterServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 2)
                .SaveFundNegative("É obrigatório um 'Gestor' como prestador.")
                .Execute();
        }

        //[Test, Order(4)]
        //[Ignore("Esse teste está em espera para fluxo de exclusão")]
        //[AllureName("Should Update a Fund")]
        //public async Task Should_Update_a_Fund()
        //{
        //    var fundsPage = new FundsPage(page);
        //    await fundsPage.UpdateFund();
        //}

    }
}
