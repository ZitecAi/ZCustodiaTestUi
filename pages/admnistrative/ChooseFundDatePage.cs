using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.administrative;
using zCustodiaUi.locators;
using zCustodiaUi.locators.administrative;
using zCustodiaUi.locators.modules;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.admnistrative
{
    public class ChooseFundDatePage
    {
        private IPage _page;
        Utils _util;
        ChooseFundDateElements _choose = new ChooseFundDateElements();
        ModulesElements _mod = new ModulesElements();
        GenericElements _gen = new GenericElements();
        private readonly ChooseFundDateData _data = new ChooseFundDateData();

        public ChooseFundDatePage(IPage _page)
        {
            this._page = _page;
            _util = new Utils(_page);
        }
        [AllureStep("Back Date of fund")]
        public async Task ChooseFundDate(string fund)
        {
            var today = DateTime.Now.Day.ToString();


            await Task.Delay(3500);
            await _util.Click(_mod.MainMenu, "Click on main menu");
            await _util.Click(_mod.AdmnistrativePage, "Click on Administrative Page to navigate on options page");
            await _util.Click(_choose.ChooseFundDatePage, "Click on Choose Fund Date Page to navigate on page");
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on Search bar");
            await _util.Write(_gen.Filter, fund, "Write on Search bar To Find fund");
            await _util.Click("//mat-option", "Select Fund option");
            await _util.Click(_choose.ButtonSearch, "Click on fund option");

            await Task.Delay(2000);
            await _util.Click(_choose.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await _util.Click(_choose.Calendar, "Click on Calendar to extend to show days available");
            await _util.Click(_choose.DayValue(today), "set day that want filter on choose day to back fund");
            await _util.Click(_choose.ChooseButton, "Click on choose button to confirm back date fund");
            await Task.Delay(200);
            await _util.Write(_gen.LocatorMatLabel("Observações"), _data.Observations, "write obs on input");
            await _util.Click(_gen.LocatorSpanText("Enviar"), "Click on send to choose date fund");
            await _util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento!", "Validate if message success returned is visible on screen to the user to back date of fund");

        }


    }
}
