using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class AssignorsPage
    {
        private readonly IPage page;
        private readonly Utils util;
        private readonly GenericElements gen = new GenericElements();
        private readonly AssignorsElements el = new AssignorsElements();
        private readonly AssignorsData data = new AssignorsData();
        public AssignorsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task CRUD_Assignors()
        {
            await Task.Delay(1000);
            await util.Click(gen.LocatorSpanText(" Novo "), "Click on new assignor button to start register");
            await util.Click(el.FormAssignors, "Click on Form Assignors button to start register");
            await Task.Delay(500);
            //General Data
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on fund select");
            await util.Write(gen.Filter, data.FundAssignor, "Click on filter input to search for fund");
            await util.Click(gen.ReceiveTypeOption(data.FundAssignor), "Click on fund option");
            await Task.Delay(100);
            await util.Write(gen.LocatorMatLabel("Nome"), data.NameAssignor, "Insert Name of Assignor to be Registered");
            await util.Write(gen.LocatorMatLabel("CNPJ"), data.CnpjAssignor, "Insert CNPJ of Assignor to be Registered");
            await util.Write(gen.LocatorMatLabel("Inscrição Estadual"), data.StateRegistration, "Insert State Registration of Assignor to be Registered");
            await util.Write(gen.LocatorMatLabel("Inscrição Municipal"), data.MunicipalRegistration, "Insert Municipal Registration of Assignor to be Registered");
            await Task.Delay(150);

            await util.Click(gen.LocatorMatLabel("Ramo de Atividade"), "Click on Activity Select");
            await util.Write(gen.Filter, data.Activity, "Insert Activity of Assignor to be Registered");
            await util.Click(gen.ReceiveTypeOption(data.Activity), "Click on Activity option");
            await Task.Delay(150);

            await util.Click(gen.LocatorMatLabel("Porte"), "COMÉRCIO on Port Select");
            await util.Write(gen.Filter, data.Port, "Insert Port of Assignor to be Registered");
            await util.Click(gen.ReceiveTypeOption(data.Port), "Click on Port option");
            await Task.Delay(150);
            await util.Write(gen.LocatorMatLabel("Email"), data.Email, "Insert Email to be registered");

            await util.Click(gen.LocatorMatLabel("Tipo de Sociedade"), "Click on Type of Society Select");
            await util.Write(gen.Filter, data.SocietyType, "Insert Type of Society to be Registered");
            await util.Click(gen.ReceiveTypeOption(data.SocietyType), "Click on Type of Society option");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Classificação de Risco"), "Click on Risk Classification Select");
            await util.Write(gen.Filter, data.RiskClassification, "Insert Risk Classification to be Registered");
            await util.Click(gen.ReceiveTypeOption(data.RiskClassification), "Click on Risk Classification option");

            await util.Write(gen.LocatorMatLabel("Faturamento Anual"), data.AnnualBilling, "Insert Annual Billing to be Registered");
            await page.Keyboard.PressAsync("Space");
            await util.Click(el.Authorization(true), "Click on Authorization Radio Button to be Registered");

            //Location
            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("CEP"), "Scroll to CEP");

            await util.Write(gen.LocatorMatLabel("CEP"), data.PostalCode, "Insert Postal Code to be Registered");
            await util.Write(gen.LocatorMatLabel("Endereço"), data.Address, "Insert Address to be Registered");
            await util.Write(gen.LocatorMatLabel("Número"), data.Number, "Insert Number to be Registered");
            await util.Write(gen.LocatorMatLabel("Complemento"), data.Complement, "Insert Complement to be Registered");
            await util.Write(gen.LocatorMatLabel("Bairro"), data.Neighborhood, "Insert Neighborhood to be Registered");
            await util.Write(gen.LocatorMatLabel("Cidade"), data.City, "Insert City to be Registered");

            await util.Click(gen.LocatorMatLabel("UF"), "Click on UF Select");
            await util.Write(gen.Filter, data.UF, "Insert UF to be Registered");
            await util.Click(gen.ReceiveTypeOption(data.UF), "Click on UF option");
            await Task.Delay(150);

            await util.Write(el.TelInput, data.Telephone, "Insert Telephone to be Registered");

            //Tax Data 
            await util.Write(gen.LocatorMatLabel("Conglomerado Econômico"), data.EconomicConglomerate, "Insert Economic Conglomerate to be Registered");
            await util.Write(gen.LocatorMatLabel("Número mínimo de assinaturas para aprovação"), data.MinSignaturesApproval, "Insert Assignor Percentage to be Approved to be Registered");
            await util.Write(gen.LocatorMatLabel("Limite de Crédito"), data.CreditLimit, "Insert Credit Limit to be Registered");
            await page.Keyboard.PressAsync("Space");
            await Task.Delay(150);

            await util.ScrollToElementAndMaintainPosition(gen.LocatorMatLabel("Chave Pix"), "Scrool on Is Chave Pix Select");
            await util.Click(gen.LocatorMatLabel("Coobrigação"), "Click on Is Coobrigation Select");
            await util.Write(gen.Filter, data.Coobrigation, "Insert Is Coobrigation to be Registered");
            await Task.Delay(1000);
            await util.Click(gen.ReceiveTypeOption(data.Coobrigation), "Click on Is Coobrigation option");

            //Data Account

            await util.ClickMatTabAsync(gen.TabAllForms("Dados da Conta"), "Click on Data Account tab to fill data");
            await Task.Delay(600);
            await util.Click(gen.ButtonNew, "Click in New to insert a New Account");
            await Task.Delay(150);
            await util.Click(gen.LocatorMatLabel("Banco"), "Insert Bank Number to be Registered");
            await util.Write(gen.Filter, data.Bank, "Insert Is Coobrigation to be Registered");
            await util.Click(gen.ReceiveTypeOption(data.Bank), "Click on Is Coobrigation option");

            await util.Write(gen.LocatorMatLabel("Número Agência"), data.AgencyNumber, "Insert Agency Number to be Registered");
            await util.Write(gen.LocatorMatLabel("Conta Corrente"), data.AccountNumber, "Insert Account Number to be Registered");
            await util.Write("(" + gen.LocatorMatLabel("Dígito") + ")[2]", data.AccountDigit, "Insert Account Digit to be Registered");
            await util.Write(gen.LocatorMatLabel("Descrição"), data.AccountDescription, "Click on Account Type Select");
            await util.Click(el.Pattern(true), "Click on Active Account");
            await util.Click(gen.AddButton, "Click on Add Button to add new account");

            //Representative
            await util.ClickMatTabAsync(gen.TabAllForms("Representante"), "Click on Representative tab to fill data");
            await Task.Delay(600);
            await util.Click(gen.ButtonNew, "Click in New to insert a New Account");
            await util.Write(gen.LocatorMatLabel("Nome"), data.RepresentativeName, "Insert Name of Representative to be Registered");
            await util.Write(gen.LocatorMatLabel("E-mail"), data.RepresentativeEmail, "Insert E-mail of Representative to be Registered");
            await util.Write(gen.LocatorMatLabel("CPF"), data.RepresentativeCPF, "Insert CPF of Representative to be Registered");
            await util.Write(gen.LocatorMatLabel("Telefone"), data.RepresentativeTelephone, "Insert Telephone of Representative to be Registered");
            await util.Click(el.Assign(true), "Click on 'yes' to Assign");
            await util.Click(el.AssignTerm(true), "Click on 'yes' to Assign Term");
            await util.Click(el.AssignByEndorsement(true), "Click on 'yes' to Assign By Endorsement");
            await util.Click(el.IssueDouble(true), "Click on 'yes' to Issue Double");
            await util.Click(gen.AddButton, "Click on Add button to add new Assignor");
            await Task.Delay(1500);
            await util.Click(gen.SaveButton, "Click on Add button to add new Representative");
            await util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success Message is visible on screen after did register a new assignor");

            //Consult Assignor
            await page.ReloadAsync();
            await util.Click(gen.FilterButton, "Click on Filter Button to filter Assignor to be consulted");
            await Task.Delay(500);
            await util.Click(gen.LocatorMatLabel("Fundo"), "Click on Filter Select to filter Assignor to be consulted");
            await util.Write(gen.Filter, data.FundAssignor, "Insert Find Assignor to be consulted");
            await util.Click(gen.ReceiveTypeOption(data.FundAssignor), $"Click on {data.FundAssignor} option");
            await util.Write(gen.LocatorMatLabel("Nome Cedente"), data.NameAssignor, "Insert Name Assignor to be consulted");
            await util.Write(gen.LocatorMatLabel("CNPJ"), data.CnpjAssignor, "Insert CNPJ Assignor to be consulted");
            await util.Click(el.ApplyFilterButton, "Click on Apply Filter Button to show results");
            await Task.Delay(1000);
            string id = await util.ValidateIfElementHaveValue(el.IdPosition, "Validate If ID of assignor is present on screen");

            //Update Assignor
            await util.Click(gen.EditButton, "Click on Edit button to update Assignor");
            await Task.Delay(150);
            await util.Write(gen.LocatorMatLabel("Nome"), data.EditedName, "Insert Name EDITED of Assignor to be Registered");
            await util.Click(gen.SaveButton, "Click on Add button to add EDITED Assignor");
            await util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success Message is visible on screen after updated existing assignor");

            //Pending -> Delete Assignor
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Token", "DHQzckJ0TGWHiFxaVuUlmrBLWXwuejrtSAT0Mf47gvclZ5GKY543iYKNeLfqlzngXH0YcKGLe4qyv0avru3xeVGBp9yUQKKKlSyJ");

            var request = await httpClient.DeleteAsync($"https://custodiabackend-prod.idsf.com.br/api/Cedente/QATESTE/{id}");

            string response = await request.Content.ReadAsStringAsync();
            Console.WriteLine(response);

        }



    }
}
