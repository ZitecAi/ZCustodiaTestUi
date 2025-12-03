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
        private Utils util;
        private readonly ModulesElements mod = new ModulesElements();
        private readonly FundsElements el = new FundsElements();


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
            await util.Click(el.FundsPage, "Open Funds page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register a New Fund")]
        //[Ignore("Esse teste está em espera para fluxo de exclusão")]
        public async Task Should_Register_a_New_Fund()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.RegisterData();
            await fundsPage.Rules();
            await fundsPage.Representatives();
            await fundsPage.Liquidation();
            await fundsPage.Account();
            await fundsPage.Slack();
            await fundsPage.FileValidation();
            await fundsPage.GoToServicePrestatives();
            await fundsPage.RegisterPrestativeAdministrator();
            await fundsPage.RegisterPrestativeManager();
            await fundsPage.RegisterPrestativeConsultant(true);
        }

        [Test, Order(2)]
        [AllureName("Should Consult a Fund")]
        public async Task Should_Consult_a_Fund()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.ConsultFund();
        }

        [Test, Order(3)]
        [AllureName("Shouldn´t Register a New Fund With Empty Fund Name")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_Fund_Name()
        {
            var testData = new FundsData { FundName = string.Empty };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("Fund name empty");
        }
        [Test, Order(4)]
        [AllureName("Should´t Register a New Fund With ISIN code empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_ISIN_code_empty()
        {
            var testData = new FundsData { IsinCode = string.Empty };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("ISIN code empty");
        }
        [Test, Order(5)]
        [AllureName("Should´t Register a New Fund With Exist CNPJ")]
        public async Task Shouldnt_Register_a_New_Fund_With_Exist_CNPJ()
        {
            var testData = new FundsData { CnpjFund = "54.638.076/0001-76" };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("CNPJ already exists");
        }
        [Test, Order(6)]
        [AllureName("Should´t Register a New Fund With Empty CNPJ")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_CNPJ()
        {
            var testData = new FundsData { CnpjFund = string.Empty };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("CNPJ empty");
        }
        [Test, Order(7)]
        [AllureName("Should´t Register a New Fund With Max Percent empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Max_Percent_Empty()
        {
            var testData = new FundsData { MaxPercent = string.Empty };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("Max Percent empty");
        }
        [Test, Order(8)]
        [AllureName("Should´t Register a New Fund With Agency Number empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Number_Agency_Empty()
        {
            var testData = new FundsData { AgencyNumber = string.Empty };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("Agency Number empty");
        }
        [Test, Order(9)]
        [AllureName("Should´t Register a New Fund With Description account empty")]
        public async Task Shouldnt_Register_a_New_Fund_With_Description_Account_Empty()
        {
            var testData = new FundsData { Description = string.Empty };
            var fundsPage = new FundsPage(page, testData);
            await fundsPage.NegativeScenario("Description account empty");
        }
        [Test, Order(10)]
        [AllureName("Should´t Register a New Fund Without type account ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Type_Account()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.NegativeScenario("Without Type Account");
        }
        [Test, Order(11)]
        [AllureName("Should´t Register a New Fund Without Consultant ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Consultant()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.NegativeScenario("Without Consultant");
        }
        [Test, Order(12)]
        [AllureName("Should´t Register a New Fund Without Manager ")]
        public async Task Shouldnt_Register_a_New_Fund_Without_Managers()
        {
            var fundsPage = new FundsPage(page);
            await fundsPage.NegativeScenario("Without Manager");
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



