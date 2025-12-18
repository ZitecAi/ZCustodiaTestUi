namespace zCustodiaUi.data.processing
{
    public class ReceivablesData
    {
        public string FundName { get; set; } = "Zitec FIDC";
        public string IdWriteOff { get; set; } = "71528915";
        public string IdProrrogation { get; set; } = "71528939";
        public string IdPartialWriteOff { get; set; } = "72104113";
        public string OccurrencePartial { get; set; } = "LIQUIDAÇÃO PARCIAL";
        public string LiquidationValuePartial { get; set; } = "10";
        public string OccurrenceLow { get; set; } = "BAIXA";
        public string LiquidationValue { get; set; } = "100000";
        public string OccurrenceDeleteMovement { get; set; } = "EXCLUSÃO DO ÚLTIMO MOVIMENTO";
        public string OccurrenceProrrogation { get; set; } = "PRORROGAÇÃO DE VENCIMENTO PRAZO TIR";
    }
}