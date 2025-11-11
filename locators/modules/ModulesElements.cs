using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.modules
{
    public class ModulesElements
    {
        public string MainMenu { get; } = "//mat-icon[text()=' menu ']";
        public string PanelPage { get; } = "//a[@href='/home/dashboard']";
        public string OperationsPage { get; } = "//a[@href='/home/operations']";
        public string OperationsPaymentPage { get; } = "//a[@href='/home/operations-payment']";
        public string IdBankPage { get; } = "//a[@href='/home/id-bank']";
        public string CommercialBillPage { get; } = "//a[@href='/home/commercial-bill']";
        public string ReportsPage { get; } = "//a[@href='/home/reports']";
        public string AdmnistrativePage { get; } = "//a[@href='/home/admin']";
        public string RegisterPage { get; } = "//a[@href='/home/registers']";
        public string ProcessingPage { get; } = "//a[@href='/home/processing']";
        public string ImportationPage { get; } = "//a[@href='/home/importation']";
        public string FramingPage { get; } = "//a[@href='/home/enquadramento']";
        public string ParamsPage { get; } = "//a[@href='/home/params']";
    }
}
