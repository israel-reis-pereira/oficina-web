Analisei a máquina, a stack que você recebeu, o processo do cliente e também o estado atual do repositório `israel-reis-pereira/oficina-web`. O ponto mais importante apareceu antes mesmo de entrar na arquitetura:

**o PC de trabalho é hoje o maior risco do projeto, não a stack.**

O projeto está corretamente iniciado em `net10.0` e já está configurado como Blazor Web App com componentes interativos no servidor.   O problema é que sua máquina tem **i7-7500U + 8 GB RAM + Windows 10 Home 22H2**, e o Windows 10 Home 22H2 terminou o suporte em **14 de outubro de 2025**. Além disso, a documentação atual do .NET limita o suporte do .NET 10 em Windows 10 às edições LTSC/Enterprise, não ao seu Windows 10 Home. ([Microsoft Learn][1])

Portanto, eu não trataria essa máquina como ambiente definitivo para um projeto novo em .NET 10.

---

# 1. Diagnóstico da máquina

Sua máquina:

| Componente     | Situação                      |
| -------------- | ----------------------------- |
| CPU            | i7-7500U, 2C/4T               |
| RAM            | 8 GB                          |
| SSD            | 240 GB                        |
| GPU            | Radeon R7 M340 + Intel HD 620 |
| SO             | Windows 10 Home 22H2          |
| Arquitetura    | x64                           |
| Projeto        | .NET 10 / Blazor              |
| IDE pretendida | Visual Studio 2026            |

### CPU

O i7-7500U é um processador de baixo consumo de uma geração antiga, com apenas:

**2 núcleos / 4 threads.**

Para editar Razor, compilar pequenos projetos e trabalhar com Git, ele ainda funciona.

Mas quando começar a combinar:

```text
Visual Studio
+
ASP.NET Core
+
 navegador
+
 PostgreSQL
+
 Docker
+
 Radzen
+
 Git
```

você vai começar a sentir bastante a limitação.

---

# 2. O problema maior: 8 GB de RAM

Para o projeto inicial, 8 GB ainda são suficientes.

Mas para desenvolvimento profissional:

**8 GB é pouco.**

A própria Microsoft recomenda **16 GB para uma solução profissional típica no Visual Studio 2026**, e afirma que o Visual Studio funciona melhor com hardware muito mais poderoso. ([Microsoft Learn][2])

Então eu classificaria:

### 8 GB

**Funciona:** sim.

**Confortável:** não.

**Adequado para desenvolvimento pesado:** não.

---

# 3. O SSD também virou um gargalo

Seu SSD tem:

**240 GB nominais.**

Na prática você provavelmente tem algo próximo de 223 GB utilizáveis.

E agora imagine:

```text
Windows
Visual Studio
.NET SDKs
NuGet cache
Git
Node
PostgreSQL
Docker
navegador
projeto
build
obj
bin
logs
backups
```

Você pode consumir boa parte rapidamente.

Eu evitaria instalar qualquer coisa desnecessária nesse computador.

---

# 4. O problema crítico: Windows 10

Aqui precisamos ser bem técnicos.

Seu sistema é:

**Windows 10 Home 22H2.**

O suporte dessa versão terminou em:

**14/10/2025.** ([Microsoft Learn][1])

E hoje estamos em agosto de 2026.

Portanto, essa máquina está rodando um sistema operacional que já saiu do suporte.

Mais importante:

A documentação atual de instalação do .NET informa que **Windows 10 só é suportado para versões modernas do .NET nas edições LTSC/Enterprise**, não no Home que você possui. ([Microsoft Learn][3])

Isso muda minha recomendação.

---

# 5. E o Visual Studio 2026?

Aqui há uma situação meio confusa porque existem páginas diferentes da Microsoft com informações de compatibilidade diferentes.

A página de requisitos atual do Visual Studio 2026 lista **Windows 11 como sistema operacional suportado**, além de recomendar 16 GB de RAM para uso profissional. ([Microsoft Learn][2])

Além disso, o .NET 10 exige Visual Studio 2026 versão 18.0 ou superior para integração completa do SDK. ([Microsoft Learn][4])

Então:

```text
.NET 10
   ↓
Visual Studio 2026
   ↓
Windows 11
```

é a combinação que eu consideraria oficialmente adequada.

---

# 6. Só que seu i7-7500U cria outro problema

Seu processador é de **7ª geração**.

Ele não está na lista oficial de CPUs suportadas pelo Windows 11.

Logo você está diante de:

```text
Notebook antigo
      ↓
Windows 10
      ↓
fim do suporte
      ↓
Windows 11 não é oficialmente suportado
      ↓
.NET 10 também não é oficialmente suportado nesse Windows 10 Home
```

Portanto, **não recomendo simplesmente tentar "forçar" Windows 11 nesse notebook para resolver isso.**

Pode funcionar tecnicamente, mas seria uma solução ruim para uma máquina de trabalho.

---

# 7. O que eu faria com esse computador

Eu dividiria em duas possibilidades.

## Cenário A — você pode mudar o sistema operacional

A solução mais interessante seria:

### Linux

Por exemplo:

**Ubuntu LTS.**

Nesse caso você poderia ter:

```text
Linux
│
├── .NET 10
├── ASP.NET Core
├── Blazor
├── PostgreSQL
├── Git
├── VS Code
└── navegador
```

Isso é particularmente interessante porque você elimina boa parte do peso do Windows + Visual Studio.

Porém:

**você perderia a experiência do Visual Studio 2026.**

E Radzen para Visual Studio também deixaria de ser uma opção, embora o Radzen Blazor Studio tenha suporte a Linux e o ecossistema Blazor continue disponível. ([Radzen.com][5])

---

# 8. Cenário B — o notebook é controlado pela empresa

Nesse caso eu **não mexeria no Windows sem autorização**.

Usaria essa máquina como:

**máquina secundária de desenvolvimento.**

E faria o desenvolvimento principal no computador novo que você mencionou anteriormente.

Isso é muito mais coerente.

O fluxo seria:

```text
Notebook novo
    ↓
desenvolvimento principal
    ↓
Git
    ↓
GitHub
    ↓
Notebook antigo
    ↓
testes / manutenção / pequenos ajustes
```

Isso também é melhor profissionalmente.

---

# 9. Agora vamos ao seu projeto

Aqui está uma boa notícia:

### A arquitetura inicial escolhida pelo seu colega faz sentido.

Seu projeto atual contém:

```text
Oficina.Web
    ├── Components
    ├── Pages
    ├── Layout
    ├── Program.cs
    ├── appsettings.json
    └── wwwroot
```

e o `.csproj` já está em:

```xml
<TargetFramework>net10.0</TargetFramework>
```

com:

```text
Razor Components
Interactive Server
```

Isso está coerente com o modelo atual do Blazor.

O projeto neste momento ainda está basicamente no estado inicial do template, contendo páginas de demonstração como `Counter`, `Weather`, `Home`, etc.

Portanto:

**não há necessidade de reconstruir o projeto.**

---

# 10. A stack proposta

Você recebeu isso:

```text
.NET 10
ASP.NET Core
Blazor Web App
Blazor Interactive Server
Razor Components
Bootstrap
HTML5
CSS3
Git
GitHub
Visual Studio 2026

Futuro:
EF Core
PostgreSQL
Radzen
ASP.NET Core Web API
Blazor WebAssembly
DDD
Arquitetura em camadas
Repository/Service
```

Minha avaliação:

| Tecnologia         | Decisão                                  |
| ------------------ | ---------------------------------------- |
| .NET 10            | **Manter**                               |
| ASP.NET Core       | **Manter**                               |
| Blazor Web App     | **Manter**                               |
| Interactive Server | **Manter inicialmente**                  |
| Razor Components   | **Manter**                               |
| HTML/CSS           | **Manter**                               |
| Bootstrap          | **Pode manter**                          |
| Git                | **Obrigatório**                          |
| GitHub             | **Manter**                               |
| EF Core            | **Adicionar quando houver persistência** |
| PostgreSQL         | **Boa escolha**                          |
| Radzen             | **Adicionar depois do layout base**      |
| Web API            | **Não adicionar inicialmente**           |
| Blazor WASM        | **Não adicionar inicialmente**           |
| DDD                | **Não adicionar inicialmente**           |
| Repository Pattern | **Não adicionar artificialmente**        |
| Service Layer      | **Adicionar quando houver regras**       |
| Clean Code         | **Desde já**                             |

---

# 11. A principal alteração que eu faria

Eu **não transformaria agora** o projeto em:

```text
Frontend
Backend
API
Banco
Repository
Services
DDD
WASM
```

Isso seria arquitetura demais para o problema atual.

O cliente não pediu um sistema bancário.

Ele pediu:

> Cadastro → Orçamento → Aprovação → Entrada → Peças → Serviço → Pagamento → Entrega.

Isso é relativamente pequeno.

---

# 12. O próprio Blazor Web App já resolve boa parte

Você tem:

```text
Browser
   ↓
Blazor Web App
   ↓
ASP.NET Core
   ↓
Services
   ↓
EF Core
   ↓
PostgreSQL
```

Sem precisar inicialmente de:

```text
Browser
 ↓
Blazor WASM
 ↓
HTTP
 ↓
Web API
 ↓
Service
 ↓
Repository
 ↓
EF
 ↓
PostgreSQL
```

A segunda arquitetura aumenta bastante a quantidade de código.

---

# 13. Interactive Server é uma excelente escolha para esse sistema

Esse sistema parece ser uma aplicação interna de oficina.

Isso combina muito bem com:

**Interactive Server.**

No modo interativo de servidor, a lógica fica no servidor e o navegador se comunica com ele por uma conexão em tempo real. ([Microsoft Learn][6])

Isso significa:

```text
Computador da oficina
       ↓
 Navegador
       ↓
Blazor Server
       ↓
 PostgreSQL
```

Excelente para:

* formulários;
* cadastro;
* orçamento;
* tabela;
* edição;
* filtros;
* status;
* dashboard;
* operações administrativas.

---

# 14. Quando WebAssembly faria sentido?

Somente quando existir uma necessidade concreta.

Por exemplo:

```text
Aplicativo extremamente cliente-side
```

ou:

```text
parte do sistema funcionando offline
```

ou:

```text
frontend separado do backend
```

ou:

```text
arquitetura distribuída
```

Nada disso aparece nos requisitos atuais.

Então:

### NÃO adicione Blazor WebAssembly agora.

O próprio Blazor atual permite diferentes modos de renderização, incluindo Server, WebAssembly e Auto, então vocês podem migrar uma parte posteriormente sem precisar decidir tudo agora. ([Microsoft Learn][7])

---

# 15. E a Web API?

Mesma situação.

Não existe nenhuma necessidade imediata de:

```text
Oficina.Web
Oficina.Api
```

Eu começaria com:

```text
Oficina.Web
```

E deixaria a API como uma possível evolução.

---

# 16. PostgreSQL

Aqui eu concordo com seu colega.

**PostgreSQL é uma ótima escolha.**

E o ecossistema Npgsql possui provider oficial para Entity Framework Core, inclusive existe versão 10.0 do provider compatível com EF Core 10. ([Npgsql][8])

Então:

```text
ASP.NET Core
     ↓
EF Core 10
     ↓
Npgsql
     ↓
PostgreSQL
```

é tecnicamente uma combinação coerente.

---

# 17. Radzen

Também faz sentido.

Radzen fornece componentes específicos para Blazor e possui suporte documentado para .NET 10. ([Radzen Blazor Components][9])

É especialmente útil para:

* DataGrid;
* Dialog;
* formulário;
* dropdown;
* notificações;
* tabelas;
* filtros.

E isso combina muito com uma oficina.

Mas eu não colocaria Radzen **antes de saber o design visual**.

Primeiro:

```text
HTML
CSS
Bootstrap
```

depois:

```text
Radzen
```

onde realmente trouxer produtividade.

---

# 18. Agora precisamos transformar o processo do cliente em domínio

O fluxo informado foi:

```text
Cadastro
   ↓
Orçamento
   ↓
Aprovação
   ↓
50% de entrada
   ↓
Pedido das peças
   ↓
Execução do serviço
   ↓
Pagamento restante
   ↓
Entrega
```

Isso é muito bom.

Porque podemos transformar isso em estados do sistema.

Por exemplo:

```text
Novo
↓
Orçamento
↓
Aguardando aprovação
↓
Aprovado
↓
Aguardando entrada
↓
Entrada recebida
↓
Aguardando peças
↓
Em execução
↓
Aguardando pagamento
↓
Pronto para entrega
↓
Entregue
```

Essa será provavelmente a parte central do sistema.

---

# 19. Só que existe um detalhe no requisito

O cliente disse:

> "Nome e telefone Marca do carro placa ano cor"

Isso provavelmente significa que vocês precisam separar:

### Cliente

```text
Cliente
- Id
- Nome
- Telefone
```

de:

### Veículo

```text
Veículo
- Id
- ClienteId
- Marca
- Modelo
- Placa
- Ano
- Cor
```

E não colocar tudo dentro de "Cadastro".

Isso permite:

```text
João
 ├── Honda Civic
 └── Fiat Strada
```

por exemplo.

Mesmo que inicialmente a oficina tenha poucos clientes, essa modelagem evita um problema futuro.

---

# 20. Orçamento

Depois temos:

```text
Orçamento
```

Que precisa possuir algo semelhante a:

```text
Id
Cliente/Veículo
Data
Validade
Status
SubtotalPeças
SubtotalServiços
Desconto
Total
PercentualEntrada
ValorEntrada
Saldo
Observações
```

E principalmente:

### Itens do orçamento.

Porque:

```text
Orçamento
 ├── Pastilha de freio
 ├── Disco de freio
 ├── Óleo
 └── Mão de obra
```

não deve ser apenas um campo:

```text
Valor = R$ 2.000
```

---

# 21. Peças e serviços

Eu separaria:

```text
ItemOrcamento
```

com:

```text
Tipo = Peça
Tipo = Serviço
```

ou, dependendo da evolução:

```text
Peca
Servico
OrcamentoItem
```

No começo eu prefiro o modelo mais simples.

---

# 22. O processo financeiro

O cliente estabeleceu uma regra:

### 50% de entrada.

Então o sistema deve calcular:

```text
Total = R$ 2.000

Entrada:
50% = R$ 1.000

Saldo:
R$ 1.000
```

E não permitir que o usuário simplesmente digite valores incompatíveis sem controle.

Isso é uma **regra de negócio**, e regras assim serão posteriormente ótimos candidatos a uma camada de serviço.

---

# 23. Mas não coloque Service Pattern agora

Primeiro faça funcionar.

Depois, quando tivermos:

```text
AprovarOrcamento()
RegistrarEntrada()
LiberarPedidoDePecas()
FinalizarServico()
RegistrarPagamento()
EntregarVeiculo()
```

começamos a extrair as regras.

A arquitetura emerge do domínio.

Não o contrário.

---

# 24. O planejamento que eu recomendo

Agora chegamos à parte principal que você pediu.

Eu faria o projeto nesta sequência.

---

## FASE 0 — Ambiente

Objetivo:

**conseguir desenvolver e executar o projeto de forma confiável.**

### No PC

Primeiro verificar:

```text
dotnet --version
dotnet --list-sdks
git --version
git status
```

Depois verificar:

```text
Visual Studio
.NET SDK
Git
```

Mas existe uma ressalva:

**não considero esse Windows 10 Home um ambiente adequado para manter o projeto .NET 10 a longo prazo.**

O .NET 10 é LTS até novembro de 2028, mas seu sistema operacional já está fora do suporte. ([Microsoft Learn][10])

---

# FASE 1 — Congelar o ponto inicial

Antes de mexer em arquitetura:

```text
git status
```

e criar um commit limpo:

```text
chore: prepara base do projeto oficina
```

Depois trabalhar em branches:

```text
main
develop
feature/layout
feature/domain
feature/database
feature/workflow
```

Para seu tamanho de projeto, até:

```text
main
feature/*
```

já é suficiente.

---

# FASE 2 — Limpeza do template

Remover:

```text
Counter
Weather
outras páginas de demonstração
```

Manter:

```text
App
Routes
Layout
Error
NotFound
```

Porque fazem parte da infraestrutura do Blazor.

O repositório hoje ainda contém essas páginas demonstrativas.

---

# FASE 3 — Layout

Aqui ainda **não existe banco**.

Nada de EF.

Nada de PostgreSQL.

Nada de API.

Nada de DDD.

Construir:

```text
Dashboard
Clientes
Veículos
Orçamentos
Serviços
Peças
Financeiro
Configurações
```

Mas inicialmente com dados falsos.

Por exemplo:

```text
Cliente
João da Silva
(17) 99999-9999

Veículo
Honda Civic
ABC1D23
2020
Prata
```

---

# FASE 4 — Design System

Definir:

```text
cores
tipografia
espaçamentos
botões
cards
tabelas
inputs
badges
status
modal
alertas
```

Aqui Bootstrap pode ajudar.

Radzen pode entrar posteriormente.

---

# FASE 5 — Primeiro "MVP visual"

Nesse momento o sistema precisa parecer um produto.

Algo assim:

```text
┌─────────────────────────────────────────────┐
│ Oficina                     Usuário         │
├──────────────┬──────────────────────────────┤
│ Dashboard    │                              │
│ Clientes     │  Veículos em manutenção      │
│ Orçamentos   │                              │
│ Serviços     │  Orçamentos pendentes        │
│ Financeiro   │                              │
└──────────────┴──────────────────────────────┘
```

Tudo falso.

Mas navegável.

---

# FASE 6 — Publicação do layout

Aqui vocês podem publicar a aplicação inicial **sem banco**, mas precisamos diferenciar duas coisas.

Como o projeto é **Blazor Web App / Interactive Server**, ele não é simplesmente um conjunto de arquivos estáticos para colocar no GitHub Pages.

A publicação precisa ter um servidor ASP.NET Core.

Então:

```text
GitHub
     ↓
Build
     ↓
ASP.NET Core
     ↓
Hospedagem
```

Nesta fase podemos publicar somente o layout e confirmar:

```text
Home funciona
Menu funciona
Rotas funcionam
CSS funciona
Responsividade funciona
```

**O banco ainda não precisa existir.**

---

# FASE 7 — Modelagem do domínio

Agora sim:

```text
Cliente
Veiculo
Orcamento
OrcamentoItem
Pagamento
```

E possivelmente:

```text
Peca
Servico
```

dependendo de como os requisitos forem detalhados.

---

# FASE 8 — Banco

Adicionar:

```text
Entity Framework Core
Npgsql
PostgreSQL
```

Estrutura:

```text
Oficina.Web
│
├── Components
├── Models
├── Data
├── Services
└── ...
```

Começaria simples.

Não criaria quatro projetos ainda.

---

# FASE 9 — Migrations

Criar:

```text
InitialCreate
```

Depois:

```text
Database
↓
Migration
↓
PostgreSQL
```

E testar:

```text
Create
Read
Update
Delete
```

---

# FASE 10 — Clientes

Primeiro módulo real:

```text
Clientes
```

Funcionalidades:

```text
Cadastrar
Listar
Editar
Visualizar
Pesquisar
```

---

# FASE 11 — Veículos

Depois:

```text
Cliente
   ↓
Veículos
```

Permitir vários veículos por cliente.

---

# FASE 12 — Orçamento

Criar:

```text
Novo orçamento
```

selecionando:

```text
Cliente
↓
Veículo
↓
Itens
↓
Serviços
↓
Peças
↓
Total
```

---

# FASE 13 — Aprovação

Adicionar:

```text
Status
```

e ações:

```text
Aprovar
Recusar
Cancelar
```

---

# FASE 14 — Entrada

Depois da aprovação:

```text
Total
↓
50%
↓
Entrada
```

Registrar:

```text
Data
Valor
Forma de pagamento
```

---

# FASE 15 — Peças

Depois da entrada:

```text
Aguardando peças
```

Criar acompanhamento:

```text
Pendente
Pedido
Recebido
```

---

# FASE 16 — Execução

Quando todas as peças estiverem disponíveis:

```text
Em execução
```

Depois:

```text
Serviço concluído
```

---

# FASE 17 — Pagamento final

Sistema calcula:

```text
Total
-
Entrada
=
Saldo
```

Registrar pagamento.

---

# FASE 18 — Entrega

Só permitir:

```text
Entregar veículo
```

quando:

```text
Serviço concluído
+
saldo quitado
```

estiverem satisfeitos.

Essa é uma regra importante do domínio.

---

# FASE 19 — Dashboard

Só depois que os dados forem reais.

Aí sim podemos apresentar:

```text
Orçamentos pendentes
Aguardando aprovação
Aguardando entrada
Aguardando peças
Em execução
Prontos para entrega
Valores a receber
```

---

# FASE 20 — Refinamento arquitetural

Só agora observar:

```text
O que está repetindo?
```

Se aparecer:

```text
regra complexa
```

criar:

```text
Services
```

Se aparecer:

```text
acesso repetitivo a dados
```

avaliar abstrações.

Se o domínio realmente crescer:

```text
DDD
```

Se surgir necessidade de:

```text
mobile
integração externa
frontend separado
```

aí:

```text
Web API
```

E se aparecer necessidade real:

```text
Blazor WebAssembly
```

---

# 25. Portanto, a arquitetura que eu usaria agora

Não seria a arquitetura "completa" da proposta.

Seria:

```text
                Oficina.Web
                     │
        ┌────────────┴────────────┐
        │                         │
    Components                  Models
        │                         │
     Pages                    Domain data
        │
     Services
        │
      EF Core
        │
     Npgsql
        │
    PostgreSQL
```

E posteriormente:

```text
                Oficina.Web
                     │
             ┌───────┴────────┐
             │                │
        Presentation       Application
             │                │
             └───────┬────────┘
                     │
                  Domain
                     │
               Infrastructure
                     │
                PostgreSQL
```

Essa segunda arquitetura nasce **quando houver necessidade**, não agora.

---

# 26. Minha ordem de tecnologia

Eu adotaria exatamente esta sequência:

```text
.NET 10
↓
ASP.NET Core
↓
Blazor Web App
↓
Interactive Server
↓
HTML
↓
CSS
↓
Bootstrap
↓
Git/GitHub
↓
Layout
↓
Publicação
↓
EF Core
↓
PostgreSQL
↓
Radzen
↓
Services
↓
Regras de negócio
↓
Dashboard
↓
Refatoração arquitetural
```

E deixaria **fora do MVP**:

```text
Blazor WebAssembly
Web API
DDD
Repository Pattern obrigatório
Microservices
Docker
Autenticação complexa
```

---

# 27. Uma decisão que eu mudaria na stack do colega

Eu escreveria a stack atual assim:

```text
## Stack atual

.NET 10
ASP.NET Core
Blazor Web App
Razor Components
Interactive Server
Bootstrap
HTML5
CSS3
Git
GitHub

## Persistência planejada

Entity Framework Core
PostgreSQL
Npgsql

## UI

Bootstrap inicialmente
Radzen Blazor conforme necessidade

## Arquitetura

Aplicação monolítica modular inicialmente
Serviços conforme regras de negócio
Separação de responsabilidades
Clean Code

## Evolução futura

ASP.NET Core Web API
Blazor WebAssembly
DDD
arquitetura em camadas mais formal
```

Eu evitaria chamar o projeto de **"monólito ruim"**. Um monólito pequeno e modular é exatamente o que faz sentido aqui.

---

# 28. O principal risco que eu vejo

Não é:

> "Será que Blazor é adequado?"

É:

> **"Será que estamos criando infraestrutura demais para um sistema pequeno?"**

O risco clássico seria:

```text
Cliente pediu uma oficina
      ↓
criamos DDD
      ↓
6 projetos
      ↓
API
      ↓
WASM
      ↓
Repository
      ↓
UnitOfWork
      ↓
CQRS
      ↓
MediatR
      ↓
Docker
      ↓
Kubernetes
```

e no fim:

**a tela de cadastrar cliente ainda não funciona.**

Eu evitaria isso completamente.

---

# 29. O que eu faria agora, concretamente

A sequência imediata seria:

### Passo 1

Resolver o ambiente.

**Não instalar ainda um monte de ferramentas nesse Windows 10.**

Primeiro verificar o que já existe na máquina:

```powershell
dotnet --version
dotnet --list-sdks
dotnet --list-runtimes
git --version
git status
```

### Passo 2

Confirmar o estado do projeto Git.

### Passo 3

Limpar o template.

### Passo 4

Criar a primeira estrutura visual.

### Passo 5

Executar e testar localmente.

### Passo 6

Commit.

### Passo 7

Publicar a primeira versão visual.

### Passo 8

Só então adicionar banco.

### Passo 9

Implementar Cliente → Veículo.

### Passo 10

Implementar Orçamento.

### Passo 11

Implementar o workflow.

---

## E um detalhe importante para o próximo passo

Você mencionou que **no próximo chat vai enviar as etapas recomendadas por outra IA**.

É exatamente isso que eu faria agora: **não devemos executar o plano que eu acabei de propor cegamente**.

Quando você enviar o plano da outra IA, eu vou comparar **etapa por etapa** com:

1. o requisito real do cliente;
2. a máquina disponível;
3. o estado atual do GitHub;
4. .NET 10/Blazor atual;
5. o custo de cada decisão arquitetural;
6. o que é necessário para o MVP;
7. o que é prematuro;
8. o que deve ser alterado ou removido.

Já encontrei uma conclusão concreta antes dessa comparação: **o projeto atual está corretamente iniciado em .NET 10 + Blazor Web App + Interactive Server, mas o Windows 10 Home dessa máquina não é um ambiente adequado para tratar .NET 10/Visual Studio 2026 como stack de longo prazo.**   ([Microsoft Learn][3])

Também vou preservar uma distinção importante durante a revisão: **"tecnicamente possível" não significa "vale a pena implementar agora".** Essa será a régua principal para decidir o que entra no projeto.

[1]: https://learn.microsoft.com/pt-br/lifecycle/announcements/windows-10-end-of-support?utm_source=chatgpt.com "Fim do suporte do Windows 10 - Microsoft Lifecycle | Microsoft Learn"
[2]: https://learn.microsoft.com/en-us/visualstudio/releases/2026/vs-system-requirements "https://learn.microsoft.com/en-us/visualstudio/releases/2026/vs-system-requirements"
[3]: https://learn.microsoft.com/pt-br/dotnet/core/install/windows?utm_source=chatgpt.com "Instalar .NET no Windows - .NET | Microsoft Learn"
[4]: https://learn.microsoft.com/en-us/dotnet/core/install/windows "https://learn.microsoft.com/en-us/dotnet/core/install/windows"
[5]: https://www.radzen.com/blazor-studio/documentation/install?utm_source=chatgpt.com "Installation | Radzen Blazor Studio Docs"
[6]: https://learn.microsoft.com/pt-pt/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0 "https://learn.microsoft.com/pt-pt/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0"
[7]: https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0 "https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0"
[8]: https://www.npgsql.org/efcore/release-notes/10.0.html?utm_source=chatgpt.com "10.0 Release Notes | Npgsql Documentation"
[9]: https://blazor.radzen.com/get-started?theme=default&utm_source=chatgpt.com "Get Started | Free UI Components by Radzen"
[10]: https://learn.microsoft.com/en-us/lifecycle/products/microsoft-net-and-net-core?utm_source=chatgpt.com "Microsoft .NET and .NET Core - Microsoft Lifecycle | Microsoft Learn"
