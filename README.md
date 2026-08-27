# Oficina.Web

Sistema web para gerenciamento do fluxo operacional de uma oficina mecânica.

O projeto está sendo desenvolvido de forma incremental. O objetivo imediato é validar a experiência visual e o fluxo de trabalho antes de implementar o domínio completo, as regras de negócio e a persistência.

## Estado atual

O projeto está em estágio de **MVP visual parcialmente implementado**.

### Implementado

- aplicação Blazor Web App em .NET 10;
- ASP.NET Core e C#;
- Blazor Interactive Server nas áreas interativas;
- layout administrativo;
- navegação principal;
- Dashboard;
- `OficinaService` utilizado pelo Dashboard;
- modelo `Veiculo`;
- enum `StatusServico`, usado atualmente pela interface;
- páginas visuais dos módulos principais.

### Parcialmente implementado

- Dashboard com indicadores, filtros e dados simulados em memória;
- separação inicial entre páginas, modelo, serviço e dados;
- fluxo operacional representado visualmente.

### Apenas interface ou wireframe

As páginas de Clientes, Veículos, Orçamentos, Ordens de Serviço, Peças, Financeiro e Configurações possuem rotas, tabelas e controles visuais. Elas ainda usam dados demonstrativos e não oferecem CRUD ou operações reais.

### Ainda não implementado

- CRUD real;
- entidades completas de Cliente, Atendimento, Orçamento, Ordem de Serviço, Peças e Financeiro;
- regras reais de aprovação;
- regra operacional de entrada de 50%;
- solicitação e recebimento real de peças;
- pagamentos e finalização reais;
- persistência, `DbContext`, Entity Framework Core, Npgsql e PostgreSQL.

## Stack atual

- .NET 10;
- ASP.NET Core;
- Blazor Web App;
- Razor Components;
- Blazor Interactive Server;
- C#;
- Bootstrap;
- HTML5 e CSS3;
- Git e GitHub como ferramentas de versionamento e colaboração.

## Arquitetura

A aplicação mantém inicialmente uma arquitetura de **monólito modular**, com separação de responsabilidades e evolução incremental.

O fluxo técnico atual pode ser resumido como:

```text
Página Razor
    ↓
OficinaService, quando aplicável
    ↓
Dados simulados em memória
```

Serviços devem ser extraídos conforme existam regras ou consultas que justifiquem essa responsabilidade. Clean Code é uma diretriz de organização, não uma camada ou tecnologia adicional.

## Modelo funcional

O modelo conceitual oficial está documentado em [docs/mapa-minimo-consolidado.md](docs/mapa-minimo-consolidado.md).

```text
Cliente
└── Veículo
    └── Atendimento
        ├── Orçamentos
        │   └── Itens do orçamento
        ├── Ordem de Serviço
        │   └── Solicitações de peças
        └── Lançamentos financeiros
```

O Atendimento representa uma passagem ou caso específico de um veículo pela oficina. Cliente, Atendimento, Orçamento, Ordem de Serviço, Peças e Financeiro são conceitos do domínio e não devem ser considerados implementados apenas porque existem páginas correspondentes.

O fluxo funcional definido é:

```text
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
Finalização e entrega
```

Entrada e pagamentos pertencem à dimensão financeira do Atendimento. Não são, na arquitetura conceitual, simples estados operacionais do atendimento.

O `StatusServico` atual é uma implementação provisória utilizada pela interface. Ele não representa o modelo definitivo de estados do domínio. A futura implementação deverá separar as diferentes dimensões de estado conforme as regras reais forem definidas.

## Evolução planejada

1. consolidar modelos de Cliente, Veículo, Atendimento, Orçamento, itens, Ordem de Serviço, peças e lançamentos financeiros;
2. implementar cadastros e operações reais;
3. implementar aprovação, entrada, peças, execução, pagamentos e finalização;
4. adicionar persistência com Entity Framework Core, Npgsql e PostgreSQL;
5. ampliar o Dashboard para dados reais;
6. adicionar validações, testes e tratamento de erros.

Radzen poderá ser avaliado se Bootstrap deixar de atender uma necessidade concreta. Web API, Blazor WebAssembly, DDD formal, camadas formais, Repository Pattern, CQRS, MediatR, Unit of Work e Docker não são requisitos do MVP nem etapas obrigatórias.

## Documentação

- [Mapa funcional consolidado](docs/mapa-minimo-consolidado.md): referência atual do modelo funcional e do estado de implementação;
- [Stack recomendada](docs/stack-recomendada.md): decisões e possibilidades relacionadas à stack;
- [Planejamento recomendado](docs/planejamento-recomendado-oficina.md): documento histórico de planejamento;
- [Planejamento recomendado versão 2](docs/planejamento-recomendado-oficina-vs2.md): revisão histórica do planejamento.

Os documentos de planejamento permanecem como histórico. Quando houver conflito, o código atual e esta documentação consolidada devem ser consultados antes deles.

## Execução local

Dentro da pasta do projeto:

```powershell
dotnet restore
dotnet build
dotnet run
```

O endereço local será informado pelo .NET CLI.
