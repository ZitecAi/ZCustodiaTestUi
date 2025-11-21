using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.data.processing
{
    public class ReceivablesData
    {
        public string FundName { get; set; } = "Zitec FIDC";
        public string YourNumberPartial { get; set; } = "9610646761377766170078081";
        public string OccurrencePartial { get; set; } = "LIQUIDAÇÃO PARCIAL";
        public string LiquidationValuePartial { get; set; } = "10";
        public string YourNumber { get; set; } = "5106952059211134519296724";
        public string OccurrenceLow { get; set; } = "BAIXA";
        public string LiquidationValue { get; set; } = "100000";
        public string OccurrenceDeleteMovement { get; set; } = "EXCLUSÃO DO ÚLTIMO MOVIMENTO";
        public string YourNumberProrrogation { get; set; } = "7627258796954141316414582";
        public string OccurrenceProrrogation { get; set; } = "PRORROGAÇÃO DE VENCIMENTO PRAZO TIR";
    }
}