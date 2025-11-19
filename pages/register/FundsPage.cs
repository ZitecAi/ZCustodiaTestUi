using Microsoft.Playwright;
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
        private readonly IPage page;
        public FundsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        string fundName = "ZitecQa";
        string cnpjFund = DataGenerator.Generate(DocumentType.Cnpj);

        public async Task RegisterNewFund()
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();


            //Register Data
            await util.Click(gen.ButtonNew, "Open New Fund form");
            await util.Write(gen.LocatorMatLabel("Fundo"), fundName, "Write Fund Name");
            await util.Write(gen.LocatorMatLabel("CNPJ"), cnpjFund, "Write CNPJ");
            await util.Write(gen.LocatorMatLabel("Código ISIN"), "000000000000130", "Write ISIN Code");
            await util.Write(gen.LocatorMatLabel("Código ANBID"), "1234567890", "Write ANBID Code");

            await util.Click(gen.LocatorMatLabel("Tipo Fundo"), "Write Type Fund");
            await util.Write(gen.Filter, "Direitos Creditórios", "Write Type Fund");
            await util.Click(gen.ReceiveTypeOption("Direitos Creditórios"), "Click on UF option");
            await util.Click(el.StartProcessingCalendar, "Open Start Processing Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(gen.LocatorMatLabel("N° CETIP"), "12345678", "Write CETIP Number");
            await util.Write(gen.LocatorMatLabel("N° SELIC"), "123456789", "Write CELIC Number");

            await util.Click(el.CvmRegisterCalendar, "Open CVM Register Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(gen.LocatorMatLabel("N° Sequencial CVM"), "2536789811", "Write Sequential Number CVM");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Cheque"), "Scroll to element CheckSelect and keep it visible");
            await util.Click(gen.LocatorMatLabel("Lastro"), "Click Ballast Select");
            await util.Write(gen.Filter, "Clube", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("Clube"), "Click on UF option");
            await Task.Delay(100);

            await util.Click(gen.LocatorMatLabel("Código"), "Click Code Select");
            await util.Write(gen.Filter, "1", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("1"), "Click on UF option");
            await Task.Delay(100);

            await util.Click(gen.LocatorMatLabel("Cheque"), "Click Check Select");
            await util.Write(gen.Filter, "CNAB160 - Retorno de Cheque", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("CNAB160 - Retorno de Cheque"), "Click on UF option");
            await Task.Delay(100);

            // Fill mandatory additional fields
            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), "Scroll to NFe Key Receipt Deadline");
            await util.Write(gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), "5", "Write NFe Key Receipt Deadline");

            await util.Write(gen.LocatorMatLabel("Prazo Recepção do Lastro"), "5", "Write Deadline Reception Ballast");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Perfil Liquidação Sistema de Ativos"), "Scroll to Profile Active System and maintain position");

            await util.Write(gen.LocatorMatLabel("Prazo PDD"), "0", "Write Deadline PDD");
            await util.Write(gen.LocatorMatLabel("Num. Sequencial Att Termo Cessão"), "1001", "Write Sequence Number Term Cession");
            await util.Write(gen.LocatorMatLabel("Num. Sequencial Att Termo Recompra"), "1002", "Write Sequence Number Term Repurchase");
            await util.Write(gen.LocatorMatLabel("Qtd. Dias Retroagir Importação PL"), "10", "Write Quantity Days Import PL");
            await util.Write(gen.LocatorMatLabel("Convênio"), "12345", "Write Agreement");
            await util.Write(gen.LocatorMatLabel("Valor Máximo para o Robô Assinatura"), "10000", "Write Max Value To Assign Robot");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Tipo Recebível"), "Scroll to Receive Type and maintain position");
            await Task.Delay(500);
            await util.Click(gen.LocatorMatLabel("Tipo Recebível"), "Click Receive Type");
            await util.Write(gen.Filter, "Duplicata", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Duplicata"), "Click Receive Type Option");

            await util.Write(gen.LocatorMatLabel("Código Carteira"), "001", "Write Wallet Code");
            await util.Write(gen.LocatorMatLabel("Ordem de Processamento"), "99999", "Write Process Order");


            //Rules 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Regras"), "Scroll to Rules form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Regras"), "Click belt to change rules form");

            await util.Click(gen.LocatorMatLabel("Nome da Regra"), "Click on select to expand options of name rules");
            await util.Write(gen.Filter, "ACELERA", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("ACELERA"), "Click on UF option");

            await util.Click(el.RelationshipCalendar, "Click on relationship callendar to expand the callendar");
            await util.Click(gen.DayValue(today), "Click on tomorrow day to set relationship date");

            await util.Click(gen.LocatorMatLabel("Modelo de Precificação"), "Click to expand price model select");
            await util.Write(gen.Filter, "Por recebível", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("Por recebível"), "Click on UF option");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Aplica-se a"), "Click on select to expand options of apply to");
            await util.Write(gen.Filter, "Toda carteira", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("Toda carteira"), "Click on UF option");

            //Representatives
            await util.Click(gen.TabAllForms("Representantes"), "Click belt to change form");

            await util.Click(gen.ButtonNew, "Click on button new to add new representative");

            await util.Click(gen.LocatorMatLabel("Nome"), "Click on the name representative input");
            await util.Write(gen.LocatorMatLabel("Nome"), "Representante Teste", "Write the name representative on input");

            await util.Write(gen.LocatorMatLabel("Email"), "teste@email.com", "insert email representative on input");

            await util.Write(gen.LocatorMatLabel("CPF"), "40956114806", "Write on the CPF representative input");
            await util.Write(gen.LocatorMatLabel("Telefone"), "11934125767", "Write on the Tel input");

            await util.Click(el.AssignRadio(true), "Select 'yes' to assign");
            await util.Click(el.SignsByEndorsementRadio(true), "Select 'yes' to Signs By Endorsement");
            await util.Click(el.AssignTermRadio(true), "Select 'yes' to assign Term");
            await util.Click(el.IssuesDuplicateRadio(true), "Select 'yes' to Issue Duplicate");

            await util.Click(el.AddButton, "Click on add to add representative on fund");

            //Liquidation 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Liquidação"), "Scroll to liquidation form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Liquidação"), "Click belt to change liquidation form");

            await util.Write(gen.LocatorMatLabel("Percentual Máximo Reembolso de Despesas %"), "10", "Set max percent of reimbursement");

            //Account
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Conta Corrente"), "Scroll to account form");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Conta Corrente"), "Click belt to change account form");

            await util.Click(gen.ButtonNew, "Click on button new to insert a new Account");
            await Task.Delay(250);
            await util.Click(gen.LocatorMatLabel("Banco"), "Click on BankSelect button new to insert a new Bank");
            await util.Write(gen.Filter, "439 - ID CTVM", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("439 - ID CTVM"), "Click Receive Type Option");
            await util.Write(gen.LocatorMatLabel("Número Agência"), "1", "Write Number Agency");
            await util.Write(gen.LocatorMatLabel("Conta Corrente"), "46677", "Write Number account");
            await util.Write(gen.LocatorMatLabel("Dígito"), "3", "Write Code account");
            await util.Click(el.PatternAccount(true), "Click on 'yes' to account pattern");
            await util.Click(el.MovementType("Movimentação"), "Click on Movement Type");
            await util.Write(gen.LocatorMatLabel("Descrição"), "Conta para fundo de teste", "fill description of account test");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");
            //await util.Click(gen.RightArrow, "Click on Arrow to expand group tab");
            //await util.Click(gen.RightArrow, "Click on Arrow to expand group tab");


            //slack
            await util.ClickMatTabAsync(gen.TabAllForms("Slack"), "Click belt to change slack form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Slack Channel");

            await util.Write(gen.LocatorMatLabel("SlackWebhook Operações:"), "WebHook Test", "Insert name of operations webhook");
            await util.Write(gen.LocatorMatLabel("Nome Canal Operações:"), "Channel Test", "Insert Name Of Channel Operations");
            await util.Write(gen.LocatorMatLabel("ID Canal Operações:"), "01", "Insert ID of Channel Operations");

            await util.Write(gen.LocatorMatLabel("SlackWebhook Lastros:"), "WebHook Test", "Insert name of operations webhook");
            await util.Write(gen.LocatorMatLabel("Nome Canal Lastros:"), "Channel Test", "Insert Name Of Channel Operations");
            await util.Write(gen.LocatorMatLabel("ID Canal Lastros:"), "01", "Insert ID of Channel Operations");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");

            //File Validation
            await util.ClickMatTabAsync(gen.TabAllForms("Validação Arquivo"), "Click belt to change file validation form");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Recebíveis Permitidos ao Fundo"), "Click on button new to Receives allow to fund");
            await util.Write(gen.Filter, "Duplicata", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Duplicata"), "Click Duplicata Type Option");
            await page.Keyboard.PressAsync("Escape");

            //Prestadores d Serviços
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await util.ClickMatTabAsync(gen.TabAllForms("Prestadores de Serviços"), "Click belt to change service prestatives form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);
            //administrator
            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, "Administrador", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Administrador"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, "ORIGINADOR QA", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("ORIGINADOR QA"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, "Valor Fixo", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Valor Fixo"), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), "100000", "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");

            //Manager
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, "Gestor", "Write Receive manager Type");
            await util.Click(gen.ReceiveTypeOption("Gestor"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, "zitec", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("zitec"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, "Valor Fixo", "Write Receive Type");
            await util.Click("//div[@role='listbox']" + gen.ReceiveTypeOption("Valor Fixo"), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), "100000", "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");

            //Consultant
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Service prestative");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, "Consultoria", "Write Consultant Receive Type");
            await util.Click(gen.ReceiveTypeOption("Consultoria"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, "GESTORA DE RECURSOS ID - GRID LTDA.", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("GESTORA DE RECURSOS ID - GRID LTDA."), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, "Valor Fixo", "Write Receive Type");
            await util.Click("//div[@role='listbox']" + gen.ReceiveTypeOption("Valor Fixo"), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), "100000", "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");
            await Task.Delay(1000);
            await util.Click(el.SaveButton, "Click on to add a new Fund!");
            await util.ValidateTextIsVisibleOnScreen(el.SuccessMessageRegisterNewFund, "Validate if success message is present on screen after all Flow finished");


        }
        //To Do - Finish the negative fund registration flow service prestatives, Consult and gestion
        public async Task RegisterNegativeFund()
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();


            //Register Data
            await util.Click(gen.ButtonNew, "Open New Fund form");
            await util.Write(gen.LocatorMatLabel("Fundo"), fundName, "Write Fund Name");
            await util.Write(gen.LocatorMatLabel("CNPJ"), cnpjFund, "Write CNPJ");
            await util.Write(gen.LocatorMatLabel("Código ISIN"), "000000000000130", "Write ISIN Code");
            await util.Write(gen.LocatorMatLabel("Código ANBID"), "1234567890", "Write ANBID Code");

            await util.Click(gen.LocatorMatLabel("Tipo Fundo"), "Write Type Fund");
            await util.Write(gen.Filter, "Direitos Creditórios", "Write Type Fund");
            await util.Click(gen.ReceiveTypeOption("Direitos Creditórios"), "Click on UF option");
            await util.Click(el.StartProcessingCalendar, "Open Start Processing Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(gen.LocatorMatLabel("N° CETIP"), "12345678", "Write CETIP Number");
            await util.Write(gen.LocatorMatLabel("N° SELIC"), "123456789", "Write CELIC Number");

            await util.Click(el.CvmRegisterCalendar, "Open CVM Register Calendar");
            await util.Click(gen.DayValue(today), "Set Today day on calendar");

            await util.Write(gen.LocatorMatLabel("N° Sequencial CVM"), "2536789811", "Write Sequential Number CVM");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Cheque"), "Scroll to element CheckSelect and keep it visible");
            await util.Click(gen.LocatorMatLabel("Lastro"), "Click Ballast Select");
            await util.Write(gen.Filter, "Clube", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("Clube"), "Click on UF option");
            await Task.Delay(100);

            await util.Click(gen.LocatorMatLabel("Código"), "Click Code Select");
            await util.Write(gen.Filter, "1", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("1"), "Click on UF option");
            await Task.Delay(100);

            await util.Click(gen.LocatorMatLabel("Cheque"), "Click Check Select");
            await util.Write(gen.Filter, "CNAB160 - Retorno de Cheque", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("CNAB160 - Retorno de Cheque"), "Click on UF option");
            await Task.Delay(100);

            // Fill mandatory additional fields
            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), "Scroll to NFe Key Receipt Deadline");
            await util.Write(gen.LocatorMatLabel("Prazo de Recepção da Chave da NFe"), "5", "Write NFe Key Receipt Deadline");

            await util.Write(gen.LocatorMatLabel("Prazo Recepção do Lastro"), "5", "Write Deadline Reception Ballast");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Perfil Liquidação Sistema de Ativos"), "Scroll to Profile Active System and maintain position");

            await util.Write(gen.LocatorMatLabel("Prazo PDD"), "0", "Write Deadline PDD");
            await util.Write(gen.LocatorMatLabel("Num. Sequencial Att Termo Cessão"), "1001", "Write Sequence Number Term Cession");
            await util.Write(gen.LocatorMatLabel("Num. Sequencial Att Termo Recompra"), "1002", "Write Sequence Number Term Repurchase");
            await util.Write(gen.LocatorMatLabel("Qtd. Dias Retroagir Importação PL"), "10", "Write Quantity Days Import PL");
            await util.Write(gen.LocatorMatLabel("Convênio"), "12345", "Write Agreement");
            await util.Write(gen.LocatorMatLabel("Valor Máximo para o Robô Assinatura"), "10000", "Write Max Value To Assign Robot");

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Tipo Recebível"), "Scroll to Receive Type and maintain position");
            await Task.Delay(500);
            await util.Click(gen.LocatorMatLabel("Tipo Recebível"), "Click Receive Type");
            await util.Write(gen.Filter, "Duplicata", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Duplicata"), "Click Receive Type Option");

            await util.Write(gen.LocatorMatLabel("Código Carteira"), "001", "Write Wallet Code");
            await util.Write(gen.LocatorMatLabel("Ordem de Processamento"), "99999", "Write Process Order");


            //Rules 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Regras"), "Scroll to Rules form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Regras"), "Click belt to change rules form");

            await util.Click(gen.LocatorMatLabel("Nome da Regra"), "Click on select to expand options of name rules");
            await util.Write(gen.Filter, "ACELERA", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("ACELERA"), "Click on UF option");

            await util.Click(el.RelationshipCalendar, "Click on relationship callendar to expand the callendar");
            await util.Click(gen.DayValue(today), "Click on tomorrow day to set relationship date");

            await util.Click(gen.LocatorMatLabel("Modelo de Precificação"), "Click to expand price model select");
            await util.Write(gen.Filter, "Por recebível", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("Por recebível"), "Click on UF option");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Aplica-se a"), "Click on select to expand options of apply to");
            await util.Write(gen.Filter, "Toda carteira", "Write Aquisition Select");
            await util.Click(gen.ReceiveTypeOption("Toda carteira"), "Click on UF option");

            //Representatives
            await util.Click(gen.TabAllForms("Representantes"), "Click belt to change form");

            await util.Click(gen.ButtonNew, "Click on button new to add new representative");

            await util.Click(gen.LocatorMatLabel("Nome"), "Click on the name representative input");
            await util.Write(gen.LocatorMatLabel("Nome"), "Representante Teste", "Write the name representative on input");

            await util.Write(gen.LocatorMatLabel("Email"), "teste@email.com", "insert email representative on input");

            await util.Write(gen.LocatorMatLabel("CPF"), "40956114806", "Write on the CPF representative input");
            await util.Write(gen.LocatorMatLabel("Telefone"), "11934125767", "Write on the Tel input");

            await util.Click(el.AssignRadio(true), "Select 'yes' to assign");
            await util.Click(el.SignsByEndorsementRadio(true), "Select 'yes' to Signs By Endorsement");
            await util.Click(el.AssignTermRadio(true), "Select 'yes' to assign Term");
            await util.Click(el.IssuesDuplicateRadio(true), "Select 'yes' to Issue Duplicate");

            await util.Click(el.AddButton, "Click on add to add representative on fund");

            //Liquidation 
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Liquidação"), "Scroll to liquidation form");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Liquidação"), "Click belt to change liquidation form");

            await util.Write(gen.LocatorMatLabel("Percentual Máximo Reembolso de Despesas %"), "10", "Set max percent of reimbursement");

            //Account
            await util.ScrollToElementAndMaintainPosition(gen.TabAllForms("Conta Corrente"), "Scroll to account form");
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await Task.Delay(500);
            await util.ClickMatTabAsync(gen.TabAllForms("Conta Corrente"), "Click belt to change account form");

            await util.Click(gen.ButtonNew, "Click on button new to insert a new Account");
            await Task.Delay(250);
            await util.Click(gen.LocatorMatLabel("Banco"), "Click on BankSelect button new to insert a new Bank");
            await util.Write(gen.Filter, "439 - ID CTVM", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("439 - ID CTVM"), "Click Receive Type Option");
            await util.Write(gen.LocatorMatLabel("Número Agência"), "1", "Write Number Agency");
            await util.Write(gen.LocatorMatLabel("Conta Corrente"), "46677", "Write Number account");
            await util.Write(gen.LocatorMatLabel("Dígito"), "3", "Write Code account");
            await util.Click(el.PatternAccount(true), "Click on 'yes' to account pattern");
            await util.Click(el.MovementType("Movimentação"), "Click on Movement Type");
            await util.Write(gen.LocatorMatLabel("Descrição"), "Conta para fundo de teste", "fill description of account test");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");
            //await util.Click(gen.RightArrow, "Click on Arrow to expand group tab");
            //await util.Click(gen.RightArrow, "Click on Arrow to expand group tab");


            //slack
            await util.ClickMatTabAsync(gen.TabAllForms("Slack"), "Click belt to change slack form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Slack Channel");

            await util.Write(gen.LocatorMatLabel("SlackWebhook Operações:"), "WebHook Test", "Insert name of operations webhook");
            await util.Write(gen.LocatorMatLabel("Nome Canal Operações:"), "Channel Test", "Insert Name Of Channel Operations");
            await util.Write(gen.LocatorMatLabel("ID Canal Operações:"), "01", "Insert ID of Channel Operations");

            await util.Write(gen.LocatorMatLabel("SlackWebhook Lastros:"), "WebHook Test", "Insert name of operations webhook");
            await util.Write(gen.LocatorMatLabel("Nome Canal Lastros:"), "Channel Test", "Insert Name Of Channel Operations");
            await util.Write(gen.LocatorMatLabel("ID Canal Lastros:"), "01", "Insert ID of Channel Operations");
            await util.Click(el.AddButton, "Click on Add Button to add a new account");

            //File Validation
            await util.ClickMatTabAsync(gen.TabAllForms("Validação Arquivo"), "Click belt to change file validation form");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Recebíveis Permitidos ao Fundo"), "Click on button new to Receives allow to fund");
            await util.Write(gen.Filter, "Duplicata", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Duplicata"), "Click Duplicata Type Option");
            await page.Keyboard.PressAsync("Escape");

            //Prestadores d Serviços
            await util.Click(gen.RightArrow, "Click on  Arrow to expand group tab");
            await util.ClickMatTabAsync(gen.TabAllForms("Prestadores de Serviços"), "Click belt to change service prestatives form");
            await util.Click(gen.ButtonNew, "Click on button new to insert a new Slack Channel");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo Prestador"), "Select Type Provider in new provider");
            await util.Write(gen.Filter, "Administrador", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Administrador"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Pessoa"), "Select Type Person Type in new provider");
            await util.Write(gen.Filter, "ORIGINADOR QA", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("ORIGINADOR QA"), "Click Receive Type Option");
            await Task.Delay(500);

            await util.Click(gen.LocatorMatLabel("Tipo de Cobrança"), "Select Charge Type Select in new provider");
            await util.Write(gen.Filter, "Valor Fixo", "Write Receive Type");
            await util.Click(gen.ReceiveTypeOption("Valor Fixo"), "Click Receive Type Option");
            await Task.Delay(500);
            await util.Write(gen.LocatorMatLabel("Valor Fixo"), "100000", "Insert fixed value in new provider");
            await page.Keyboard.PressAsync("Backspace");
            await util.Click(el.AddButton, "Click on add button to add new provider");
            await util.Click(el.SaveButton, "Click on to add a new Fund!");
            await util.ValidateReturnedMessageIsVisible(el.SuccessMessage, "Validate if success message is present on screen after all Flow finished");


        }

        public async Task ConsultFund()
        {


            await util.Write(el.SearchBar, fundName, "Write on filter input to find the fund created");
            await Task.Delay(1000);
            await util.ValidateElementPresentOnTheTable(page, el.FundTable, fundName, "Validate if Text is present on table to consult a existing fund");
        }

        public async Task UpdateFund()
        {

            await util.Write(el.SearchBar, fundName, "Write on filter input to find the fund created");
            await Task.Delay(600);
            await util.ValidateTextIsVisibleInElement(el.NameFundTable, fundName, "Validate if name fund is present on table");
            await util.Click(el.EditButton, "Click on Edit button to edit the Fund");
            //Make changes
            await util.Write(gen.LocatorMatLabel("Código ISIN"), "000000000000001", "Edit Code isin");
            await util.ScrollToElementAndMaintainPosition(el.ApplyChangesButton, "Scroll to Button apply changes");

            await util.Click(el.ApplyChangesButton, "Click on to save the Fund!");
            await util.ValidateReturnedMessageIsVisible(el.SuccessMessage, "Validate if success message is present on screen after fund updated");
        }

    }



}