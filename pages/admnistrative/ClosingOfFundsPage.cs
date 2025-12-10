using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.administrative;
using zCustodiaUi.locators;
using zCustodiaUi.locators.administrative;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.admnistrative
{
    public class ClosingOfFundsPage
    {
        private readonly IPage _page;
        Utils _util;
        ClosingOfFundsElements _el = new ClosingOfFundsElements();
        GenericElements _gen = new GenericElements();
        private readonly ClosingOfFundsData _data = new ClosingOfFundsData();
        public ClosingOfFundsPage(IPage _page)
        {
            this._page = _page;
            _util = new Utils(_page);
        }
        [AllureStep("Close Fund")]
        public async Task CloseFund(string fund)
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();



            //await _util.Click(_el.SearchBar, $"Click on Search bar To Find {fund}");
            await Task.Delay(1000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), $"Write on Search bar To Find {fund}");
            await _util.Write(_gen.Filter, _data.FundName, "Click on filter input to search for fund");
            await _util.Click("(" + _gen.ReceiveTypeOption(_data.FundName) + ")[2]", "Click on fund option");
            await _util.Click(_el.ButtonSearch, "Click on fund option");

            await Task.Delay(2000);
            await _util.Click(_el.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await _util.Click(_el.Calendar, "Click on Calendar to expand the days available");
            await _util.Click(_el.DayValue(tomorrow), "Set Tomorrow day on calendar");
            await _util.Click(_el.ButtonCloseFund, "Click Button closed fund to confirm the process");
            await _util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento", "Validate if message success returned is visible on screen to the user after Closed fund");


        }

    }
}
