using Microsoft.Playwright;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class DraweePage
    {
        private readonly IPage page;
        private readonly Utils util;
        private readonly GenericElements gen = new GenericElements();
        private readonly DraweeElements el = new DraweeElements();
        public DraweePage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }


        string cpfTest = DataGenerator.Generate(DocumentType.Cpf);

        public async Task Register_Drawee()
        {
            var today = DateTime.Now.Day.ToString();
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            Random random = new Random();
            int uniqueNumber = random.Next(0, 9999);

            await util.Click(gen.LocatorSpanText("Novo Sacado"), "Click on new drawee button to register a new drawee");
            await Task.Delay(1000);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on select fund to expand list of funds");
            await util.Write(gen.Filter, "Zitec FIDC", "Select Zitec FIDC to choose zitec fund");
            await util.Click(gen.LocatorSpanText(" Zitec FIDC "), "Select ZITEC FIDC");

            await util.Write(gen.LocatorMatLabel("Nome"), $"Sacado Test {uniqueNumber}", "Write drawee name");
            await util.Write(gen.LocatorMatLabel("Email"), "email@teste.com", "Write drawee email");
            await util.Write(gen.LocatorMatLabel("CPF"), cpfTest, "Write drawee email");

            await util.Click(el.CalendarStartRelationship, "Open Calendar Start Relationship");
            await util.Click(el.DayValue(today), "Select Today on calendar of start Relationship");
            await util.Click(el.CalendarEndRelationship, "Open Calendar End Relationship");
            await util.Click(el.DayValue(tomorrow), "Select Today on calendar of start Relationship");
            await util.Write(gen.LocatorMatLabel("Faturamento anual"), "100000", "Write annual revenue");
            await page.Keyboard.PressAsync("Space");

            await util.Write(gen.LocatorMatLabel("Conglomerado Econômico"), "1234", "Write drawee economic conglomerate");
            await Task.Delay(100);
            await util.Click(gen.LocatorMatLabel("Porte"), "Click on select size to expand options");
            await util.Write(gen.Filter, "Microempreendedor Individual (MEI)", "Select MEI to choose MEI");
            await util.Click(gen.LocatorSpanText(" Microempreendedor Individual (MEI) "), "Select large size option");
            await Task.Delay(100);
            await util.Click(gen.LocatorMatLabel("Classificação de Risco"), "Click on select risk classification to expand options");
            await util.Write(gen.Filter, "Baixo", "Select low to choose low option");
            await util.Click(gen.LocatorSpanText(" Baixo "), "Select low size option");
            await Task.Delay(100);
            await util.Click(gen.LocatorMatLabel("Tipo de Sociedade"), "Click on select risk classification to expand options");
            await util.Write(gen.Filter, "LTDA", "Select low to choose low option");
            await util.Click(gen.LocatorSpanText(" LTDA "), "Select low size option");

            await util.Write(gen.LocatorMatLabel("Inscrição Estadual"), "123456", "Write state registration");

            await util.Write(gen.LocatorMatLabel("CEP"), "06240110", "Write postal code");
            await util.ValidateElementHaveValue(el.NeighborhoodInput, "Validate if CEP returned address values");
            await util.Write(gen.LocatorMatLabel("Número"), "1889", "Write number adress on input number");
            await util.Write(gen.LocatorMatLabel("Telefone(DDD)"), "11934125767", "Write phone number on input");

            await util.Click(gen.LocatorSpanText("Salvar"), "CLick on save button to save drawee");

            await util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success message is visible on screen after did flow to register a new drawee");
            await Task.Delay(1000);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on select fund to expand list of funds");
            await util.Write(gen.Filter, "Zitec FIDC", "Select Zitec FIDC to choose zitec fund");
            await util.Click(gen.LocatorSpanText(" Zitec FIDC "), "Select ZITEC FIDC");
            await Task.Delay(100);

            string nameDrawee = $"Sacado Test {uniqueNumber}";
            await util.Click("//button" + gen.LocatorMatIcon("last_page"), "Click on right arrow to navigate to next page of drawee list");

            await Task.Delay(1500);
            await util.ValidateElementPresentOnTheTable(page, el.DraweeTable, nameDrawee, "Validate if drawee name is visible on screen after created");

        }



    }
}
