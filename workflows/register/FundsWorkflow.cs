using zCustodiaUi.pages.register;
using zCustodiaUi.data.register;

namespace zCustodiaUi.workflows.register
{
    public class FundsWorkflow
    {
        private readonly FundsPage _fundsPage;
        private readonly FundsData _data;

        public FundsWorkflow(FundsPage fundsPage, FundsData data = null)
        {
            _fundsPage = fundsPage;
            _data = data ?? new FundsData();
        }

        public async Task ExecuteStandardFlow(bool skipServiceProvider = false)
        {
            await _fundsPage.RegisterData();
            await _fundsPage.Rules();
            await _fundsPage.Representatives();
            await _fundsPage.Liquidation();
            await _fundsPage.FillAccountForm();
            await _fundsPage.AddAccount();
            await _fundsPage.Slack();
            await _fundsPage.FileValidation();

            if (!skipServiceProvider)
            {
                await _fundsPage.GoToForm("Prestadores de Serviços");
                await _fundsPage.RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator);
                await _fundsPage.RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2);
                await _fundsPage.RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3);
            }
        }

        public async Task ExecuteForValidation()
        {
            await _fundsPage.RegisterData();
            await _fundsPage.Rules();
            await _fundsPage.Representatives();
            await _fundsPage.Liquidation();
            await _fundsPage.FillAccountForm();
            await _fundsPage.AddAccount();
            await _fundsPage.Slack();
            await _fundsPage.FileValidation();
            await _fundsPage.GoToForm("Prestadores de Serviços");
            await _fundsPage.RegisterServiceProvider(_data.ProviderTypeAdministrator, _data.PersonTypeAdministrator);
            await _fundsPage.RegisterServiceProvider(_data.ProviderTypeManager, _data.PersonTypeManager, 2, 2);
            await _fundsPage.RegisterServiceProvider(_data.ProviderTypeConsultant, _data.PersonTypeConsultant, null, 3);
        }

        public async Task ExecuteForAccountValidation()
        {
            await _fundsPage.RegisterData();
            await _fundsPage.Rules();
            await _fundsPage.Representatives();
            await _fundsPage.Liquidation();
            await _fundsPage.FillAccountForm();
        }

        public async Task ExecuteForServiceProviderValidation()
        {
            await _fundsPage.RegisterData();
            await _fundsPage.Rules();
            await _fundsPage.Representatives();
            await _fundsPage.Liquidation();
            await _fundsPage.FillAccountForm();
            await _fundsPage.AddAccount();
            await _fundsPage.Slack();
            await _fundsPage.FileValidation();
            await _fundsPage.GoToForm("Prestadores de Serviços");
        }
    }
}
