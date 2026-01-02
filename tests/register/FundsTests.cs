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
            await fundsPage.ExecuteStandardFlow();
            await fundsPage.SaveFund();
        }

        [Test, Order(2)]
        [AllureName("Should Consult a Fund")]
        public async Task Should_Consult_a_Fund()
        {
            var fundsPage = new FundsPage(_page);
            await fundsPage.ConsultFund();
        }

        [Test, Order(3)]
        [AllureName("Shouldn´t Register a New Fund With Empty Fund Name")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_Fund_Name()
        {
            var testData = new FundsData { FundName = string.Empty };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .WithServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 3)
                .ValidateSaveDisabled();
        }

        [Test, Order(4)]
        [AllureName("Should´t Register a New Fund With ISIN code empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_ISIN_code_empty()
        {
            var testData = new FundsData { IsinCode = string.Empty };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .WithServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 3)
                .ValidateSaveDisabled();
        }

        [Test, Order(5)]
        [AllureName("Should´t Register a New Fund With Exist CNPJ")]
        public async Task Shouldnt_Register_a_New_Fund_With_Exist_CNPJ()
        {
            var testData = new FundsData { CnpjFund = "54.638.076/0001-76" };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .WithServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 3)
                .ValidateErrorMessage("Fundo já existente para o CNPJ '54638076000176'.");
        }

        [Test, Order(6)]
        [AllureName("Should´t Register a New Fund With Empty CNPJ")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_CNPJ()
        {
            var testData = new FundsData { CnpjFund = string.Empty };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .WithServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 3)
                .ValidateSaveDisabled();
        }

        [Test, Order(7)]
        [AllureName("Should´t Register a New Fund With Max Percent empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Max_Percent_Empty()
        {
            var testData = new FundsData { MaxPercent = string.Empty };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .WithServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 3)
                .ValidateSaveDisabled();
        }

        [Test, Order(8)]
        [AllureName("Should´t Register a New Fund With Agency Number empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Number_Agency_Empty()
        {
            var testData = new FundsData { AgencyNumber = string.Empty };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .ValidateAddAccountButtonDisabled();
        }

        [Test, Order(9)]
        [AllureName("Should´t Register a New Fund With Description account empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Description_Account_Empty()
        {
            var testData = new FundsData { Description = string.Empty };
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .ValidateAddAccountButtonDisabled();
        }

        [Test, Order(10)]
        [AllureName("Should´t Register a New Fund Without type account ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Type_Account()
        {
            await new FundsBuilder(_page)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAction(async () =>
                {
                    await new FundsPage(_page).FillAccountFormNotypeAccount();
                })
                .ValidateAddAccountButtonDisabled();
        }

        [Test, Order(11)]
        [AllureName("Should´t Register a New Fund Without Consultant ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Consultant()
        {
            await new FundsBuilder(_page)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Gestor", "ORIGINADOR QA", 2, 2)
                .ValidateErrorMessage("É obrigatório um 'Consultor' como prestador.");
        }

        [Test, Order(12)]
        [AllureName("Should´t Register a New Fund Without Manager ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Managers()
        {
            var testData = new FundsData();
            await new FundsBuilder(_page, testData)
                .WithRegisterData()
                .WithRules()
                .WithRepresentatives()
                .WithLiquidation()
                .WithAccount()
                .AddAccount()
                .WithSlack()
                .WithFileValidation()
                .GoToForm("Prestadores de Serviços")
                .WithServiceProvider("Administrador", "ORIGINADOR QA")
                .WithServiceProvider("Consultoria", "ID CORRETORA DE TITULOS E VALORES MOBILIARIOS SA", null, 2)
                .ValidateErrorMessage("É obrigatório um 'Gestor' como prestador.");
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
