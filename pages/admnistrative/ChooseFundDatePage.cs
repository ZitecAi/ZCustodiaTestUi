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
        private IPage page;
        Utils util;
        ChooseFundDateElements choose = new ChooseFundDateElements();
        ModulesElements mod = new ModulesElements();
        GenericElements gen = new GenericElements();
        private readonly ChooseFundDateData data = new ChooseFundDateData();

        public ChooseFundDatePage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }
        [AllureStep("Back Date of fund")]
        public async Task ChooseFundDate(string fund)
        {
            var today = DateTime.Now.Day.ToString();


            await Task.Delay(3500);
            await util.Click(mod.MainMenu, "Click on main menu");
            await util.Click(mod.AdmnistrativePage, "Click on Administrative Page to navigate on options page");
            await util.Click(choose.ChooseFundDatePage, "Click on Choose Fund Date Page to navigate on page");
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on Search bar");
            await util.Write(gen.Filter, fund, "Write on Search bar To Find fund");
            await util.Click("//mat-option", "Select Fund option");
            await util.Click(choose.ButtonSearch, "Click on fund option");

            await Task.Delay(2000);
            await util.Click(choose.FirstCheckbox, "Click on First CheckBox to mark the fund to be closed");
            await util.Click(choose.Calendar, "Click on Calendar to extend to show days available");
            await util.Click(choose.DayValue(today), "set day that want filter on choose day to back fund");
            await util.Click(choose.ChooseButton, "Click on choose button to confirm back date fund");
            await Task.Delay(200);
            await util.Write(gen.LocatorMatLabel("Observações"), data.Observations, "write obs on input");
            await util.Click(gen.LocatorSpanText("Enviar"), "Click on send to choose date fund");
            await util.ValidateTextIsVisibleOnScreen("Registro inserido com sucesso, aguarde o processamento!", "Validate if message success returned is visible on screen to the user to back date of fund");

        }


    }
}
