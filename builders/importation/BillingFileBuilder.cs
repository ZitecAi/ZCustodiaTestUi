using zCustodiaUi.pages.importation;

namespace zCustodiaUi.builders.importation
{
    public class BillingFileBuilder : TestBuilder
    {
        private readonly BillingFilePage _billingFilePage;

        public BillingFileBuilder(BillingFilePage billingFilePage)
        {
            _billingFilePage = billingFilePage;
        }

        public BillingFileBuilder ClickImportButton()
        {
            AddStep(async () => await _billingFilePage.ClickImportButton());
            return this;
        }

        public BillingFileBuilder SelectFund()
        {
            AddStep(async () => await _billingFilePage.SelectFund());
            return this;
        }

        public BillingFileBuilder AttachFile()
        {
            AddStep(async () => await _billingFilePage.AttachFile());
            return this;
        }

        public BillingFileBuilder ClickProcessButton()
        {
            AddStep(async () => await _billingFilePage.ClickProcessButton());
            return this;
        }

        public BillingFileBuilder ValidateSuccessImport()
        {
            AddStep(async () => await _billingFilePage.ValidateSuccessImport());
            return this;
        }

        public BillingFileBuilder SearchFund()
        {
            AddStep(async () => await _billingFilePage.SearchFund());
            return this;
        }

        public BillingFileBuilder ClickSearchButton()
        {
            AddStep(async () => await _billingFilePage.ClickSearchButton());
            return this;
        }

        public BillingFileBuilder ValidateFilePresentOnTable()
        {
            AddStep(async () => await _billingFilePage.ValidateFilePresentOnTable());
            return this;
        }

        public BillingFileBuilder DeleteFile()
        {
            AddStep(async () => await _billingFilePage.DeleteFile());
            return this;
        }

        public BillingFileBuilder ConfirmDelete()
        {
            AddStep(async () => await _billingFilePage.ConfirmDelete());
            return this;
        }

        public BillingFileBuilder ValidateSuccessDelete()
        {
            AddStep(async () => await _billingFilePage.ValidateSuccessDelete());
            return this;
        }

        public BillingFileBuilder ReloadPage()
        {
            AddStep(async () => await _billingFilePage.ReloadPage());
            return this;
        }

        public BillingFileBuilder ValidateFileNotPresentOnTable()
        {
            AddStep(async () => await _billingFilePage.ValidateFileNotPresentOnTable());
            return this;
        }

        public BillingFileBuilder SendBillingFile()
        {
            AddStep(async () => await _billingFilePage.SendBillingFile());
            return this;
        }
    }
}
