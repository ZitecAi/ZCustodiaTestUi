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
        private readonly IPage _page;
        Utils _util;
        ShippingFileElements _el = new ShippingFileElements();
        GenericElements _gen = new GenericElements();
        private readonly ShippingFileData _data = new ShippingFileData();

        string nameNewFile { get; set; }

        public ShippingFilePage(IPage _page)
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


        public async Task SendShippingFile()
        {
            var today = DateTime.Now.Day.ToString();
            await _util.Click(_gen.ImportButton, "Click on Import button to import a new shipping file");
            await Task.Delay(2000);
            await _util.Click("(" + _gen.LocatorMatLabel("Fundo") + ")[2]", "Click on Fund Select to expand a Funds list");
            await Task.Delay(500);
            await _util.Write(_gen.Filter, _data.FundName, "Click on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
            await Task.Delay(1000);
            nameNewFile = await _util.UpdateDateAndSentFile(GetPath() + _data.FileName, _gen.AttachFileInput, "Attaching a new shipping file");
            await Task.Delay(1000);
            await _util.Click(_el.ProcessButton, "Click on process button");
            await _util.ValidateTextIsVisibleOnScreen("Arquivo importado com sucesso!", "Validate if success text is visible on screen to user after sended file");
            await Task.Delay(60000);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on fund selector to search fund");
            await Task.Delay(100);
            await _util.Write(_gen.Filter, _data.FundName, "Click on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button");
            await Task.Delay(1000);
            var getId = await _util.ValidateIfElementHaveValue(_el.IdPositionOnTheTable(nameNewFile), "Validate if the file name is correct in the grid");
            await _util.ValidateElementPresentOnTheTable(_page, _el.Table, nameNewFile, "Validate if the file name is correct in the grid");
            await _util.Click(_el.DeleteButton(nameNewFile), "Click on delete to Delete file");
            await _util.Click(_gen.LocatorSpanText(" Sim "), "Click on 'yes' to confirm Delete file");
            await _util.ValidateTextIsVisibleOnScreen("Arquivo deletado com sucesso!", "Validate if success text is visible on screen to user after did deleted file");
            await _page.ReloadAsync();
            await Task.Delay(500);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on Fund Select to expand a Funds list");
            await Task.Delay(100);
            await _util.Write(_gen.Filter, _data.FundName, "Click on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button");
            await _util.ValidateTextIsNotVisibleOnScreen(nameNewFile, "Validate if the file was don´t be present on table to validate if file was deleted on table");

        }


    }
}
