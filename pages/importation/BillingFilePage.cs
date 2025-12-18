using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using zCustodiaUi.data.importation;
using zCustodiaUi.locators;
using zCustodiaUi.locators.Importation;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.importation
{
    public class BillingFilePage
    {
        private readonly IPage _page;
        Utils _util;
        BillingFileElements _el = new BillingFileElements();
        GenericElements _gen = new GenericElements();
        private readonly BillingFileData _data = new BillingFileData();

        string nameNewFile { get; set; }

        public BillingFilePage(IPage _page)
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

        public async Task SendBillingFile()
        {
            var today = DateTime.Now.Day.ToString();
            await _util.Click(_gen.ImportButton, "Click on Import button to import a new shipping file");
            await _util.Click("(" + _gen.LocatorMatLabel("Fundo") + ")[2]", "Click on Fund Select to expand a Funds list");
            await _util.Write(_gen.Filter, _data.FundName, "Write name fund on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
            nameNewFile = await _util.UpdateDateAndSentFile(GetPath() + _data.FileName, _gen.AttachFileInput, "Attaching a new shipping file");
            await _util.Click(_el.ProcessButton, "Click on process button");
            await _util.ValidateTextIsVisibleOnScreen("Arquivo importado com sucesso!", "Validate if success text is visible on screen to user after sended file");
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on fund selector to search fund");
            await _util.Write(_gen.Filter, _data.FundName, "Write name fund on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button");
            await Task.Delay(150);
            var getId = await _util.ValidateIfElementHaveValue(_el.IdPositionOnTheTable(nameNewFile), "Validate if the file ID have vaue on the table");
            await _util.ValidateElementPresentOnTheTable(_page, _el.Table, nameNewFile, "Validate if the file name is correct in the grid");
            await _util.Click(_el.DeleteButton(nameNewFile), "Click on delete to Delete file");
            await _util.Click(_gen.LocatorSpanText(" Sim "), "Click on 'yes' to confirm Delete file");
            await _util.ValidateTextIsVisibleOnScreen("Arquivo deletado com sucesso!", "Validate if success text is visible on screen to user after did deleted file");
            await _page.ReloadAsync();
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on Fund Select to expand a Funds list");
            await _util.Write(_gen.Filter, _data.FundName, "Write name fund on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button");
            await _util.ValidateTextIsNotVisibleOnScreen(nameNewFile, "Validate if the file was don´t be present on table to validate if file was deleted of table");
        }


    }
}
