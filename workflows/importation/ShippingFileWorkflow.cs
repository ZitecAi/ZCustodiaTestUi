using Microsoft.Playwright;
using zCustodiaUi.pages.importation;

namespace zCustodiaUi.workflows.importation
{
    public class ShippingFileWorkflow
    {
        private readonly ShippingFilePage _shippingFilePage;

        public ShippingFileWorkflow(ShippingFilePage shippingFilePage)
        {
            _shippingFilePage = shippingFilePage;
        }

        public async Task SendShippingFile()
        {
            await _shippingFilePage.SendShippingFile();
        }
    }
}
