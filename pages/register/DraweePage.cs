using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.Pages.register
{
    public class DraweePage
    {
        private readonly IPage _page;
        private readonly Utils _util;
        private readonly GenericElements _gen = new GenericElements();
        private readonly DraweeElements _el = new DraweeElements();
        private readonly DraweeData _data = new DraweeData();
        public DraweePage(IPage _page)
        {
            this._page = _page;
            _util = new Utils(_page);
        }

        public async Task Register_Drawee()
        {
            var today = DateTime.Now.Day.ToString();
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            Random random = new Random();
            int uniqueNumber = random.Next(0, 9999);

            await _util.Click(_gen.LocatorSpanText("Novo Sacado"), "Click on new drawee button to register a new drawee");
            //await Task.Delay(1000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on select fund to expand list of funds");
            await _util.Write(_gen.Filter, _data.Fund, "Select Zitec FIDC to choose zitec fund");
            await _util.Click(_gen.LocatorSpanText(" Zitec FIDC "), "Select ZITEC FIDC");

            await _util.Write(_gen.LocatorMatLabel("Nome"), $"Sacado Test {uniqueNumber}", "Write drawee name");
            await _util.Write(_gen.LocatorMatLabel("Email"), _data.Email, "Write drawee email");
            await _util.Write(_gen.LocatorMatLabel("CPF"), _data.CPF, "Write drawee email");

            await _util.Click(_el.CalendarStartRelationship, "Open Calendar Start Relationship");
            await _util.Click(_el.DayValue(today), "Select Today on calendar of start Relationship");
            await _util.Click(_el.CalendarEndRelationship, "Open Calendar End Relationship");
            await _util.Click(_el.DayValue(tomorrow), "Select Today on calendar of start Relationship");
            await _util.Write(_gen.LocatorMatLabel("Faturamento anual"), _data.AnnualRevenue, "Write annual revenue");
            await _page.Keyboard.PressAsync("Space");

            await _util.Write(_gen.LocatorMatLabel("Conglomerado Econômico"), _data.EconomicConglomerate, "Write drawee economic conglomerate");
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Porte"), "Click on select size to expand options");
            await _util.Write(_gen.Filter, _data.Size, "Select MEI to choose MEI");
            await _util.Click(_gen.LocatorSpanText(" Microempreendedor Individual (MEI) "), "Select large size option");
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Classificação de Risco"), "Click on select risk classification to expand options");
            await _util.Write(_gen.Filter, _data.RiskClassification, "Select low to choose low option");
            await _util.Click(_gen.LocatorSpanText(" Baixo "), "Select low size option");
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Tipo de Sociedade"), "Click on select risk classification to expand options");
            await _util.Write(_gen.Filter, _data.SocietyType, "Select low to choose low option");
            await _util.Click(_gen.LocatorSpanText(" LTDA "), "Select low size option");

            await _util.Write(_gen.LocatorMatLabel("Inscrição Estadual"), _data.StateRegistration, "Write state registration");

            await _util.Write(_gen.LocatorMatLabel("CEP"), _data.PostalCode, "Write postal code");
            await _util.ValidateElementHaveValue(_el.NeighborhoodInput, "Validate if CEP returned address values");
            await _util.Write(_gen.LocatorMatLabel("Número"), _data.AddressNumber, "Write number adress on input number");
            await _util.Write(_gen.LocatorMatLabel("Telefone(DDD)"), _data.Telephone, "Write phone number on input");

            await _util.Click(_gen.LocatorSpanText("Salvar"), "CLick on save button to save drawee");

            await _util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success message is visible on screen after did flow to register a new drawee");
            await Task.Delay(1000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on select fund to expand list of funds");
            await _util.Write(_gen.Filter, _data.Fund, "Select Zitec FIDC to choose zitec fund");
            await _util.Click(_gen.LocatorSpanText(" Zitec FIDC "), "Select ZITEC FIDC");
            await Task.Delay(100);

            string nameDrawee = $"Sacado Test {uniqueNumber}";

            ILocator arrowLastRegistered = _page.Locator("//button" + _gen.LocatorMatIcon("last_page"));

            if (await arrowLastRegistered.IsEnabledAsync())
            {
                await _util.Click("//button" + _gen.LocatorMatIcon("last_page"), "Click on right arrow to navigate to next _page of drawee list");
            }

            await Task.Delay(1500);
            await _util.ValidateElementPresentOnTheTable(_page, _el.DraweeTable, nameDrawee, "Validate if drawee name is visible on screen after created");

        }



    }
}
