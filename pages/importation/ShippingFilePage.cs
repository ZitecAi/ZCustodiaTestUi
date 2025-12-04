using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using zCustodiaUi.data.importation;
using zCustodiaUi.locators;
using zCustodiaUi.locators.Importation;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.importation
{
    public class ShippingFilePage
    {
        private readonly IPage page;
        Utils util;
        ShippingFileElements el = new ShippingFileElements();
        GenericElements gen = new GenericElements();
        private readonly ShippingFileData data = new ShippingFileData();

        string nameNewFile { get; set; }

        public ShippingFilePage(IPage page)
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


        public async Task SendShippingFile()
        {
            var today = DateTime.Now.Day.ToString();
            await util.Click(gen.ImportButton, "Click on Import button to import a new shipping file");
            await Task.Delay(2000);
            await util.Click("(" + gen.LocatorMatLabel("Fundo") + ")[2]", "Click on Fund Select to expand a Funds list");
            await Task.Delay(500);
            await util.Write(gen.Filter, data.FundName, "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption(data.FundName), "Click on fund option");
            await Task.Delay(1000);
            nameNewFile = await util.UpdateDateAndSentFile(GetPath() + data.FileName, gen.AttachFileInput, "Attaching a new shipping file");
            await Task.Delay(1000);
            await util.Click(el.ProcessButton, "Click on process button");
            await util.ValidateTextIsVisibleOnScreen("Arquivo importado com sucesso!", "Validate if success text is visible on screen to user after sended file");
            await Task.Delay(60000);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on fund selector to search fund");
            await Task.Delay(100);
            await util.Write(gen.Filter, data.FundName, "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption(data.FundName), "Click on fund option");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button");
            await Task.Delay(1000);
            var getId = await util.ValidateIfElementHaveValue(el.IdPositionOnTheTable(nameNewFile), "Validate if the file name is correct in the grid");
            await util.ValidateElementPresentOnTheTable(page, el.Table, nameNewFile, "Validate if the file name is correct in the grid");
            await util.Click(el.DeleteButton(nameNewFile), "Click on delete to Delete file");
            await util.Click(gen.LocatorSpanText(" Sim "), "Click on 'yes' to confirm Delete file");
            await util.ValidateTextIsVisibleOnScreen("Arquivo deletado com sucesso!", "Validate if success text is visible on screen to user after did deleted file");
            await page.ReloadAsync();
            await Task.Delay(500);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on Fund Select to expand a Funds list");
            await Task.Delay(100);
            await util.Write(gen.Filter, data.FundName, "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption(data.FundName), "Click on fund option");
            await util.Click(gen.LocatorSpanText("Pesquisar"), "Click on search button");
            await util.ValidateTextIsNotVisibleOnScreen(nameNewFile, "Validate if the file was don´t be present on table to validate if file was deleted on table");

        }


    }
}
