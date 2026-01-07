using Microsoft.Playwright;
using zCustodiaUi.pages.importation;

namespace zCustodiaUi.workflows.importation
{
    public class BillingFileWorkflow
    {
        private readonly BillingFilePage _billingFilePage;

        public BillingFileWorkflow(BillingFilePage billingFilePage)
        {
            _billingFilePage = billingFilePage;
        }

        public async Task SendBillingFile()
        {
            await _billingFilePage.SendBillingFile();
        }
    }
}
