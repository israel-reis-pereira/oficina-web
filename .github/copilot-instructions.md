# Instruções do projeto Oficina.Web

## Contexto

Oficina.Web é um sistema web para gerenciamento da operação de uma oficina mecânica.

O projeto está sendo desenvolvido incrementalmente.

## Fonte de verdade

Ao analisar o projeto, priorize nesta ordem:

1. código atualmente implementado;
2. documentação atual consolidada;
3. decisões arquiteturais mais recentes;
4. documentos históricos de planejamento.

Documentos de planejamento antigos não devem ser tratados automaticamente como estado atual.

## Estado do projeto

Diferencie sempre:

- implementado;
- parcialmente implementado;
- definido;
- planejado;
- futuro.

Nunca declare uma funcionalidade como implementada apenas porque ela aparece em um documento de planejamento.

## Modelo funcional

Cliente
└── Veículo
    └── Atendimento
        ├── Orçamento
        │   └── Itens do orçamento
        ├── Ordem de Serviço
        │   └── Solicitações de peças
        └── Lançamentos financeiros

## Fluxo operacional

Cliente
↓
Veículo
↓
Atendimento
↓
Orçamento
↓
Aprovação
↓
Entrada de 50%
↓
Solicitação de peças
↓
Execução do serviço
↓
Pagamento
↓
Finalização

## Stack atual

- .NET 10
- ASP.NET Core
- Blazor Web App
- Razor Components
- Interactive Server
- Bootstrap
- C#
- Git
- GitHub

## Persistência planejada

- Entity Framework Core
- PostgreSQL
- Npgsql

Essas tecnologias não devem ser descritas como implementadas enquanto não existirem no projeto.

## Evolução futura

- ASP.NET Core Web API
- Blazor WebAssembly
- DDD
- arquitetura em camadas mais formal

## Regras

Não inventar funcionalidades.

Não implementar código quando a tarefa for exclusivamente documental.

Não alterar arquitetura por iniciativa própria.

Quando houver conflito entre documentação e código, registrar o conflito antes de tomar uma decisão.

Preservar nomenclaturas existentes até que uma mudança seja explicitamente aprovada. StatusServico existente não deve ser tratado automaticamente como modelo definitivo; mudanças de nomenclatura ou estados devem seguir a documentação consolidada e uma decisão explícita.

Documentação deve refletir o projeto real.