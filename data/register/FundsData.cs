using zCustodiaUi.utils;

namespace zCustodiaUi.data.register
{
    public class FundsData
    {

        public string FundName { get; set; } = "ZitecQa";
        public string FundNameZitecFIDC { get; set; } = "Zitec FIDC";
        public string FundCNPJZitecFIDC { get; set; } = "54.638.076/0001-76";
        public string ManagerNameZitecFIDC { get; set; } = "ORIGINADOR QA";
        public string CnpjFund { get; set; } = DataGenerator.Generate(DocumentType.Cnpj);
        public string CetipNumber { get; set; } = "12345678";
        public string SelicNumber { get; set; } = "123456789";
        public string IsinCode { get; set; } = "000000000000130";
        public string MaxPercent { get; set; } = "10";
        public string AgencyNumber { get; set; } = "1";
        public string Description { get; set; } = "Conta para fundo de teste";

        // Additional properties for all Write calls
        public string AnbidCode { get; set; } = "1234567890";
        public string FundType { get; set; } = "Direitos Creditórios";
        public string SequentialCvmNumber { get; set; } = "2536789811";
        public string Ballast { get; set; } = "Clube";
        public string Code { get; set; } = "1";
        public string CheckType { get; set; } = "CNAB160 - Retorno de Cheque";
        public string NFeKeyReceiptDeadline { get; set; } = "5";
        public string BallastReceiptDeadline { get; set; } = "5";
        public string PddDeadline { get; set; } = "0";
        public string SequenceNumberTermCession { get; set; } = "1001";
        public string SequenceNumberTermRepurchase { get; set; } = "1002";
        public string DaysImportPl { get; set; } = "10";
        public string Agreement { get; set; } = "12345";
        public string MaxValueRobot { get; set; } = "10000";
        public string ReceivableType { get; set; } = "Duplicata";
        public string WalletCode { get; set; } = "001";
        public string ProcessOrder { get; set; } = "99999";
        public string RuleName { get; set; } = "ACELERA";
        public string PricingModel { get; set; } = "Por recebível";
        public string ApplyTo { get; set; } = "Toda carteira";
        public string RepresentativeName { get; set; } = "Representante Teste";
        public string RepresentativeEmail { get; set; } = "teste@email.com";
        public string RepresentativeCPF { get; set; } = "40956114806";
        public string RepresentativeTelephone { get; set; } = "11934125767";
        public string Bank { get; set; } = "439 - ID CTVM";
        public string AccountNumber { get; set; } = "46677";
        public string AccountDigit { get; set; } = "3";
        public string OperationsWebhook { get; set; } = "WebHook Test";
        public string OperationsChannelName { get; set; } = "Channel Test";
        public string OperationsChannelId { get; set; } = "01";
        public string BallastWebhook { get; set; } = "WebHook Test";
        public string BallastChannelName { get; set; } = "Channel Test";
        public string BallastChannelId { get; set; } = "01";
        public string ProviderTypeAdministrator { get; set; } = "Administrador";
        public string PersonTypeAdministrator { get; set; } = "ORIGINADOR QA";
        public string ChargeType { get; set; } = "Valor Fixo";
        public string FixedValue { get; set; } = "100000";
        public string ProviderTypeManager { get; set; } = "Gestor";
        public string PersonTypeManager { get; set; } = "ORIGINADOR QA";
        public string ProviderTypeConsultant { get; set; } = "Consultoria";
        public string PersonTypeConsultant { get; set; } = "GESTORA DE RECURSOS ID - GRID LTDA.";
        public string EditedIsinCode { get; set; } = "000000000000001";
    }
}
