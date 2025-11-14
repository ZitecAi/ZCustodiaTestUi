namespace zCustodiaUi.locators.processing
{
    public class ReceivablesElements
    {
        public string ReceivablesPage { get; } = "//span[text()='Processamento Recebíveis']";
        public string SecondCheckBox { get; } = "(//div[@class='mdc-checkbox__background'])[2]";
        public string StatusPositionOnTheTable { get; } = "//app-status-column//div";
    }
}
