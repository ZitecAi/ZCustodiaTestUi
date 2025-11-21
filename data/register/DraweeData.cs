using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.utils;

namespace zCustodiaUi.data.register
{
    public class DraweeData
    {
        public string Fund { get; set; } = "Zitec FIDC";
        public string Email { get; set; } = "email@teste.com";
        public string CPF { get; set; } = DataGenerator.Generate(DocumentType.Cpf);
        public string AnnualRevenue { get; set; } = "100000";
        public string EconomicConglomerate { get; set; } = "1234";
        public string Size { get; set; } = "Microempreendedor Individual (MEI)";
        public string RiskClassification { get; set; } = "Baixo";
        public string SocietyType { get; set; } = "LTDA";
        public string StateRegistration { get; set; } = "123456";
        public string PostalCode { get; set; } = "06240110";
        public string AddressNumber { get; set; } = "1889";
        public string Telephone { get; set; } = "11934125767";
    }
}