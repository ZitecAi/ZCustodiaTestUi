namespace zCustodiaUi.locators.register
{
    public class FundsElements
    {
        #region Form Registration Data
        //Form Registration Data
        //Name and CNPJ
        public string FundsPage { get; } = "//span[text()='Fundos']";
        public string FundName { get; } = "#input-nome";
        public string Cnpj { get; } = "#input-cnpj";
        public string IsinCode { get; } = "#input-codigoISIN";
        public string AnbidCode { get; } = "#input-codigoANBID";
        public string TypeFundSelect { get; } = "#select-tipoFundo";
        public string TypeFidc { get; } = "//span[text()=' Direitos Creditórios ']";
        public string StartProcessingCalendar { get; } = "(//button[@aria-label='Open calendar'])[1]";
        public string CetipNumber { get; } = "#input-numeroCETIP";
        public string CelicNumber { get; } = "#input-nmrCelic";
        public string CvmRegisterCalendar { get; } = "(//button[@aria-label='Open calendar'])[4]";
        public string SequentialNumberCvm { get; } = "#input-numeroSequencialCVM";

        //Layouts


        public string BallastSelect { get; } = "#select-layoutLastro";
        public string BallastClube { get; } = "//span[text()=' Clube ']";
        public string CodeSelect { get; } = "#mat-select-value-15";
        public string Code1 { get; } = "//span[text()=' 1 ']";

        public string CheckSelect { get; } = "#mat-select-value-17";
        public string CheckCNAB160 { get; } = "//span[text()=' CNAB160 - Retorno de Cheque ']";

        //Permissions and Qualifications
        #region Permissions and Qualifications - Radio Buttons
        public string RateTypeUpdated(bool isMonthly) => $"mat-radio-{(isMonthly ? "17" : "18")}";
        public string ClosedEndFundOpeningProcess(bool isTrue) => $"mat-radio-{(isTrue ? "20" : "21")}";
        public string BlockAssignor(bool isTrue) => $"mat-radio-{(isTrue ? "23" : "24")}";
        public string EnableWhiteOff(bool isTrue) => $"mat-radio-{(isTrue ? "26" : "27")}";
        public string EnableCCBcalculation(bool isTrue) => $"mat-radio-{(isTrue ? "29" : "30")}";
        public string EnablesReducedXml(bool isTrue) => $"mat-radio-{(isTrue ? "32" : "33")}";
        public string ActivateImportPendingAssetSystem(bool isTrue) => $"mat-radio-{(isTrue ? "35" : "36")}";
        public string EnablesValuationOfOverduePayments(bool isTrue) => $"mat-radio-{(isTrue ? "38" : "39")}";
        public string CheckContractsAtRegisterC3(bool isTrue) => $"mat-radio-{(isTrue ? "41" : "42")}";
        public string HighVolumetry(bool isTrue) => $"mat-radio-{(isTrue ? "44" : "45")}";
        public string EnableAssignRobot(bool isTrue) => $"mat-radio-{(isTrue ? "47" : "48")}";
        public string SentEmailNotification(bool isTrue) => $"mat-radio-{(isTrue ? "50" : "51")}";
        public string WorksWithReceivingUnits(bool isTrue) => $"mat-radio-{(isTrue ? "53" : "54")}";
        public string QualificationClassification(bool isTrue) => $"mat-radio-{(isTrue ? "56" : "57")}";
        public string DilutionOfReceivingUnits(bool isTrue) => $"mat-radio-{(isTrue ? "59" : "60")}";
        public string ConsiderPostFixed(bool isTrue) => $"mat-radio-{(isTrue ? "62" : "63")}";
        public string AuthorizesAutomaticFundClosure(bool isTrue) => $"mat-radio-{(isTrue ? "65" : "66")}";
        public string ZeroPl(bool isTrue) => $"mat-radio-{(isTrue ? "68" : "69")}";
        public string IntegrateAccounting(bool isTrue) => $"mat-radio-{(isTrue ? "71" : "72")}";
        public string DisplaysIndexInformationInTheStockReport(bool isTrue) => $"mat-radio-{(isTrue ? "74" : "75")}";
        public string GenerateStockAfterClosingFund(bool isTrue) => $"mat-radio-{(isTrue ? "77" : "78")}";
        public string GeneratesStockAttorney(bool isTrue) => $"mat-radio-{(isTrue ? "80" : "81")}";
        public string ConsiderDueOnClosingDate(bool isTrue) => $"mat-radio-{(isTrue ? "83" : "84")}";
        public string EnablesGeneratePortalStock(bool isTrue) => $"mat-radio-{(isTrue ? "86" : "87")}";
        public string RegisterAssignorAutomated(bool isTrue) => $"mat-radio-{(isTrue ? "89" : "90")}";
        public string EnableGlobalPdd(bool isTrue) => $"mat-radio-{(isTrue ? "92" : "93")}";
        public string WalletSystemIntegrationProcessor(bool isTrue) => $"mat-radio-{(isTrue ? "95" : "96")}";
        #endregion Permissions and Qualifications - Radio Buttons
        //Others

        public string NFeKeyReceiptDeadlineInput { get; } = "#input-prazoRecepcaoChaveNfe";
        public string DataCalendar { get; } = "//button[@aria-label='Calendário aberto']";
        public string DeadLineReceptionBallastInput { get; } = "#input-prazoRecepcaoLastro";
        public string SelectProfileActiveSystem { get; } = "#mat-select-value-21";
        public string DeadLinePddInput { get; } = "#input-prazoPDD";
        public string SequenceNumberTermCessionInput { get; } = "#input-numeroSequencialAttTermoCessao";
        public string SequenceNumberTermRepurchaseInput { get; } = "#input-numeroSequencialAttTermoRecompra";
        public string QuantityDaysImportPlInput { get; } = "#input-qtdDiasRetroagirImportacaoPL";
        public string AgreementInput { get; } = "#input-convenio";
        public string MaxValueToAssignRobotInput { get; } = "#input-valorMaximoRoboAssinatura";
        public string SelectReceiveType { get; } = "#mat-select-value-23";
        public string WalletCodeInput { get; } = "#input-codigoCarteira";
        public string ProcessOrderInput { get; } = "#input-ordemProcessamento";

        // Additional Form Elements
        public string SaveButton { get; } = "//span[text()='Salvar']";
        public string CancelButton { get; } = "//span[text()='Cancelar']";
        public string BackButton { get; } = "//span[text()='Voltar']";
        public string SuccessMessage { get; } = "//div[contains(text(),'sucesso')]";
        public string SuccessMessageRegisterNewFund { get; } = "Dados Salvos com Sucesso!";
        public string ErrorMessage { get; } = "//div[contains(text(),'erro')]";

        // Form Sections
        public string BasicDataSection { get; } = "//h3[contains(text(),'Dados Básicos')]";
        public string LayoutsSection { get; } = "//h3[contains(text(),'Layouts')]";
        public string PermissionsSection { get; } = "//h3[contains(text(),'Permissões')]";
        public string QualificationsSection { get; } = "//h3[contains(text(),'Qualificações')]";
        public string OthersSection { get; } = "//h3[contains(text(),'Outros')]";

        // Additional Layout Options
        public string LayoutAquisitionOption(string option) => $"//span[text()=' {option} ']";
        public string LayoutLastroOption(string option) => $"//span[text()=' {option} ']";
        public string LayoutCodeOption(string option) => $"//span[text()=' {option} ']";
        public string LayoutCheckOption(string option) => $"//span[text()=' {option} ']";
        public string LayoutGeneralOption(string option) => $"//span[text()=' {option} ']";

        // Additional Select Options
        public string ProfileActiveSystemOption(string option) => $"//span[text()=' {option} ']";
        public string ReceiveTypeOption(string option) => $"//span[text()=' {option} ']";

        // Form Validation Elements
        public string RequiredFieldError { get; } = "//mat-error[contains(text(),'obrigatório')]";
        public string InvalidFormatError { get; } = "//mat-error[contains(text(),'formato')]";
        public string DuplicateError { get; } = "//mat-error[contains(text(),'já existe')]";

        // Navigation Elements
        public string NextStepButton { get; } = "//span[text()='Próximo']";
        public string PreviousStepButton { get; } = "//span[text()='Anterior']";
        public string FinishButton { get; } = "//span[text()='Finalizar']";

        // Form Steps/Tabs
        public string StepIndicator { get; } = "//div[contains(@class,'step')]";
        public string CurrentStep { get; } = "//div[contains(@class,'step-active')]";

        // Additional Input Fields
        public string FundDescription { get; } = "#input-descricao";
        public string FundManager { get; } = "#input-gestor";
        public string FundAdministrator { get; } = "#input-administrador";
        public string FundCustodian { get; } = "#input-custodiante";
        public string FundAuditor { get; } = "#input-auditor";
        public string FundRiskManager { get; } = "#input-gestorRisco";
        public string FundLegalRepresentative { get; } = "#input-representanteLegal";

        // Additional Calendar Fields
        public string FundCreationDate { get; } = "(//button[@aria-label='Open calendar'])[5]";
        public string FundStartDate { get; } = "(//button[@aria-label='Open calendar'])[6]";
        public string FundEndDate { get; } = "(//button[@aria-label='Open calendar'])[7]";

        // Additional Number Fields
        public string FundShareValue { get; } = "#input-valorCota";
        public string FundMinimumInvestment { get; } = "#input-investimentoMinimo";
        public string FundMaximumInvestment { get; } = "#input-investimentoMaximo";
        public string FundTotalValue { get; } = "#input-valorTotal";
        public string FundShareQuantity { get; } = "#input-quantidadeCotas";

        // Additional Select Fields
        public string FundCategory { get; } = "#select-categoriaFundo";
        public string FundSubCategory { get; } = "#select-subCategoriaFundo";
        public string FundRiskLevel { get; } = "#select-nivelRisco";
        public string FundLiquidity { get; } = "#select-liquidez";
        public string FundBenchmark { get; } = "#select-benchmark";

        // Additional Checkbox/Radio Groups
        public string FundPublicOffering(bool isPublic) => $"mat-radio-{(isPublic ? "100" : "101")}";
        public string FundQualifiedInvestors(bool isQualified) => $"mat-radio-{(isQualified ? "102" : "103")}";
        public string FundProfessionalInvestors(bool isProfessional) => $"mat-radio-{(isProfessional ? "104" : "105")}";
        public string FundInstitutionalInvestors(bool isInstitutional) => $"mat-radio-{(isInstitutional ? "106" : "107")}";

        // Additional Text Areas
        public string FundInvestmentPolicy { get; } = "#textarea-politicaInvestimento";
        public string FundRiskFactors { get; } = "#textarea-fatoresRisco";
        public string FundAdditionalInformation { get; } = "#textarea-informacoesAdicionais";

        // File Upload Elements
        public string FundProspectusUpload { get; } = "#input-prospecto";
        public string FundRegulationUpload { get; } = "#input-regulamento";
        public string FundByLawsUpload { get; } = "#input-estatuto";
        public string FundOtherDocumentsUpload { get; } = "#input-outrosDocumentos";

        // Additional Action Buttons
        public string PreviewButton { get; } = "//span[text()='Visualizar']";
        public string PrintButton { get; } = "//span[text()='Imprimir']";
        public string ExportButton { get; } = "//span[text()='Exportar']";
        public string ImportButton { get; } = "//span[text()='Importar']";
        public string ValidateButton { get; } = "//span[text()='Validar']";
        public string SubmitButton { get; } = "//span[text()='Submeter']";

        // Form Status Indicators
        public string FormStatusDraft { get; } = "//span[text()='Rascunho']";
        public string FormStatusPending { get; } = "//span[text()='Pendente']";
        public string FormStatusApproved { get; } = "//span[text()='Aprovado']";
        public string FormStatusRejected { get; } = "//span[text()='Rejeitado']";

        // Additional Navigation
        public string FormProgressBar { get; } = "//div[contains(@class,'progress-bar')]";
        public string FormStepCounter { get; } = "//span[contains(text(),'Passo')]";
        public string FormCompletionPercentage { get; } = "//span[contains(text(),'%')]";


        // Tabs Control


        // Rules related elements
        public string RuleNameSelect { get; } = "#select-nomeRegra";
        public string FirstRuleNameOfList { get; } = "(//mat-option)[1]";
        public string RelationshipCalendar { get; } = "(//button[@aria-label='Open calendar'])[1]";
        public string PriceModelSelect { get; } = "#select-idTipoPrecificacao";
        public string FirstPriceModelOfList { get; } = "//span[text()=' Por recebível ']";
        public string ApplyToSelect { get; } = "#mat-select-value-29";
        public string FirstApplyToOfList { get; } = "//span[text()=' Toda carteira ']";

        public string NameRepresentative { get; } = "#input-nome";
        public string EmailRepresentative { get; } = "#input-email";
        public string PersonTypeSelect { get; } = "#input-nome";
        public string Cpf { get; } = "#mat-mdc-form-field-label-162";
        public string Tel { get; } = "#input-telefone";
        public string Assign { get; } = "#input-nome";
        public string SignsByEndorsement { get; } = "#input-nome";
        public string AssignTerm { get; } = "#input-nome";
        public string IssuesDuplicate { get; } = "#input-nome";
        public string AssignRadio(bool IsTrue) => $"//mat-radio-group//mat-radio-button[@id='mat-radio-{(IsTrue ? "254" : "255")}']";
        public string SignsByEndorsementRadio(bool IsTrue) => $"//mat-radio-group//mat-radio-button[@id='mat-radio-{(IsTrue ? "257" : "258")}']";
        public string AssignTermRadio(bool IsTrue) => $"//mat-radio-group//mat-radio-button[@id='mat-radio-{(IsTrue ? "260" : "261")}']";
        public string IssuesDuplicateRadio(bool IsTrue) => $"//mat-radio-group//mat-radio-button[@id='mat-radio-{(IsTrue ? "263" : "264")}']";
        public string AddButton { get; } = "//span[text()='Adicionar']";
        public string MaxPercentReimbusement { get; } = "#input-percentualMaxReembolso";
        public string BankSelect { get; } = "#select-idBanco";
        public string NumberAgencyInput { get; } = "#mat-input-59";
        public string NumberAccountInput { get; } = "#input-nuConta";
        public string NumberCodeInput { get; } = "#input-nuDigitoConta";
        public string PatternAccount(bool IsTrue) => $"//mat-radio-group//mat-radio-button[@id='mat-radio-{(IsTrue ? "266" : "267")}']";
        public string MovementType(string type) => $"//label[text()=' {type} ']";
        public string ReceiveAllowToFund { get; } = "#select-recebiveisPermitidosFundos";
        public string TableDouble { get; } = "#select-recebiveisPermitidosFundos-panel";
        public string WebHookOperationsInput { get; } = "#input-slackWebookOperacoes";
        public string NameChannelOperationsInput { get; } = "#input-nomeCanalOperacoes";
        public string IDChannelOperationsInput { get; } = "#mat-input-65";
        public string WebHookBallastInput { get; } = "#input-slackWebookLastros";
        public string NameChannelBallastInput { get; } = "#input-nomeCanalLastros";
        public string IDChannelBallastInput { get; } = "#mat-input-68";
        public string ProviderTypeSelect { get; } = "(//div[@class='col-md-3 ng-star-inserted'])[1]";
        public string PersonSelect { get; } = "#mat-select-value-53";
        public string ChargeTypeSelect { get; } = "#mat-select-value-55";
        public string FixedValue { get; } = "#mat-input-69";
        public string MinimunValue { get; } = "(//div[@class='col-md-3 ng-star-inserted'])[3]";
        public string RateService { get; } = "(//div[@class='col-md-3 ng-star-inserted'])[4]";


        #endregion Form Registration Data



        public string SearchBar { get; } = "#mat-input-0";
        public string NameFundTable { get; } = "(//tbody//tr//td)[3]//app-table-cell//div//span";
        public string EditButton { get; } = "(//mat-icon[text()=' edit_note '])[1]";
        public string ApplyChangesButton { get; } = "//span[text()='Editar']";
        public string FundTable { get; } = "//table[@class='w-100 mat-elevated-item overflow-auto']";
    }

}
