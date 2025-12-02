# zCustodiaUi - Testes Automatizados Web

**Relatório Allure**: https://zitecai.github.io/ZCustodiaTestUi/

## 📋 Visão Geral

O **zCustodiaUi** é um framework robusto de testes automatizados E2E (End-to-End) desenvolvido em C# com .NET 8, utilizando Playwright para automação web e NUnit como framework de testes. O projeto foi arquitetado seguindo as melhores práticas de Design Patterns e Clean Architecture para garantir manutenibilidade, escalabilidade e confiabilidade nos testes da aplicação web Custodia.

## 🏗️ Arquitetura do Projeto

### Estrutura de Diretórios

```
zCustodiaUi/
├── data/           # Data Objects e Test Data
├── locators/       # Page Objects Pattern - Elementos da UI
├── pages/          # Page Objects Pattern - Páginas e Métodos
├── runner/         # Configuração Base de Testes
├── tests/          # Casos de Teste Organizados por Funcionalidade
├── utils/          # Utilitários e Helpers Reutilizáveis
└── .github/        # CI/CD Pipeline
```

### Design Patterns Implementados

#### 🎯 Page Object Model (POM)
- **Locators**: Classes que armazenam seletores CSS/XPath dos elementos
- **Pages**: Classes que encapsulam a lógica de interação com as páginas
- **Data**: Classes que gerenciam dados de teste

#### 🔧 Singleton e Factory
- Configuração centralizada de browser e contexto
- Gerenciamento eficiente de recursos

#### 📦 Strategy Pattern
- Suporte a múltiplos ambientes (dev, staging, produção)

## 🛠️ Stack Tecnológico

| Componente | Versão | Finalidade |
|------------|--------|------------|
| .NET | 8.0 | Framework principal |
| Playwright | 1.55.0 | Automação web |
| NUnit | 3.13.3 | Framework de testes |
| Allure | 2.14.1 | Relatórios e documentação |
| Microsoft.Extensions.Configuration | 9.0.9 | Gerenciamento de configurações |


### Tipos de Testes

- **Testes Funcionais**: Validação de fluxos de negócio
- **Testes de Regressão**: Garantia de estabilidade
- **Testes Negativos**: Validação de cenários de erro
- **Testes de Carga**: Performance em múltiplos cenários

## 🎯 Boas Práticas Implementadas

### 🏛️ Clean Architecture
- Separação clara de responsabilidades
- Baixo acoplamento entre camadas
- Alta coesão funcional

### 🔒 Segurança
- Validação de dados sensíveis
- Ambiente isolado para testes

### 📊 Qualidade e Manutenibilidade
- Código documentado e autoexplicativo
- Nomenclatura padronizada
- Refatoração constante
- Code review integrado

### ⚡ Performance
- Execução paralela de testes
- Gerenciamento eficiente de recursos
- Timeout configurável para elementos

## 🔄 Fluxo de Execução

1. **Setup**: Inicialização do browser e contexto
2. **Configuração**: Leitura de ambiente e parâmetros
3. **Execução**: Rodar casos de teste com validações
4. **Teardown**: Limpeza de recursos e geração de evidências
5. **Relatório**: Compilação de resultados e métricas

## 📊 Relatórios e Evidências

### Allure Reports
- **Interface Intuitiva**: Dashboard interativo com métricas detalhadas
- **Evidências Visuais**: Vídeos anexados automaticamente
- **Categorização**: Testes organizados por severidade e suites
- **Histórico**: Comparação de execuções ao longo do tempo

### Recursos de Evidência
- 🎥 Vídeos de execução completa dos testes
- 📝 Logs detalhados com timestamps
- 🔍 Stack traces completas para debugging

## 📈 Métricas e KPIs

### Cobertura de Testes
- Funcionalidades críticas: 100%
- Fluxos principais: 95%
- Casos negativos: 85%

### Performance
- Tempo médio de execução: 8-15 minutos
- Paralelização: All threads simultâneos
- Estabilidade: 99.5% de sucesso

## 🛡️ Tratamento de Erros

### Logging Estruturado
- Níveis de log configuráveis
- Formatação padronizada
- Exportação para múltiplos formatos

## 📝 Contribuição

### Padrões de Código
- Seguir convenções C# Microsoft
- Utilizar async/await consistentemente
- Documentar métodos públicos

### Pull Request Process
1. Fork do repositório
2. Branch feature/nome-da-feature
3. Testes passando localmente
4. PR com descrição detalhada
5. Code review obrigatório

---

## 📊 Link Relatório

**Acesse os relatórios detalhados de execução dos testes:**
### [zitecai.github.io/ZCustodiaTestUi/](https://zitecai.github.io/ZCustodiaTestUi/)

---

## 📞 Contato e Suporte

- **Maintainer**: Levi Alves
- **Email**: al@zitec.ai

---

**© 2024 ZITEC AI - Todos os direitos reservados**

*Este projeto segue as diretrizes de qualidade e segurança da ZITEC AI, garantindo entregas de alta performance e confiabilidade.*
