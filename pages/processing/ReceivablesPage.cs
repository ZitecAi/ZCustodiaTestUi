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
        private readonly IPage page;
        Utils util;
        ReceivablesElements el = new ReceivablesElements();
        GenericElements gen = new GenericElements();
        private readonly ReceivablesData data = new ReceivablesData();

        public ReceivablesPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
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
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await util.Write(gen.Filter, data.FundName, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.FundName), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await util.Write(gen.LocatorMatLabel("Seu Número"), data.YourNumberPartial, "Write on your number field to Filter per your number");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await util.Click(el.SecondCheckBox, "Click on CheckBox");
            await Task.Delay(300);
            await util.Click(gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await util.Write(gen.Filter, data.OccurrencePartial, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.OccurrencePartial), "Click on liquidation partial to select liquidation partial option");
            await util.Write(gen.LocatorMatLabel("Valor Liquidação"), data.LiquidationValuePartial, "Write on value of liquidation ");
            await page.Keyboard.PressAsync("Space");
            await util.Click(gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user after processed partial liquidation receivable");
            await Task.Delay(300);
            await util.ValidateTextIsVisibleInElement(el.StatusPositionOnTheTable, "Ativo", "Validate if status of Receivable is Ativo after did processing");
            // Do Delete Last movement


        }
        public async Task ProcessReceivable()
        {
            await Task.Delay(2000);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await util.Write(gen.Filter, data.FundName, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.FundName), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await util.Write(gen.LocatorMatLabel("Seu Número"), data.YourNumber, "Write on your number field to Filter per your number");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await util.Click(el.SecondCheckBox, "Click on CheckBox");
            await util.Click(gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await util.Write(gen.Filter, data.OccurrenceLow, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.OccurrenceLow), "Click on low to select low option");
            await util.Write(gen.LocatorMatLabel("Valor Liquidação"), data.LiquidationValue, "Write on value of liquidation ");
            await page.Keyboard.PressAsync("Space");
            await util.Click(gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user after processed liquidation receivable");
            await Task.Delay(300);
            await util.ValidateTextIsVisibleInElement(el.StatusPositionOnTheTable, "Inativo", "Validate if status of Receivable is Inativo after did processing");
            await util.Click(gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await util.Write(gen.Filter, data.OccurrenceDeleteMovement, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.OccurrenceDeleteMovement), "Click on low to select low option");
            await util.Click(gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user");
            Console.WriteLine("Exclusão do Ultimo movimento efetuada com sucesso!!");
        }
        //PENDING PRORROGATION FLOW
        public async Task ProcessProrrogation()
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();

            await Task.Delay(2000);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on New button to create a new receivable");
            await util.Write(gen.Filter, data.FundName, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.FundName), "Click on Zitec FIDC to create select Zitec FIDC fund");
            await util.Write(gen.LocatorMatLabel("Seu Número"), data.YourNumberProrrogation, "Write on your number field to Filter per your number");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button to search receivable");
            //await util.Click(el.SecondCheckBox, "Click on CheckBox");
            await util.Click(gen.LocatorMatLabel("Ocorrência"), "Click on Add button to add the receivable");
            await util.Write(gen.Filter, data.OccurrenceProrrogation, "Write on filter field to search Zitec FIDC");
            await util.Click(gen.ReceiveTypeOption(data.OccurrenceProrrogation), "Click on low to select low option");
            await util.Click("(" + gen.Calendar + ")[3]", "Click on calendar to expand list days");
            await util.Click(gen.DayValue(tomorrow), "Click on day to select new due date");
            await util.Click(gen.LocatorSpanText("Processar"), "Click on Process to do low");
            await util.ValidateTextIsVisibleOnScreen("Dados Processados com Sucesso!", "Validate if success text is visible on screen to user after prorrogated tax");

        }
    }
}
