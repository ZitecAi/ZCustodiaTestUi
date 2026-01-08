using zCustodiaUi.pages.importation;

namespace zCustodiaUi.builders.importation
{
    public class ShippingFileBuilder : TestBuilder
    {
        private readonly ShippingFilePage _shippingFilePage;

        public ShippingFileBuilder(ShippingFilePage shippingFilePage)
        {
            _shippingFilePage = shippingFilePage;
        }

        public ShippingFileBuilder ClickImportButton()
        {
            AddStep(async () => await _shippingFilePage.ClickImportButton());
            return this;
        }

        public ShippingFileBuilder SelectFund()
        {
            AddStep(async () => await _shippingFilePage.SelectFund());
            return this;
        }

        public ShippingFileBuilder AttachFile()
        {
            AddStep(async () => await _shippingFilePage.AttachFile());
            return this;
        }

        public ShippingFileBuilder ClickProcessButton()
        {
            AddStep(async () => await _shippingFilePage.ClickProcessButton());
            return this;
        }

        public ShippingFileBuilder ValidateSuccessImport()
        {
            AddStep(async () => await _shippingFilePage.ValidateSuccessImport());
            return this;
        }

        public ShippingFileBuilder SearchFund()
        {
            AddStep(async () => await _shippingFilePage.SearchFund());
            return this;
        }

        public ShippingFileBuilder ClickSearchButton()
        {
            AddStep(async () => await _shippingFilePage.ClickSearchButton());
            return this;
        }

        public ShippingFileBuilder ValidateFilePresentOnTable()
        {
            AddStep(async () => await _shippingFilePage.ValidateFilePresentOnTable());
            return this;
        }

        public ShippingFileBuilder DeleteFile()
        {
            AddStep(async () => await _shippingFilePage.DeleteFile());
            return this;
        }

        public ShippingFileBuilder ConfirmDelete()
        {
            AddStep(async () => await _shippingFilePage.ConfirmDelete());
            return this;
        }

        public ShippingFileBuilder ValidateSuccessDelete()
        {
            AddStep(async () => await _shippingFilePage.ValidateSuccessDelete());
            return this;
        }

        public ShippingFileBuilder ReloadPage()
        {
            AddStep(async () => await _shippingFilePage.ReloadPage());
            return this;
        }

        public ShippingFileBuilder ValidateFileNotPresentOnTable()
        {
            AddStep(async () => await _shippingFilePage.ValidateFileNotPresentOnTable());
            return this;
        }

        public ShippingFileBuilder SendShippingFile()
        {
            AddStep(async () => await _shippingFilePage.SendShippingFile());
            return this;
        }
    }
}
