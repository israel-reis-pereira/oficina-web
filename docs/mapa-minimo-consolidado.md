# Mapa funcional consolidado

Este documento é a referência funcional consolidada do Oficina.Web. Ele descreve o modelo conceitual aprovado e diferencia o que existe no código do que ainda está planejado.

## 1. Objetivo

O sistema deve apoiar a operação de uma oficina mecânica, acompanhando a passagem dos veículos pela oficina desde o cadastro até a finalização do atendimento.

## 2. Modelo conceitual oficial

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

O Atendimento representa uma passagem ou caso específico de um veículo pela oficina. Ele evita concentrar todo o histórico e o estado operacional diretamente no veículo.

Este é um modelo conceitual definido. Ele ainda não corresponde a entidades completas implementadas no código.

## 3. Fluxo operacional

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

O fluxo acima é uma definição funcional. As transições, validações e bloqueios ainda não estão implementados.

Entrada e pagamentos são responsabilidades da dimensão financeira relacionada ao Atendimento. Não devem ser tratados como simples estados operacionais do atendimento.

## 4. Módulos e responsabilidades

### Dashboard

Apresentar a visão operacional da oficina, incluindo veículos em atendimento, orçamentos pendentes, entradas pendentes, serviços em execução e alertas.

**Estado atual:** parcialmente implementado. A tela possui indicadores, filtro e dados simulados em memória. O Dashboard utiliza `OficinaService`.

### Clientes

Cadastrar e consultar clientes e seus dados de contato.

**Estado atual:** apenas interface/wireframe. A rota e a tabela demonstrativa existem, mas não há cadastro ou consulta real.

### Veículos

Cadastrar veículos e relacioná-los aos clientes e aos atendimentos.

**Estado atual:** parcialmente implementado como modelo e interface demonstrativos. Existe `Veiculo`, mas não existe relacionamento de domínio completo com Cliente e Atendimento.

### Atendimentos

Representar cada passagem específica do veículo pela oficina e concentrar as referências ao orçamento, à ordem de serviço e aos lançamentos financeiros.

**Estado atual:** planejado. Não há entidade ou tela funcional de Atendimento.

### Orçamentos

Registrar peças, serviços, mão de obra, valores, total e decisão de aprovação.

**Estado atual:** apenas interface/wireframe. Não há entidade, itens, cálculo persistente ou aprovação real.

### Ordens de Serviço

Acompanhar a execução técnica dos serviços vinculados ao Atendimento.

**Estado atual:** apenas interface/wireframe. Não há entidade nem atualização real do serviço.

### Peças

Registrar solicitações de peças e acompanhar pedido, recebimento e vínculo com a Ordem de Serviço.

**Estado atual:** apenas interface/wireframe. Não há fluxo real de solicitação ou recebimento.

### Financeiro

Registrar entradas, pagamentos, saldos e demais lançamentos financeiros relacionados ao Atendimento.

**Estado atual:** apenas interface/wireframe. Não há lançamentos ou pagamentos reais.

### Configurações

Manter dados e preferências gerais da oficina.

**Estado atual:** apenas interface demonstrativa. Os campos e ações não persistem alterações.

## 5. Estado atual da implementação

O projeto está em estágio de **MVP visual parcialmente implementado**.

### Implementado

- aplicação Blazor Web App;
- .NET 10, ASP.NET Core e C#;
- Interactive Server nas áreas interativas;
- layout administrativo;
- navegação principal;
- Dashboard visual;
- `OficinaService` utilizado pelo Dashboard;
- modelo `Veiculo` provisório;
- `StatusServico` atualmente utilizado pela interface;
- rotas e páginas visuais dos módulos principais.

### Parcialmente implementado

- Dashboard com dados simulados;
- consultas operacionais em memória;
- filtro de veículos por `StatusServico`;
- cálculo visual de 50% do orçamento para entradas pendentes;
- separação inicial entre apresentação, serviço e dados no Dashboard.

### Não implementado como domínio funcional

- CRUD real;
- Cliente, Atendimento, Orçamento, itens, Ordem de Serviço, Peças e Financeiro como entidades completas;
- persistência e banco de dados;
- Entity Framework Core, Npgsql, PostgreSQL e `DbContext`;
- aprovação e recusa reais de orçamento;
- registro e validação de entrada;
- bloqueio do pedido de peças sem entrada registrada;
- solicitação e recebimento de peças;
- pagamentos, saldo e finalização reais.

## 6. Status

O código possui o enum `StatusServico`, usado atualmente para apresentação e consultas do Dashboard. Ele é uma implementação provisória da interface, não o modelo definitivo do domínio.

A futura modelagem deverá separar as diferentes dimensões de estado, incluindo o estado operacional do atendimento e a situação financeira. A lista definitiva de estados e suas transições ainda precisa ser validada quando o domínio funcional for implementado.

## 7. Arquitetura atual

A aplicação utiliza inicialmente um monólito modular:

```text
Página Razor
    ↓
OficinaService, quando aplicável
    ↓
Dados simulados em memória
```

As páginas cuidam da apresentação e do estado da interface. O serviço concentra consultas e critérios operacionais quando essa separação já foi aplicada. Serviços adicionais devem surgir conforme houver regras ou consultas que justifiquem sua extração.

Bootstrap permanece como base visual inicial. Clean Code é uma diretriz de organização e não implica adoção de DDD ou camadas formais.

## 8. Evolução planejada

1. validar e refinar a experiência visual;
2. definir os modelos de domínio e seus relacionamentos;
3. implementar cadastros e operações reais;
4. implementar as regras de aprovação, entrada, peças, execução, pagamento e finalização;
5. adicionar persistência com EF Core, Npgsql e PostgreSQL;
6. substituir dados simulados por dados reais;
7. adicionar validações, testes e tratamento de erros.

Radzen, Web API, Blazor WebAssembly, DDD formal e arquitetura em camadas permanecem possibilidades futuras, condicionadas a necessidade concreta. Repository Pattern, CQRS, MediatR, Unit of Work e Docker não são etapas obrigatórias do MVP.

## 9. Documentos relacionados

- [README.md](../README.md): visão resumida do projeto;
- [stack-recomendada.md](stack-recomendada.md): stack e possibilidades técnicas;
- [planejamento-recomendado-oficina.md](planejamento-recomendado-oficina.md): planejamento histórico;
- [planejamento-recomendado-oficina-vs2.md](planejamento-recomendado-oficina-vs2.md): revisão histórica do planejamento.
