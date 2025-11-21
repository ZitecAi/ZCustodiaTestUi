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
        private readonly FundsData data = new FundsData();


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
        [AllureName("Shouldn´t Register a New Fund With Epmty Fund Name")]
        public async Task Shouldnt_Register_a_New_Fund_With_Empty_Fund_Name()
        {
            data.FundName = string.Empty;
            var fundsPage = new FundsPage(page, data);
            await fundsPage.NegativeScenario("Fund name empty");
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



