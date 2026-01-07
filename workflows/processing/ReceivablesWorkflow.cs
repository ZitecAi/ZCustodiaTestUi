using Microsoft.Playwright;
using zCustodiaUi.pages.processing;

namespace zCustodiaUi.workflows.processing
{
    public class ReceivablesWorkflow
    {
        private readonly ReceivablesPage _receivablesPage;

        public ReceivablesWorkflow(ReceivablesPage receivablesPage)
        {
            _receivablesPage = receivablesPage;
        }

        public async Task ProcessReceivablePartial()
        {
            await _receivablesPage.ProcessReceivablePartial();
        }

        public async Task ProcessReceivable()
        {
            await _receivablesPage.ProcessReceivable();
        }

        public async Task ProcessProrrogation()
        {
            await _receivablesPage.ProcessProrrogation();
        }
    }
}
