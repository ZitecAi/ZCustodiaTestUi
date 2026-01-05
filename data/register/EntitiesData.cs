namespace zCustodiaUi.data.register
{
    public class EntitiesData
    {
        public string EntityName { get; set; } = "Entity Test UI";
        public string EntityCnpj { get; set; } = utils.DataGenerator.Generate(utils.DocumentType.Cnpj);
        public string EntityEmail { get; set; } = "52721175000191";
        public string EntityPostalCode { get; set; } = "06240090";
        public string NumberAdress { get; set; } = "127";
        public string TelNumber { get; set; } = "11934125767";


        //Bank Account Data         
        public string BankName { get; set; } = "439 - ID CTVM";
        public string NumberAgency { get; set; } = "1";
        public string NumberAccount { get; set; } = "1010";
        public string Description { get; set; } = "Test";

        //Representative
        public string RepresentativeName { get; set; } = "Representative Test UI";
        public string RepresentativeEmail { get; set; } = "email@test.com";
        public string RepresentativeCpf { get; set; } = utils.DataGenerator.Generate(utils.DocumentType.Cpf);
        public string RepresentativeTelNumber { get; set; } = "11934125767";

        //Messages
        public string SuccessMessageWhenRegisterEntity { get; } = "Dados Salvos com Sucesso!";
        public string ErrorMessageWhitoutFunction { get; } = "É necessário selecionar pelo menos um papel desempenhado.";
        public string ErrorMessageWhitoutAccount { get; } = "A entidade deve possuir ao menos uma conta corrente vinculada.";


    }
}
