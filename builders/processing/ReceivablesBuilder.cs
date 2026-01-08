using zCustodiaUi.pages.processing;

namespace zCustodiaUi.builders.processing
{
    public class ReceivablesBuilder : TestBuilder
    {
        private readonly ReceivablesPage _receivablesPage;

        public ReceivablesBuilder(ReceivablesPage receivablesPage)
        {
            _receivablesPage = receivablesPage;
        }

        public ReceivablesBuilder ProcessReceivablePartial()
        {
            AddStep(async () => await _receivablesPage.ProcessReceivablePartial());
            return this;
        }

        public ReceivablesBuilder ProcessReceivable()
        {
            AddStep(async () => await _receivablesPage.ProcessReceivable());
            return this;
        }

        public ReceivablesBuilder ProcessProrrogation()
        {
            AddStep(async () => await _receivablesPage.ProcessProrrogation());
            return this;
        }
    }
}
