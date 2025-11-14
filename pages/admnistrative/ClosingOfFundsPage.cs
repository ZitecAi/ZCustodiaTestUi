using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.locators;
using zCustodiaUi.locators.administrative;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.admnistrative
{
    public class ClosingOfFundsPage
    {
        private readonly IPage page;
        Utils util;
        ClosingOfFundsElements el = new ClosingOfFundsElements();
        GenericElements gen = new GenericElements();
        public ClosingOfFundsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }
        [AllureStep("Close Fund")]
        public async Task CloseFund(string fund)
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();

            string fundName = "Zitec FIDC";

            //await util.Click(el.SearchBar, $"Click on Search bar To Find {fund}");
            await Task.Delay(1000);
            await util.Click(gen.LocatorMatLabel("Fundo"), $"Write on Search bar To Find {fund}");
            await util.Write(gen.Filter, fundName, "Click on filter input to search for fund");
            await util.Click("(" + gen.ReceiveTypeOption(fundName) + ")[2]", "Click on fund option");
            await util.Click(el.ButtonSearch, "Click on fund option");

            await Task.Delay(2000);
            await util.Click(el.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await util.Click(el.Calendar, "Click on Calendar to expand the days available");
            await util.Click(el.DayValue(tomorrow), "Set Tomorrow day on calendar");
            await util.Click(el.ButtonCloseFund, "Click Button closed fund to confirm the process");
            await util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento", "Validate if message success returned is visible on screen to the user after Closed fund");


        }

    }
}
