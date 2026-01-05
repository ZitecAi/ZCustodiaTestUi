using Microsoft.Extensions.Configuration;
using zCustodiaUi.utils;

namespace zCustodiaUi.data.register
{
    public class AssignorsData
    {
        public static string Config(bool isToken)
        {
            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            var tokenEnv = Environment.GetEnvironmentVariable("ZCUSTODIA_TOKEN");
            var apiEnv = Environment.GetEnvironmentVariable("ZCUSTODIA_ROUTE");
            var tokenConfig = config["Credentials:Token"];
            var apiConfig = config["Credentials:Api"];

            var token = tokenConfig ?? tokenEnv;
            var api = apiConfig ?? apiEnv;

            return isToken ? $"{token}" : $"{api}";
        }

        public AssignorsData()
        {
            Token = Config(true);
            Api = Config(false);
        }
        public static string Token { get; set; }
        public static string Api { get; set; }

        public static string uniqueNumber = new Random().Next(1000, 9999).ToString();

        public string NameAssignor { get; set; } = $"Cedente Teste Zitec {uniqueNumber}";
        public string FundAssignor { get; set; } = "Zitec FIDC";
        public string CnpjAssignor { get; set; } = DataGenerator.Generate(DocumentType.Cnpj);
        public string CpfAssignor { get; set; } = DataGenerator.Generate(DocumentType.Cpf);
        public string StateRegistration { get; set; } = "123456789";
        public string MunicipalRegistration { get; set; } = "987654321";
        public string Activity { get; set; } = "COMÉRCIO";
        public string Port { get; set; } = "Médio";
        public string Email { get; set; } = "teste@email.com.br";
        public string SocietyType { get; set; } = "LTDA";
        public string RiskClassification { get; set; } = "Baixo";
        public string AnnualBilling { get; set; } = "50000000";
        public string PostalCode { get; set; } = "01310-000";
        public string Address { get; set; } = "Avenida Paulista";
        public string Number { get; set; } = "1000";
        public string Complement { get; set; } = "10º Andar";
        public string Neighborhood { get; set; } = "Bela Vista";
        public string City { get; set; } = "São Paulo";
        public string UF { get; set; } = "São Paulo";
        public string Telephone { get; set; } = "1130000000";
        public string EconomicConglomerate { get; set; } = "Conglomerado Teste Zitec";
        public string MinSignaturesApproval { get; set; } = "80";
        public string CreditLimit { get; set; } = "1000000";
        public string Coobrigation { get; set; } = "Não";
        public string Bank { get; set; } = "439 - ID CTVM";
        public string AgencyNumber { get; set; } = "1";
        public string AccountNumber { get; set; } = "46677";
        public string AccountDigit { get; set; } = "3";
        public string AccountDescription { get; set; } = "Teste";
        public string RepresentativeName { get; set; } = "Representante Teste Zitec";
        public string RepresentativeEmail { get; set; } = "email@representantetestZitec.ai";
        public string RepresentativeCPF { get; set; } = "40956114806";
        public string RepresentativeTelephone { get; set; } = "11934125767";
        public string EditedName { get; set; } = "Cedente Teste Zitec EDITADO";
    }
}