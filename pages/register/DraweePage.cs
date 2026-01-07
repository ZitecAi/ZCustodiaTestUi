using Allure.NUnit.Attributes;
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
        private readonly DraweeData _data;

        public DraweePage(IPage _page, DraweeData data = null)
        {
            this._page = _page;
            _data = data ?? new DraweeData();
            _util = new Utils(_page);
        }

        public string Today => DateTime.Now.Day.ToString();
        public string Tomorrow => DateTime.Now.AddDays(1).Day.ToString();

        [AllureStep("Click on New Drawee Button")]
        public async Task ClickOnNewDraweeButton()
        {
            await _util.Click(_gen.LocatorSpanText("Novo Sacado"), "Click on new drawee button to register a new drawee");
        }

        [AllureStep("Fill Fund")]
        public async Task FillFund()
        {
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on select fund to expand list of funds");
            await _util.Write(_gen.Filter, _data.Fund, "Select Zitec FIDC to choose zitec fund");
            await _util.Click(_gen.LocatorSpanText(" Zitec FIDC "), "Select ZITEC FIDC");
        }

        [AllureStep("Fill Drawee Name")]
        public async Task FillDraweeName(string name)
        {
            await _util.Write(_gen.LocatorMatLabel("Nome"), name, "Write drawee name");
        }

        [AllureStep("Fill Email")]
        public async Task FillEmail()
        {
            await _util.Write(_gen.LocatorMatLabel("Email"), _data.Email, "Write drawee email");
        }

        [AllureStep("Fill CPF")]
        public async Task FillCPF()
        {
            await _util.Write(_gen.LocatorMatLabel("CPF"), _data.CPF, "Write drawee email");
        }

        [AllureStep("Fill Relationship Dates")]
        public async Task FillRelationshipDates(string startDate = null, string endDate = null)
        {
            startDate = startDate ?? Today;
            endDate = endDate ?? Tomorrow;

            await _util.Click(_el.CalendarStartRelationship, "Open Calendar Start Relationship");
            await _util.Click(_el.DayValue(startDate), "Select Start Date on calendar");
            await _util.Click(_el.CalendarEndRelationship, "Open Calendar End Relationship");
            await _util.Click(_el.DayValue(endDate), "Select End Date on calendar");
        }

        [AllureStep("Fill Annual Revenue")]
        public async Task FillAnnualRevenue()
        {
            await _util.Write(_gen.LocatorMatLabel("Faturamento anual"), _data.AnnualRevenue, "Write annual revenue");
            await _page.Keyboard.PressAsync("Space");
        }

        [AllureStep("Fill Economic Conglomerate")]
        public async Task FillEconomicConglomerate()
        {
            await _util.Write(_gen.LocatorMatLabel("Conglomerado Econômico"), _data.EconomicConglomerate, "Write drawee economic conglomerate");
        }

        [AllureStep("Fill Size")]
        public async Task FillSize()
        {
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Porte"), "Click on select size to expand options");
            await _util.Write(_gen.Filter, _data.Size, "Select size to choose option");
            await _util.Click(_gen.LocatorSpanText(" Microempreendedor Individual (MEI) "), "Select size option");
        }

        [AllureStep("Fill Risk Classification")]
        public async Task FillRiskClassification()
        {
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Classificação de Risco"), "Click on select risk classification to expand options");
            await _util.Write(_gen.Filter, _data.RiskClassification, "Select risk classification to choose option");
            await _util.Click(_gen.LocatorSpanText(" Baixo "), "Select low size option");
        }

        [AllureStep("Fill Society Type")]
        public async Task FillSocietyType()
        {
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Tipo de Sociedade"), "Click on society type to expand options");
            await _util.Write(_gen.Filter, _data.SocietyType, "Select society type to choose option");
            await _util.Click(_gen.LocatorSpanText(" LTDA "), "Select society type option");
        }

        [AllureStep("Fill State Registration")]
        public async Task FillStateRegistration()
        {
            await _util.Write(_gen.LocatorMatLabel("Inscrição Estadual"), _data.StateRegistration, "Write state registration");
        }

        [AllureStep("Fill Address")]
        public async Task FillAddress()
        {
            await _util.Write(_gen.LocatorMatLabel("CEP"), _data.PostalCode, "Write postal code");
            await _util.ValidateElementHaveValue(_el.NeighborhoodInput, "Validate if CEP returned address values");
            await _util.Write(_gen.LocatorMatLabel("Número"), _data.AddressNumber, "Write number adress on input number");
            await _util.Write(_gen.LocatorMatLabel("Telefone(DDD)"), _data.Telephone, "Write phone number on input");
        }

        [AllureStep("Click on Save Button")]
        public async Task ClickOnSaveButton()
        {
            await _util.Click(_gen.LocatorSpanText("Salvar"), "Click on save button to save drawee");
        }

        [AllureStep("Validate Success Message")]
        public async Task ValidateSuccessMessage()
        {
            await _util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success message is visible on screen");
        }

        [AllureStep("Filter and Validate Drawee")]
        public async Task FilterAndValidateDrawee(string nameDrawee)
        {
            await Task.Delay(1000);
            await FillFund();
            await Task.Delay(100);

            ILocator arrowLastRegistered = _page.Locator("//button" + _gen.LocatorMatIcon("last_page"));

            if (await arrowLastRegistered.IsEnabledAsync())
            {
                await _util.Click("//button" + _gen.LocatorMatIcon("last_page"), "Click on right arrow to navigate to next page of drawee list");
            }

            await Task.Delay(1500);
            await _util.ValidateElementPresentOnTheTable(_page, _el.DraweeTable, nameDrawee, "Validate if drawee name is visible on screen after created");
        }

        public async Task Register_Drawee()
        {
            var random = new Random();
            int uniqueNumber = random.Next(0, 9999);
            string draweeName = $"Sacado Test {uniqueNumber}";

            await ClickOnNewDraweeButton();
            await FillFund();
            await FillDraweeName(draweeName);
            await FillEmail();
            await FillCPF();
            await FillRelationshipDates();
            await FillAnnualRevenue();
            await FillEconomicConglomerate();
            await FillSize();
            await FillRiskClassification();
            await FillSocietyType();
            await FillStateRegistration();
            await FillAddress();
            await ClickOnSaveButton();
            await ValidateSuccessMessage();
            await FilterAndValidateDrawee(draweeName);
        }

    }
}
