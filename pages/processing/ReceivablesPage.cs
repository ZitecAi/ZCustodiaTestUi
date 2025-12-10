using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using zCustodiaUi.data.processing;
using zCustodiaUi.locators;
using zCustodiaUi.locators.processing;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.processing
{
    public class ReceivablesPage
    {
        private readonly IPage _page;
        Utils _util;
        ReceivablesElements _el = new ReceivablesElements();
        GenericElements _gen = new GenericElements();
        private readonly ReceivablesData _data = new ReceivablesData();

        public ReceivablesPage(IPage _page)
        {
            this._page = _page;
            _util = new Utils(_page);
        }

        public static string GetPath()
        {
            ConfigurationManager config = new ConfigurationManager();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            string path = config["Paths:Arquivo"].ToString();
            return path;
        }



        public async Task ProcessReceivablePartial()
        {
            await Task.Delay(2000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await _util.Write(_gen.Filter, _data.FundName, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await _util.Write(_gen.LocatorMatLabel("Seu Número"), _data.YourNumberPartial, "Write on your number field to Filter per your number");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await _util.Click(_el.SecondCheckBox, "Click on CheckBox");
            await Task.Delay(300);
            await _util.Click(_gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await _util.Write(_gen.Filter, _data.OccurrencePartial, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.OccurrencePartial), "Click on liquidation partial to select liquidation partial option");
            await _util.Write(_gen.LocatorMatLabel("Valor Liquidação"), _data.LiquidationValuePartial, "Write on value of liquidation ");
            await _page.Keyboard.PressAsync("Space");
            await _util.Click(_gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await _util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user after processed partial liquidation receivable");
            await Task.Delay(300);
            await _util.ValidateTextIsVisibleInElement(_el.StatusPositionOnTheTable, "Ativo", "Validate if status of Receivable is Ativo after did processing");
            // Do Delete Last movement


        }
        public async Task ProcessReceivable()
        {
            await Task.Delay(2000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await _util.Write(_gen.Filter, _data.FundName, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await _util.Write(_gen.LocatorMatLabel("Seu Número"), _data.YourNumber, "Write on your number field to Filter per your number");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await _util.Click(_el.SecondCheckBox, "Click on CheckBox");
            await _util.Click(_gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await _util.Write(_gen.Filter, _data.OccurrenceLow, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.OccurrenceLow), "Click on low to select low option");
            await _util.Write(_gen.LocatorMatLabel("Valor Liquidação"), _data.LiquidationValue, "Write on value of liquidation ");
            await _page.Keyboard.PressAsync("Space");
            await _util.Click(_gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await _util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user after processed liquidation receivable");
            await Task.Delay(300);
            await _util.ValidateTextIsVisibleInElement(_el.StatusPositionOnTheTable, "Inativo", "Validate if status of Receivable is Inativo after did processing");
            await _util.Click(_gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await _util.Write(_gen.Filter, _data.OccurrenceDeleteMovement, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.OccurrenceDeleteMovement), "Click on low to select low option");
            await _util.Click(_gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await _util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user");
            Console.WriteLine("Exclusão do Ultimo movimento efetuada com sucesso!!");
        }
        //PENDING PRORROGATION FLOW
        public async Task ProcessProrrogation()
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();

            await Task.Delay(2000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await _util.Write(_gen.Filter, _data.FundName, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await _util.Write(_gen.LocatorMatLabel("Seu Número"), _data.YourNumberProrrogation, "Write on your number field to Filter per your number");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await _util.Click(_el.SecondCheckBox, "Click on CheckBox");
            await _util.Click(_gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await _util.Write(_gen.Filter, _data.OccurrenceProrrogation, "Write on filter field to search Zitec FIDC");
            await _util.Click(_gen.ReceiveTypeOption(_data.OccurrenceProrrogation), "Click on low to select low option");
            await _util.Click("(" + _gen.Calendar + ")[3]", "Click on calendar to expand list days");
            await _util.Click(_gen.DayValue(tomorrow), "Click on day to select new due date");
            await _util.Click(_gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await _util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user after prorrogated tax");

        }
    }
}
