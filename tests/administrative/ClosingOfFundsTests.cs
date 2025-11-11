using Allure.Commons;
using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using zCustodiaUi.locators.administrative;
using zCustodiaUi.locators.modules;
using zCustodiaUi.pages.admnistrative;
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.reports;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.administrative
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    [AllureSuite("Arquivo de Remessa UI")]
    public class ClosingOfFundsTests : TestBase
    {
        private IPage page;
        Utils util;
        ClosingOfFundsElements el = new ClosingOfFundsElements();
        ModulesElements mod = new ModulesElements();
        string fundName = "Zitec FIDC";
        [SetUp]
        public async Task SetUp()
        {
            page = await OpenBrowserAsync();
            var login = new LoginPage(page);
            util = new Utils(page);
            await login.DoLogin();
            await util.Click(mod.MainMenu, "Click on Main menu to extend page Options");
            await util.Click(mod.AdmnistrativePage, "Click on Administrative Page to navigate on options page");
            await util.Click(el.ClosingFundsPage, "Click on Closing of Funds Page to navigate on the page");

        }

        [TearDown]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Deve Realizar o Fechamento de Fundo, Processar e Gerar Relatório")]
        public async Task Should_Do_Processing_And_Generating_Report_Of_Fund()
        {
            var fund = new ClosingOfFundsPage(page);
            await fund.CloseFund(fundName);

            var myReports = new MyReportsPage(page);
            await myReports.ValidateGenerateReportsAndDownloadReport(fundName);

            var chooseDateFund = new ChooseFundDatePage(page);
            await chooseDateFund.ChooseFundDate(fundName);

        }



    }
}
