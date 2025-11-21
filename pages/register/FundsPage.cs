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
        private readonly Utils util;
        private readonly FundsElements el = new FundsElements();
        private readonly GenericElements gen = new GenericElements();
        private readonly FundsData data;
        private readonly IPage page;
        public FundsPage(IPage page, FundsData data = null)
        {
            this.page = page;
            this.data = data ?? new FundsData();
            util = new Utils(page);
        }






        public string Today => DateTime.Now.Day.ToString();
        public string Tomorrow => DateTime.Now.AddDays(1).Day.ToString();

        [AllureStep("Fill Register Data")]
        public async Task RegisterData()
        {
            string today = Today;

            //Register Data
            await util.Click(gen.ButtonNew, "Open New Fund form");
            await util.Write(gen.LocatorMatLabel("Fundo"), data.FundName, "Write Fund Name");
            await util.Write(gen.LocatorMatLabel("CNPJ"), data.CnpjFund, "Write CNPJ");
            await util.Write(gen.LocatorMatLabel("Código ISIN"), data.IsinCode, "Write ISIN Code");
            await util.Write(gen.LocatorMatLabel("Código ANBID"), data.AnbidCode, "Write ANBID Code");

            await util.Click(gen.LocatorMatLabel("Tipo Fundo"), "Write Type Fund");
            await util.Write(gen.Filter, data.FundType, "Write Type Fund");
            await util.Click(gen.ReceiveTypeOption(data.FundType), "Click on UF option");
            await util.Click(el.StartProcessingCalendar, "Open Start Processing Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            //await util.Write(gen.LocatorMatLabel("Nº CETIP"), data.CetipNumber, "Write CETIP Number");
            await util.Write(gen.LocatorMatLabel("N° SELIC"), data.SelicNumber, "Write CELIC Number");

            await util.Click(el.CvmRegisterCalendar, "Open CVM Register Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(gen.LocatorMatLabel("N° Sequencial CVM"), data.SequentialCvmNumber, "Write Sequential Number CVM");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Cheque"), "Scroll to element CheckSelect and keep it visible");
            await util.Click(gen.LocatorMatLabel("Lastro"), "Click Ballast Select");
            await util.Write(gen.Filter, data.Ballast, "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption(data.Ballast), "Click on UF option");
            await Task.Delay(100);

            await util.Click(gen.LocatorMatLabel("Código"), "Click Code Select");
            await util.Write(gen.Filter, data.Code, "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption(data.Code), "Click on UF option");
            await Task.Delay(100);

            await util.Click(gen.LocatorMatLabel("Cheque"), "Click Check Select");
            await util.Write(gen.Filter, data.CheckType, "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption(data.CheckType), "Click on UF option");
            await Task.Delay(100);

            // Fill mandatory additional fields
            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), "Scroll to NFe Key Receipt Deadline");
            await util.Write(gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), data.NFeKeyReceiptDeadline, "Write NFe Key Receipt Deadline");

            await util.Write(gen.LocatorMatLabel("Prazo Recepção do Lastro"), data.BallastReceiptDeadline, "Write Deadline Reception Ballast");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Perfil Liquidação Sistema de Ativos"), "Scroll to Profile Active System and maintain position");

            await util.Write(gen.LocatorMatLabel("Prazo PDD"), data.PddDeadline, "Write Deadline PDD");
            await util.Write(gen.LocatorMatLabel("Num. Sequencial Att Termo Cessão"), data.SequenceNumberTermCession, "Write Sequence Number Term Cession");
            await util.Write(gen.LocatorMatLabel("Num. Sequencial Att Termo Recompra"), data.SequenceNumberTermRepurchase, "Write Sequence Number Term Repurchase");
            await util.Write(gen.LocatorMatLabel("Qtd. Dias Retroagir Importação PL"), data.DaysImportPl, "Write Quantity Days Import PL");
            await util.Write(gen.LocatorMatLabel("Convênio"), data.Agreement, "Write Agreement");
            await util.Write(gen.LocatorMatLabel("Valor Máximo para o Robô Assinatura"), data.MaxValueRobot, "Write Max Value To Assign Robot");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Tipo Recebível"), "Scroll to Receive Type and maintain position");
            await Task.Delay(500);
            await util.Click(gen.LocatorMatLabel("Tipo Recebível"), "Click Receive Type");
            await util.Write(gen.Filter, data.ReceivableType, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.ReceivableType), "Click Receive Type Option");

            await util.Write(gen.LocatorMatLabel("Código Carteira"), data.WalletCode, "Write Wallet Code");
            await util.Write(gen.LocatorMatLabel("Ordem de Processamento"), data.ProcessOrder, "Write Process Order");
        }

        [AllureStep("Fill Rules")]
        public async Task Rules()
        {
            string today = Today;
            //Rules 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Regras"), "Scroll to Rules form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Regras"), "Click belt to change rules form");

            await util.Click(gen.LocatorMatLabel("Nome da Regra"), "Click on select to expand options of name rules");
            await util.Write(gen.Filter, data.RuleName, "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption(data.RuleName), "Click on UF option");

            await util.Click(el.RelationshipCalendar, "Click on relationship callendar to expand the callendar");
            await util.Click(gen.DayValue(today), "Click on tomorrow day to set relationship date");

            await util.Click(gen.LocatorMatLabel("Modelo de Precificação"), "Click to expand price model select");
            await util.Write(gen.Filter, data.PricingModel, "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption(data.PricingModel), "Click on UF option");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Aplica-se a"), "Click on select to expand options of apply to");
            await util.Write(gen.Filter, data.ApplyTo, "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption(data.ApplyTo), "Click on UF option");
        }

        [AllureStep("Fill Representatives")]
        public async Task Representatives()
        {
            //Representatives
            await util.Click(gen.TabAllForms("Representantes"), "Click belt to change form");

            await util.Click(gen.ButtonNew, "Click on button new to add new representative");

            await util.Click(gen.LocatorMatLabel("Nome"), "Click on the name representative input");
            await util.Write(gen.LocatorMatLabel("Nome"), data.RepresentativeName, "Write the name representative on input");

            await util.Write(gen.LocatorMatLabel("Email"), data.RepresentativeEmail, "insert email representative on input");

            await util.Write(gen.LocatorMatLabel("CPF"), data.RepresentativeCPF, "Write on the CPF representative input");
            await util.Write(gen.LocatorMatLabel("Telefone"), data.RepresentativeTelephone, "Write on the Tel input");

            await util.Click(el.AssignRadio(true), "Select 'yes' to assign");
            await util.Click(el.SignsByEndorsementRadio(true), "Select 'yes' to Signs By Endorsement");
            await util.Click(el.AssignTermRadio(true), "Select 'yes' to assign Term");
            await util.Click(el.IssuesDuplicateRadio(true), "Select 'yes' to Issue Duplicate");

            await util.Click(el.AddButton, "Click on add to add representative on fund");
        }

        [AllureStep("Fill Liquidation")]
        public async Task Liquidation()
        {
            //Liquidation 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Liquidação"), "Scroll to liquidation form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Liquidação"), "Click belt to change liquidation form");
            await Task.Delay(100);
            await util.Write(gen.LocatorMatLabel("Percentual Máximo Reembolso de Despesas %"), data.MaxPercent, "Set max percent of reimbursement");
        }

        [AllureStep("Fill Account")]
        public async Task Account(bool? isNegative = false)
        {
            //Account
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Conta Corrente"), "Scroll to account form");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Conta Corrente"), "Click belt to change account form");

            await util.Click(gen.ButtonNew, "Click on button new to insert a new Account");
            await Task.Delay(250);
            await util.Click(gen.LocatorMatLabel("Banco"), "Click on BankSelect button new to insert a new Bank");
            await util.Write(gen.Filter, data.Bank, "Write Name Bank");
            await util.Click(gen.ReceiveTypeOption(data.Bank), "Click Receive Type Option");
            await util.Write(gen.LocatorMatLabel("Número Agência"), data.AgencyNumber, "Write Number Agency");
            await util.Write(gen.LocatorMatLabel("Conta Corrente"), data.AccountNumber, "Write Number account");
            await util.Write(gen.LocatorMatLabel("Dígito"), data.AccountDigit, "Write Code account");
            await util.Click(el.PatternAccount(true), "Click on 'yes' to account pattern");
            await util.Click(el.MovementType("Movimentação"), "Click on Movement Type");
            await util.Write(gen.LocatorMatLabel("Descrição"), data.Description, "fill description of account test");
            if (isNegative is true)
            {
                return;
            }
            await util.Click(el.AddButton, "Click on Add Button to add a new account");
        }
        public async Task AccountWithoutType(bool? isNegative = false)
        {
            //Account
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Conta Corrente"), "Scroll to account form");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Conta Corrente"), "Click belt to change account form");

            await util.Click(gen.ButtonNew, "Click on button new to insert a new Account");
            await Task.Delay(250);
            await util.Click(gen.LocatorMatLabel("Banco"), "Click on BankSelect button new to insert a new Bank");
            await util.Write(gen.Filter, data.Bank, "Write Name Bank");
            await util.Click(gen.ReceiveTypeOption(data.Bank), "Click Receive Type Option");
            await util.Write(gen.LocatorMatLabel("Número Agência"), data.AgencyNumber, "Write Number Agency");
            await util.Write(gen.LocatorMatLabel("Conta Corrente"), data.AccountNumber, "Write Number account");
            await util.Write(gen.LocatorMatLabel("Dígito"), data.AccountDigit, "Write Code account");
            await util.Click(el.PatternAccount(true), "Click on 'yes' to account pattern");
            await util.Write(gen.LocatorMatLabel("Descrição"), data.Description, "fill description of account test");
            if (isNegative is true)
            {
                return;
            }
            await util.Click(el.AddButton, "Click on Add Button to add a new account");
        }

        [AllureStep("Fill Slack Data")]
        public async Task Slack()
        {
            //slack
            await util.ClickMatTabAsync(gen.TabAllForms("Slack"), "Click belt to change slack form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Slack Channel");

            await util.Write(gen.LocatorMatLabel("SlackWebhook Operações:"), data.OperationsWebhook, "Insert name of operations webhook");
            await util.Write(gen.LocatorMatLabel("Nome Canal Operações:"), data.OperationsChannelName, "Insert Name Of Channel Operations");
            await util.Write(gen.LocatorMatLabel("ID Canal Operações:"), data.OperationsChannelId, "Insert ID of Channel Operations");

            await util.Write(gen.LocatorMatLabel("SlackWebhook Lastros:"), data.BallastWebhook, "Insert name of operations webhook");
            await util.Write(gen.LocatorMatLabel("Nome Canal Lastros:"), data.BallastChannelName, "Insert Name Of Channel Operations");
            await util.Write(gen.LocatorMatLabel("ID Canal Lastros:"), data.BallastChannelId, "Insert ID of Channel Operations");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");
        }

        [AllureStep("Fill File Validation")]
        public async Task FileValidation()
        {
            //File Validation
            await util.ClickMatTabAsync(gen.TabAllForms("Validação Arquivo"), "Click belt to change file validation form");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Recebíveis Permitidos ao Fundo"), "Click on button new to Receives allow to fund");
            await util.Write(gen.Filter, data.ReceivableType, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.ReceivableType), "Click Duplicata Type Option");
            await page.Keyboard.PressAsync("Escape");
        }


        [AllureStep("Fill Represetatives")]
        public async Task GoToServicePrestatives()
        {
            //Prestadores d Servi�os
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await util.ClickMatTabAsync(gen.TabAllForms("Prestadores de Serviços"), "Click belt to change service prestatives form");


        }
        public async Task RegisterPrestativeAdministrator(bool lastFlow = false)
        {

            //administrator
            await Task.Delay(100);
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(100);
            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, data.ProviderTypeAdministrator, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.ProviderTypeAdministrator), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, data.PersonTypeAdministrator, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.PersonTypeAdministrator), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, data.ChargeType, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.ChargeType), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), data.FixedValue, "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");
            if (lastFlow is true)
            {
                await SaveFund();
            }
        }
        public async Task RegisterPrestativeManager(bool lastFlow = false)
        {
            //Manager
            await Task.Delay(100);
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, data.ProviderTypeManager, "Write Receive manager Type");
            await util.Click(gen.ReceiveTypeOption(data.ProviderTypeManager), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, data.PersonTypeManager, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.PersonTypeManager), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, data.ChargeType, "Write Receive Type");
            await util.Click("//div[@role='listbox']" + gen.ReceiveTypeOption(data.ChargeType), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), data.FixedValue, "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");
            if (lastFlow is true)
            {
                await SaveFund();
            }
        }
        public async Task RegisterPrestativeConsultant(bool lastFlow = false)
        {
            //Consultant
            await Task.Delay(100);
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, data.ProviderTypeConsultant, "Write Consultant Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.ProviderTypeConsultant), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, data.PersonTypeConsultant, "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption(data.PersonTypeConsultant), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, data.ChargeType, "Write Receive Type");
            await util.Click("//div[@role='listbox']" + gen.ReceiveTypeOption(data.ChargeType), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), data.FixedValue, "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");
            if (lastFlow is true)
            {
                await SaveFund();
            }

        }

        public async Task SaveFund()
        {
            await Task.Delay(1000);
            await util.Click(el.SaveButton, "Click on to add a new Fund!");
            await util.ValidateTextIsVisibleOnScreen(el.SuccessMessageRegisterNewFund, "Validate if success message is present on screen after all Flow finished");
        }
        public async Task SaveFundNegative(string expectedText)
        {
            await Task.Delay(1500);
            await util.Click(el.SaveButton, "Click on to add a new Fund!");
            await util.ValidateTextIsVisibleOnScreen(expectedText, "Validate if error message is present on screen after all Flow finished");
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
                    await GoToServicePrestatives();
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await util.ValidateElementIsDisabled(el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "ISIN code empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToServicePrestatives();
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await util.ValidateElementIsDisabled(el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "CNPJ already exists":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToServicePrestatives();
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
                    await GoToServicePrestatives();
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await util.ValidateElementIsDisabled(el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "Max Percent empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToServicePrestatives();
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeManager();
                    await RegisterPrestativeConsultant();
                    await util.ValidateElementIsDisabled(el.SaveButton, "Validate if Save Button is disabled with empty Fund Name");
                    break;
                case "Agency Number empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account(true);
                    await util.ValidateElementIsDisabled(el.AddButton, "Validate if Add Button is disabled with empty Fund Name");
                    break;
                case "Description account empty":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account(true);
                    await util.ValidateElementIsDisabled(el.AddButton, "Validate if Add Button is disabled with empty Fund Name");
                    break;
                case "Without Type Account":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await AccountWithoutType(true);
                    await util.ValidateElementIsDisabled(el.AddButton, "Validate if add Button is disabled with empty Fund Name");
                    break;
                case "Without Consultant":
                    await RegisterData();
                    await Rules();
                    await Representatives();
                    await Liquidation();
                    await Account();
                    await Slack();
                    await FileValidation();
                    await GoToServicePrestatives();
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
                    await GoToServicePrestatives();
                    await RegisterPrestativeAdministrator();
                    await RegisterPrestativeConsultant();
                    await SaveFundNegative("É obrigatório um 'Gestor' como prestador.");
                    break;

            }




        }

        public async Task ConsultFund()
        {


            await util.Write(el.SearchBar, data.FundName, "Write on filter input to find the fund created");
            await Task.Delay(1000);
            await util.ValidateElementPresentOnTheTable(page, el.FundTable, data.FundName, "Validate if Text is present on table to consult a existing fund");
        }

        public async Task UpdateFund()
        {

            await util.Write(el.SearchBar, data.FundName, "Write on filter input to find the fund created");
            await Task.Delay(600);
            await util.ValidateTextIsVisibleInElement(el.NameFundTable, data.FundName, "Validate if name fund is present on table");
            await util.Click(el.EditButton, "Click on Edit button to edit the Fund");
            //Make changes
            await util.Write(gen.LocatorMatLabel("Código ISIN"), data.EditedIsinCode, "Edit Code isin");
            await util.ScrollToElementAndMaintainPosition(el.ApplyChangesButton, "Scroll to Button apply changes");

            await util.Click(el.ApplyChangesButton, "Click on to save the Fund!");
            await util.ValidateReturnedMessageIsVisible(el.SuccessMessage, "Validate if success message is present on screen after fund updated");
        }

    }



}