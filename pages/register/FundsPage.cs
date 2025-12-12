using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class FundsPage
    {
        private readonly Utils _util;
        private readonly FundsElements _el = new FundsElements();
        private readonly GenericElements _gen = new GenericElements();
        private readonly FundsData _data;
        private readonly IPage _page;
        public FundsPage(IPage _page, FundsData _data = null)
        {
            this._page = _page;
            this._data = _data ?? new FundsData();
            _util = new Utils(_page);
        }

        public string Today => DateTime.Now.Day.ToString();
        public string Tomorrow => DateTime.Now.AddDays(1).Day.ToString();

        [AllureStep("Fill Register Data")]
        public async Task RegisterData()
        {
            string today = Today;

            //Register Data
            await _util.Click(_gen.ButtonNew, "Open New Fund form");
            await _util.Write(_gen.LocatorMatLabel("Fundo"), _data.FundName, "Write Fund Name");
            await _util.Write(_gen.LocatorMatLabel("CNPJ"), _data.CnpjFund, "Write CNPJ");
            await _util.Write(_gen.LocatorMatLabel("Código ISIN"), _data.IsinCode, "Write ISIN Code");
            await _util.Write(_gen.LocatorMatLabel("Código ANBID"), _data.AnbidCode, "Write ANBID Code");

            await _util.Click(_gen.LocatorMatLabel("Tipo Fundo"), "Write Type Fund");
            await _util.Write(_gen.Filter, _data.FundType, "Write Type Fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundType), "Click on UF option");
            await _util.Click(_el.StartProcessingCalendar, "Open Start Processing Calendar");
            await _util.Click(_gen.DayValue(today), "Set Today day on calendar");

            //await _util.Write(_gen.LocatorMatLabel("Nº CETIP"), _data.CetipNumber, "Write CETIP Number");
            await _util.Write(_gen.LocatorMatLabel("N° SELIC"), _data.SelicNumber, "Write CELIC Number");

            await _util.Click(_el.CvmRegisterCalendar, "Open CVM Register Calendar");
            await _util.Click(_gen.DayValue(today), "Set Today day on calendar");

            await _util.Write(_gen.LocatorMatLabel("N° Sequencial CVM"), _data.SequentialCvmNumber, "Write Sequential Number CVM");

            await _util.ScrollToElementAndMaintainPosition(_gen.LocatorMatLabel("Cheque"), "Scroll to element CheckSelect and keep it visible");
            await _util.Click(_gen.LocatorMatLabel("Lastro"), "Click Ballast Select");
            await _util.Write(_gen.Filter, _data.Ballast, "Write Aquisition Select");
            await _util.Click(_gen.ReceiveTypeOption(_data.Ballast), "Click on UF option");
            await Task.Delay(100);

            await _util.Click(_gen.LocatorMatLabel("Código"), "Click Code Select");
            await _util.Write(_gen.Filter, _data.Code, "Write Aquisition Select");
            await _util.Click(_gen.ReceiveTypeOption(_data.Code), "Click on UF option");
            await Task.Delay(100);

            await _util.Click(_gen.LocatorMatLabel("Cheque"), "Click Check Select");
            await _util.Write(_gen.Filter, _data.CheckType, "Write Aquisition Select");
            await _util.Click(_gen.ReceiveTypeOption(_data.CheckType), "Click on UF option");
            await Task.Delay(100);

            // Fill mandatory additional fields
            await _util.ScrollToElementAndMaintainPosition(_gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), "Scroll to NFe Key Receipt Deadline");
            await _util.Write(_gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), _data.NFeKeyReceiptDeadline, "Write NFe Key Receipt Deadline");

            await _util.Write(_gen.LocatorMatLabel("Prazo Recepção do Lastro"), _data.BallastReceiptDeadline, "Write Deadline Reception Ballast");

            await _util.ScrollToElementAndMaintainPosition(_gen.LocatorMatLabel("Perfil Liquidação Sistema de Ativos"), "Scroll to Profile Active System and maintain position");

            await _util.Write(_gen.LocatorMatLabel("Prazo PDD"), _data.PddDeadline, "Write Deadline PDD");
            await _util.Write(_gen.LocatorMatLabel("Num. Sequencial Att Termo Cessão"), _data.SequenceNumberTermCession, "Write Sequence Number Term Cession");
            await _util.Write(_gen.LocatorMatLabel("Num. Sequencial Att Termo Recompra"), _data.SequenceNumberTermRepurchase, "Write Sequence Number Term Repurchase");
            await _util.Write(_gen.LocatorMatLabel("Qtd. Dias Retroagir Importação PL"), _data.DaysImportPl, "Write Quantity Days Import PL");
            await _util.Write(_gen.LocatorMatLabel("Convênio"), _data.Agreement, "Write Agreement");
            await _util.Write(_gen.LocatorMatLabel("Valor Máximo para o Robô Assinatura"), _data.MaxValueRobot, "Write Max Value To Assign Robot");

            await _util.ScrollToElementAndMaintainPosition(_gen.LocatorMatLabel("Tipo Recebível"), "Scroll to Receive Type and maintain position");
            //await Task.Delay(500);
            await _util.Click(_gen.LocatorMatLabel("Tipo Recebível"), "Click Receive Type");
            await _util.Write(_gen.Filter, _data.ReceivableType, "Write Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.ReceivableType), "Click Receive Type Option");

            await _util.Write(_gen.LocatorMatLabel("Código Carteira"), _data.WalletCode, "Write Wallet Code");
            await _util.Write(_gen.LocatorMatLabel("Ordem de Processamento"), _data.ProcessOrder, "Write Process Order");
        }

        [AllureStep("Fill Rules")]
        public async Task Rules()
        {
            string today = Today;
            //Rules 
            await _util.ScrollToElementAndMaintainPosition(_gen.TabAllForms("Regras"), "Scroll to Rules form");
            //await Task.Delay(500);
            await _util.ClickMatTabAsync(_gen.TabAllForms("Regras"), "Click belt to change rules form");

            await _util.Click(_gen.LocatorMatLabel("Nome da Regra"), "Click on select to expand options of name rules");
            await _util.Write(_gen.Filter, _data.RuleName, "Write Aquisition Select");
            await _util.Click(_gen.ReceiveTypeOption(_data.RuleName), "Click on UF option");

            await _util.Click(_el.RelationshipCalendar, "Click on relationship callendar to expand the callendar");
            await _util.Click(_gen.DayValue(today), "Click on tomorrow day to set relationship date");

            await _util.Click(_gen.LocatorMatLabel("Modelo de Precificação"), "Click to expand price model select");
            await _util.Write(_gen.Filter, _data.PricingModel, "Write Aquisition Select");
            await _util.Click(_gen.ReceiveTypeOption(_data.PricingModel), "Click on UF option");
            await Task.Delay(150);
            await _util.Click(_gen.LocatorMatLabel("Aplica-se a"), "Click on select to expand options of apply to");
            await _util.Write(_gen.Filter, _data.ApplyTo, "Write Aquisition Select");
            await _util.Click(_gen.ReceiveTypeOption(_data.ApplyTo), "Click on UF option");
        }

        [AllureStep("Fill Representatives")]
        public async Task Representatives()
        {
            //Representatives
            await _util.Click(_gen.TabAllForms("Representantes"), "Click belt to change form");

            await _util.Click(_gen.ButtonNew, "Click on button new to add new representative");

            await _util.Click(_gen.LocatorMatLabel("Nome"), "Click on the name representative input");
            await _util.Write(_gen.LocatorMatLabel("Nome"), _data.RepresentativeName, "Write the name representative on input");

            await _util.Write(_gen.LocatorMatLabel("Email"), _data.RepresentativeEmail, "insert email representative on input");

            await _util.Write(_gen.LocatorMatLabel("CPF"), _data.RepresentativeCPF, "Write on the CPF representative input");
            await _util.Write(_gen.LocatorMatLabel("Telefone"), _data.RepresentativeTelephone, "Write on the Tel input");

            await _util.Click(_el.AssignRadio(true), "Select 'yes' to assign");
            await _util.Click(_el.SignsByEndorsementRadio(true), "Select 'yes' to Signs By Endorsement");
            await _util.Click(_el.AssignTermRadio(true), "Select 'yes' to assign Term");
            await _util.Click(_el.IssuesDuplicateRadio(true), "Select 'yes' to Issue Duplicate");

            await _util.Click(_el.AddButton, "Click on add to add representative on fund");
        }

        [AllureStep("Fill Liquidation")]
        public async Task Liquidation()
        {
            //Liquidation 
            await _util.ScrollToElementAndMaintainPosition(_gen.TabAllForms("Liquidação"), "Scroll to liquidation form");
            //await Task.Delay(500);
            await _util.ClickMatTabAsync(_gen.TabAllForms("Liquidação"), "Click belt to change liquidation form");
            //await Task.Delay(100);
            await _util.Write(_gen.LocatorMatLabel("Percentual Máximo Reembolso de Despesas %"), _data.MaxPercent, "Set max percent of reimbursement");
        }

        [AllureStep("Fill Account")]
        public async Task Account(bool? isNegative = false)
        {
            //Account
            await _util.ScrollToElementAndMaintainPosition(_gen.TabAllForms("Conta Corrente"), "Scroll to account form");
            await _util.Click(_gen.RightArrow, "Click on  Arrow to expand group tab");
            //await Task.Delay(500);
            await _util.ClickMatTabAsync(_gen.TabAllForms("Conta Corrente"), "Click belt to change account form");
            //await Task.Delay(250);
            await _util.Click(_gen.ButtonNew, "Click on button new to insert a new Account");
            //await Task.Delay(250);
            await _util.Click(_gen.LocatorMatLabel("Banco"), "Click on BankSelect button new to insert a new Bank");
            await _util.Write(_gen.Filter, _data.Bank, "Write Name Bank");
            await _util.Click(_gen.ReceiveTypeOption(_data.Bank), "Click Receive Type Option");
            await _util.Write(_gen.LocatorMatLabel("Número Agência"), _data.AgencyNumber, "Write Number Agency");
            await _util.Write(_gen.LocatorMatLabel("Conta Corrente"), _data.AccountNumber, "Write Number account");
            await _util.Write(_gen.LocatorMatLabel("Dígito"), _data.AccountDigit, "Write Code account");
            await _util.Click(_el.PatternAccount(true), "Click on 'yes' to account pattern");
            await _util.Click(_el.MovementType("Movimentação"), "Click on Movement Type");
            await _util.Write(_gen.LocatorMatLabel("Descrição"), _data.Description, "fill description of account test");
            if (isNegative is true)
            {
                return;
            }
            await _util.Click(_el.AddButton, "Click on Add Button to add a new account");
        }
        public async Task AccountWithoutType(bool? isNegative = false)
        {
            //Account
            await _util.ScrollToElementAndMaintainPosition(_gen.TabAllForms("Conta Corrente"), "Scroll to account form");
            await _util.Click(_gen.RightArrow, "Click on  Arrow to expand group tab");
            //await Task.Delay(500);
            await _util.ClickMatTabAsync(_gen.TabAllForms("Conta Corrente"), "Click belt to change account form");

            await _util.Click(_gen.ButtonNew, "Click on button new to insert a new Account");
            //await Task.Delay(250);
            await _util.Click(_gen.LocatorMatLabel("Banco"), "Click on BankSelect button new to insert a new Bank");
            await _util.Write(_gen.Filter, _data.Bank, "Write Name Bank");
            await _util.Click(_gen.ReceiveTypeOption(_data.Bank), "Click Receive Type Option");
            await _util.Write(_gen.LocatorMatLabel("Número Agência"), _data.AgencyNumber, "Write Number Agency");
            await _util.Write(_gen.LocatorMatLabel("Conta Corrente"), _data.AccountNumber, "Write Number account");
            await _util.Write(_gen.LocatorMatLabel("Dígito"), _data.AccountDigit, "Write Code account");
            await _util.Click(_el.PatternAccount(true), "Click on 'yes' to account pattern");
            await _util.Write(_gen.LocatorMatLabel("Descrição"), _data.Description, "fill description of account test");
            if (isNegative is true)
            {
                return;
            }
            await _util.Click(_el.AddButton, "Click on Add Button to add a new account");
        }

        [AllureStep("Fill Slack Data")]
        public async Task Slack()
        {
            //slack
            await _util.ClickMatTabAsync(_gen.TabAllForms("Slack"), "Click belt to change slack form");
            await _util.Click(_gen.ButtonNew, "Click on button new to insert a new Slack Channel");

            await _util.Write(_gen.LocatorMatLabel("SlackWebhook Operações:"), _data.OperationsWebhook, "Insert name of operations webhook");
            await _util.Write(_gen.LocatorMatLabel("Nome Canal Operações:"), _data.OperationsChannelName, "Insert Name Of Channel Operations");
            await _util.Write(_gen.LocatorMatLabel("ID Canal Operações:"), _data.OperationsChannelId, "Insert ID of Channel Operations");

            await _util.Write(_gen.LocatorMatLabel("SlackWebhook Lastros:"), _data.BallastWebhook, "Insert name of operations webhook");
            await _util.Write(_gen.LocatorMatLabel("Nome Canal Lastros:"), _data.BallastChannelName, "Insert Name Of Channel Operations");
            await _util.Write(_gen.LocatorMatLabel("ID Canal Lastros:"), _data.BallastChannelId, "Insert ID of Channel Operations");
            await _util.Click(_el.AddButton, "Click on Add Button to add a new account");
        }

        [AllureStep("Fill File Validation")]
        public async Task FileValidation()
        {
            //File Validation
            await _util.ClickMatTabAsync(_gen.TabAllForms("Validação Arquivo"), "Click belt to change file validation form");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Recebíveis Permitidos ao Fundo"), "Click on button new to Receives allow to fund");
            await _util.Write(_gen.Filter, _data.ReceivableType, "Write Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.ReceivableType), "Click Duplicata Type Option");
            await _page.Keyboard.PressAsync("Escape");
        }


        [AllureStep("Fill Represetatives")]
        public async Task GoToForm(string formName)
        {
            await _util.ClickMatTabAsync(_gen.TabAllForms(formName), "Click belt to change service prestatives form");
        }
        public async Task RegisterPrestativeAdministrator(bool lastFlow = false)
        {

            //administrator
            //await Task.Delay(100);
            await _util.Click(_gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(100);
            await _util.Click(_gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await _util.Write(_gen.Filter, _data.ProviderTypeAdministrator, "Write Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.ProviderTypeAdministrator), "Click Receive Type Option");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await _util.Write(_gen.Filter, _data.PersonTypeAdministrator, "Write Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.PersonTypeAdministrator), "Click Receive Type Option");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await _util.Write(_gen.Filter, _data.ChargeType, "Write Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.ChargeType), "Click Receive Type Option");
            await Task.Delay(500);
            await _util.Write(_gen.LocatorMatLabel("Valor Fixo"), _data.FixedValue, "Insert fixed value in new provider");
            await _page.Keyboard.PressAsync("Backspace");
            await _util.Click(_el.AddButton, "Click on add button to add new provider");
            if (lastFlow is true)
            {
                await SaveFund();
            }
        }
        public async Task RegisterPrestativeManager(bool lastFlow = false)
        {
            //Manager
            //await Task.Delay(100);
            await _util.Click(_gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await _util.Write(_gen.Filter, _data.ProviderTypeManager, "Write Receive manager Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.ProviderTypeManager), "Click Receive Type Option");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await _util.Write(_gen.Filter, _data.PersonTypeManager, "Write Receive Type");
            await _util.Click("(" + _gen.ReceiveTypeOption(_data.PersonTypeManager) + ")[2]", "Click Receive Type Option");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await _util.Write(_gen.Filter, _data.ChargeType, "Write Receive Type");
            await _util.Click("//div[@role='listbox']" + _gen.ReceiveTypeOption(_data.ChargeType), "Click Receive Type Option");
            await Task.Delay(500);
            await _util.Write(_gen.LocatorMatLabel("Valor Fixo"), _data.FixedValue, "Insert fixed value in new provider");
            await _page.Keyboard.PressAsync("Backspace");
            await _util.Click(_el.AddButton, "Click on add button to add new provider");
            if (lastFlow is true)
            {
                await SaveFund();
            }
        }
        public async Task RegisterPrestativeConsultant(bool lastFlow = false)
        {
            //Consultant
            //await Task.Delay(100);
            await _util.Click(_gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await _util.Write(_gen.Filter, _data.ProviderTypeConsultant, "Write Consultant Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.ProviderTypeConsultant), "Click Receive Type Option");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await _util.Write(_gen.Filter, _data.PersonTypeConsultant, "Write Receive Type");
            await _util.Click(_gen.ReceiveTypeOption(_data.PersonTypeConsultant), "Click Receive Type Option");
            await Task.Delay(500);

            await _util.Click(_gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await _util.Write(_gen.Filter, _data.ChargeType, "Write Receive Type");
            await _util.Click("//div[@role='listbox']" + _gen.ReceiveTypeOption(_data.ChargeType), "Click Receive Type Option");
            await Task.Delay(500);
            await _util.Write(_gen.LocatorMatLabel("Valor Fixo"), _data.FixedValue, "Insert fixed value in new provider");
            await _page.Keyboard.PressAsync("Backspace");
            await _util.Click(_el.AddButton, "Click on add button to add new provider");
            if (lastFlow is true)
            {
                await SaveFund();
            }
        }

        public async Task SaveFund()
        {
            //await Task.Delay(1000);
            await _util.Click(_el.SaveButton, "Click on to add a new Fund!");
            await _util.ValidateTextIsVisibleOnScreen(_el.SuccessMessageRegisterNewFund, "Validate if success message is present on screen after all Flow finished");
        }
        public async Task SaveFundNegative(string expectedText)
        {
            await Task.Delay(1500);
            await _util.Click(_el.SaveButton, "Click on to add a new Fund!");
            await _util.ValidateTextIsVisibleOnScreen(expectedText, "Validate if error message is present on screen after all Flow finished");
        }

        public async Task NegativeScenario(string testCase)
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();

            switch (testCase)
            {
                case "Fund name empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await _util.ValidateElementIsDisabled(_el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "ISIN code empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await _util.ValidateElementIsDisabled(_el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "CNPJ already exists":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await SaveFundNegative("Fundo já existente para o CNPJ '54638076000176'.");
                    break;
                case "CNPJ empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await _util.ValidateElementIsDisabled(_el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "Max Percent empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await _util.ValidateElementIsDisabled(_el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "Agency Number empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account(true);
                    await _util.ValidateElementIsDisabled(_el.AddButton, "Validate if Add Button is disabled with empty Fund Name");
                    break;
                case "Description account empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account(true);
                    await _util.ValidateElementIsDisabled(_el.AddButton, "Validate if Add Button is disabled with empty Fund Name");
                    break;
                case "Without Type Account":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await AccountWithoutType(true);
                    await _util.ValidateElementIsDisabled(_el.AddButton, "Validate if add Button is disabled with empty Fund Name");
                    break;
                case "Without Consultant":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await SaveFundNegative("É obrigatório um 'Consultor' como prestador.");
                    break;
                case "Without Manager":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToForm("Prestadores de Serviços");
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeConsultant();
                    await SaveFundNegative("É obrigatório um 'Gestor' como prestador.");
                    break;

            }




        }

        public async Task ConsultFund()
        {


            await _util.Write(_el.SearchBar, _data.FundName, "Write on filter input to find the fund created");
            await Task.Delay(1000);
            await _util.ValidateElementPresentOnTheTable(_page, _el.FundTable, _data.FundName, "Validate if Text is present on table to consult a existing fund");
        }

        public async Task UpdateFund()
        {

            await _util.Write(_el.SearchBar, _data.FundName, "Write on filter input to find the fund created");
            await Task.Delay(600);
            await _util.ValidateTextIsVisibleInElement(_el.NameFundTable, _data.FundName, "Validate if name fund is present on table");
            await _util.Click(_el.EditButton, "Click on Edit button to edit the Fund");
            //Make changes
            await _util.Write(_gen.LocatorMatLabel("Código ISIN"), _data.EditedIsinCode, "Edit Code isin");
            await _util.ScrollToElementAndMaintainPosition(_el.ApplyChangesButton, "Scroll to Button apply changes");

            await _util.Click(_el.ApplyChangesButton, "Click on to save the Fund!");
            await _util.ValidateReturnedMessageIsVisible(_el.SuccessMessage, "Validate if success message is present on screen after fund updated");
        }

    }
}