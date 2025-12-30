namespace zCustodiaUi.locators.register
{
    public class EntitiesElements
    {
        public string CheckBoxAdminRole { get; } = "(//input[@type='checkbox']/following-sibling::div[2])[1]";
        public string RadioButtonAssign { get; } = "(//label[text()='Assina ']/following-sibling::mat-radio-group//input[@type='radio'])[1]";
        public string RadioButtonAssignByEndorsement { get; } = "(//label[text()='Assina por Endosso ']/following-sibling::mat-radio-group//input[@type='radio'])[1]";
        public string RadioButtonAssignSessionTerm { get; } = "(//label[text()='Assina Termo de Cessão ']/following-sibling::mat-radio-group//input[@type='radio'])[1]";
        public string RadioButtonIssueDuplicate { get; } = "(//label[text()='Emite Duplicata ']/following-sibling::mat-radio-group//input[@type='radio'])[1]";

    }
}
