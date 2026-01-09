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


        public async Task ClickImportButton()
        {
            await _util.Click(_gen.ImportButton, "Click on Import button to import a new shipping file");
        }

        public async Task SelectFund()
        {
            await _util.Click("(" + _gen.LocatorMatLabel("Fundo") + ")[2]", "Click on Fund Select to expand a Funds list");
            await _util.Write(_gen.Filter, _data.FundName, "Write name fund on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
        }

        public async Task AttachFile()
        {
            nameNewFile = await _util.UpdateDateAndSentFile(Utils.GetPath() + _data.FileName, _gen.AttachFileInput, "Attaching a new shipping file");
        }

        public async Task ClickProcessButton()
        {
            await _util.Click(_el.ProcessButton, "Click on process button");
        }

        public async Task ValidateSuccessImport()
        {
            await _util.ValidateTextIsVisibleOnScreen("Arquivo importado com sucesso!", "Validate if success text is visible on screen to user after sended file");
        }

        public async Task SearchFund()
        {
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on fund selector to search fund");
            await _util.Write(_gen.Filter, _data.FundName, "Write name fund on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), "Click on fund option");
        }

        public async Task ClickSearchButton()
        {
            await _util.Click(_gen.LocatorSpanText("Pesquisar"), "Click on search button");
        }

        public async Task ValidateFilePresentOnTable()
        {
            await Task.Delay(150);
            var getId = await _util.ValidateIfElementHaveValue(_el.IdPositionOnTheTable(nameNewFile), "Validate if file ID have vaue on table");
            await _util.ValidateElementPresentOnTheTable(_page, _el.Table, nameNewFile, "Validate if file name is correct in grid");
        }

        public async Task DeleteFile()
        {
            await _util.Click(_el.DeleteButton(nameNewFile), "Click on delete to Delete file");
        }

        public async Task ConfirmDelete()
        {
            await _util.Click(_gen.LocatorSpanText(" Sim "), "Click on 'yes' to confirm Delete file");
        }

        public async Task ValidateSuccessDelete()
        {
            await _util.ValidateTextIsVisibleOnScreen("Arquivo deletado com sucesso!", "Validate if success text is visible on screen to user after did deleted file");
        }

        public async Task ReloadPage()
        {
            await _page.ReloadAsync();
        }

        public async Task ValidateFileNotPresentOnTable()
        {
            await _util.ValidateTextIsNotVisibleOnScreen(nameNewFile, "Validate if the file was don´t be present on table to validate if file was deleted of table");
        }

        public async Task SendBillingFile()
        {
            var today = DateTime.Now.Day.ToString();
            await ClickImportButton();
            await SelectFund();
            await AttachFile();
            await ClickProcessButton();
            await ValidateSuccessImport();
            await SearchFund();
            await ClickSearchButton();
            await ValidateFilePresentOnTable();
            await DeleteFile();
            await ConfirmDelete();
            await ValidateSuccessDelete();
            await ReloadPage();
            await SearchFund();
            await ClickSearchButton();
            await ValidateFileNotPresentOnTable();
        }



    }
}




