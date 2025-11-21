using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.utils;

namespace zCustodiaUi.data.register
{
    public class FundsData
    {

        public string FundName { get; set; } = "ZitecQa";
        public string CnpjFund { get; set; } = DataGenerator.Generate(DocumentType.Cnpj);
        public string CetipNumber { get; set; } = "12345678";
        public string SelicNumber { get; set; } = "123456789";
        public string IsinCode { get; set; } = "000000000000130";
        public string MaxPercent { get; set; } = "10";
        public string AgencyNumber { get; set; } = "1";
        public string Description { get; set; } = "Conta para fundo de teste";
    }
}
