# Oficina.Web

Sistema web para gerenciamento do fluxo operacional de uma oficina mecânica.

O projeto está sendo desenvolvido como um MVP incremental: primeiro validamos a experiência visual e o fluxo de trabalho; depois adicionamos persistência, regras de negócio e recursos mais avançados somente quando houver necessidade real.

> **Princípio técnico:** uma tecnologia pode ser tecnicamente possível sem ser tecnicamente necessária. A complexidade deve crescer junto com a necessidade do sistema.

---

## 1. Objetivo do projeto

O sistema deve apoiar o processo operacional da oficina:

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
Entrega do veículo
```

### Dados iniciais do atendimento

**Proprietário**
- Nome
- Telefone

**Veículo**
- Marca
- Placa
- Ano
- Cor

### Orçamento

O orçamento deverá permitir registrar, conforme os requisitos forem detalhados:
- Peças
- Serviços
- Mão de obra
- Valores
- Valor total
- Aprovação
- Entrada de 50%

---

## 2. Estado atual

O projeto já possui:

- projeto Blazor Web App criado;
- .NET 10;
- ASP.NET Core;
- Interactive Server;
- primeira página visual da oficina;
- Git e GitHub configurados;
- desenvolvimento independente de uma IDE específica;
- documentação inicial na pasta `docs/`.

O ambiente foi validado em duas máquinas.

### Ambiente de desenvolvimento atual

```text
Windows 10 Home Single Language 22H2
.NET SDK 10.0.400
Git 2.55.0
VS Code
C# Dev Kit
```

O Windows 10 atual é tratado como ambiente temporário de desenvolvimento. A transferência para uma máquina mais nova poderá ocorrer quando houver necessidade de desempenho ou quando o ambiente deixar de ser adequado.

---

## 3. Stack

### Stack atual

```text
.NET 10
ASP.NET Core
Blazor Web App
Razor Components
Blazor Interactive Server
Bootstrap
HTML5
CSS3
Git
GitHub
VS Code
```

### Persistência planejada

```text
Entity Framework Core
Npgsql
PostgreSQL
```

### UI planejada

```text
Bootstrap inicialmente
Radzen Blazor somente se trouxer ganho real de produtividade
```

### Evolução possível

```text
ASP.NET Core Web API
Blazor WebAssembly
DDD
Arquitetura em camadas mais formal
Repository/Service Pattern
```

Essas tecnologias não fazem parte do MVP por obrigação. Elas serão avaliadas conforme o domínio e os requisitos crescerem.

---

## 4. Arquitetura atual

A aplicação começa como um **monólito modular**.

A estrutura inicial deve permanecer simples:

```text
Oficina.Web
│
├── Components
│   ├── Layout
│   └── Pages
│
├── Models              # quando os modelos forem introduzidos
│
├── Services            # somente quando houver regras que justifiquem
│
├── Data                # quando a persistência for adicionada
│
├── wwwroot
│
├── Program.cs
├── Oficina.Web.csproj
└── docs
```

Não criar múltiplos projetos, API separada ou camadas formais antecipadamente.

A arquitetura deve **emergir das necessidades do domínio**, e não o contrário.

---

## 5. Régua para decisões técnicas

Antes de adicionar uma tecnologia, avaliar:

| Tecnologia / decisão | Pergunta |
|---|---|
| PostgreSQL | Já precisamos persistir dados reais? |
| EF Core | Já existe banco real para acessar? |
| Service | Existe regra de negócio suficiente para extrair? |
| Repository | Existe necessidade concreta de abstrair o acesso aos dados? |
| Radzen | Bootstrap deixou de ser produtivo para determinada interface? |
| Web API | Precisamos atender consumidores/clientes separados? |
| Blazor WebAssembly | Existe necessidade arquitetural para execução client-side/offline? |
| DDD | O domínio ficou complexo o suficiente para justificar? |
| Docker | A implantação ou desenvolvimento realmente exige? |

### Fora do MVP inicial

```text
Blazor WebAssembly
Web API
DDD formal
Repository obrigatório
Microservices
Docker
CQRS
MediatR
Unit of Work
```

Podem ser introduzidos posteriormente, mas somente mediante necessidade.

---

# 6. Plano de desenvolvimento

## Fase 0 — Ambiente

Objetivo: conseguir clonar, compilar e executar o projeto.

```text
Git
↓
.NET SDK
↓
clone
↓
restore
↓
build
↓
run
```

Status: **concluída**.

---

## Fase 1 — Base do projeto

Objetivo: manter uma base limpa e reproduzível.

Tarefas:

- confirmar Git;
- remover páginas de demonstração que não forem necessárias;
- preservar infraestrutura do Blazor;
- manter commits pequenos e objetivos;
- documentar decisões importantes.

Status: **em andamento**.

---

## Fase 2 — Layout

Objetivo: transformar a aplicação inicial em uma interface mínima e apresentável.

Primeira estrutura visual:

```text
┌──────────────────────────────────────────────────────┐
│ Oficina                              Usuário         │
├───────────────┬──────────────────────────────────────┤
│ Dashboard     │                                      │
│ Clientes      │  Resumo da oficina                  │
│ Veículos      │                                      │
│ Orçamentos    │  Veículos em atendimento             │
│ Serviços      │  Orçamentos pendentes                │
│ Peças         │  Serviços em execução                │
│ Financeiro    │                                      │
│ Configurações │                                      │
└───────────────┴──────────────────────────────────────┘
```

Inicialmente os dados podem ser fictícios.

O objetivo é validar:

- hierarquia visual;
- navegação;
- responsividade;
- organização das informações;
- experiência operacional.

Status: **próxima etapa**.

---

## Fase 3 — MVP visual

O sistema deve parecer minimamente um produto antes da implementação do banco.

Prioridades:

1. Header;
2. navegação;
3. layout responsivo;
4. Dashboard;
5. páginas principais;
6. cards;
7. tabelas;
8. badges de status;
9. formulários;
10. mensagens de sucesso/erro;
11. estados vazios;
12. dados fictícios coerentes.

Resultado esperado:

```text
Aplicação
↓
navegável
↓
visualmente consistente
↓
responsiva
↓
apresentável ao cliente
```

---

## Fase 4 — Publicação visual

Publicar uma primeira versão funcional **sem banco**.

Validar:

- aplicação inicia;
- Home funciona;
- menu funciona;
- rotas funcionam;
- CSS funciona;
- responsividade funciona.

Como o projeto usa Blazor Web App / Interactive Server, a publicação precisa de uma hospedagem capaz de executar ASP.NET Core. Não tratar esta etapa como um site estático de GitHub Pages.

---

## Fase 5 — Modelagem do domínio

Depois de validar a experiência visual:

```text
Cliente
Veículo
Orçamento
ItemOrcamento
Pagamento
```

Possivelmente:

```text
Peça
Serviço
```

A modelagem definitiva depende do detalhamento dos requisitos.

---

## Fase 6 — Persistência

Quando os modelos estiverem suficientemente definidos:

```text
ASP.NET Core
      ↓
EF Core
      ↓
Npgsql
      ↓
PostgreSQL
```

Adicionar:

- DbContext;
- entidades;
- relacionamentos;
- migrations;
- configuração de conexão;
- persistência.

Não criar abstrações desnecessárias antes de conhecer o acesso real aos dados.

---

## Fase 7 — Cadastros reais

Implementar primeiro:

```text
Cliente
   +
Veículo
```

O cadastro deve refletir o fluxo real de atendimento da oficina.

---

## Fase 8 — Orçamento

Implementar:

```text
Peças
Serviços
Mão de obra
Subtotal
Total
Aprovação
```

A interface deve permitir compreender rapidamente o valor do serviço.

---

## Fase 9 — Fluxo operacional

Implementar os estados do serviço:

```text
Cadastro realizado
       ↓
Orçamento em análise
       ↓
Aguardando entrada
       ↓
Peças solicitadas
       ↓
Em execução
       ↓
Aguardando pagamento restante
       ↓
Finalizado / entregue
```

Os nomes definitivos dos estados devem seguir o domínio real.

---

## Fase 10 — Regra dos 50%

Após aprovação:

```text
Valor total
     ↓
50%
     ↓
Entrada
```

Exemplo:

```text
Orçamento: R$ 2.000,00
Entrada:   R$ 1.000,00
Restante:  R$ 1.000,00
```

A regra deve impedir que o fluxo avance para o pedido das peças sem que o recebimento da entrada esteja devidamente registrado.

A implementação da regra deve ser feita quando tivermos o modelo de dados e o fluxo real definidos.

---

## Fase 11 — Dashboard real

Depois que houver dados reais:

```text
Dashboard
├── veículos em atendimento
├── orçamentos pendentes
├── aguardando entrada
├── peças aguardando pedido
├── serviços em execução
├── pagamentos pendentes
└── veículos prontos
```

Aqui o dashboard deixa de ser apenas visual e passa a representar o estado real da oficina.

---

## Fase 12 — Refinamento

Somente após o MVP funcional:

- validações;
- segurança;
- logs;
- tratamento de erros;
- melhoria de UX;
- Radzen onde fizer sentido;
- serviços para regras de negócio;
- refatoração;
- testes;
- melhorias de arquitetura.

---

# 7. Fluxo de desenvolvimento

Para cada funcionalidade:

```text
Requisito
   ↓
Entender o problema
   ↓
Definir UX
   ↓
Implementar o mínimo
   ↓
Executar localmente
   ↓
Testar
   ↓
Revisar código
   ↓
Commit
   ↓
Push
```

Não começar pela tecnologia.

Começar pela necessidade.

---

# 8. Git

Verificar estado:

```powershell
git status
```

Atualizar:

```powershell
git pull
```

Executar:

```powershell
dotnet restore
dotnet build
dotnet run
```

Registrar alterações:

```powershell
git add .
git commit -m "tipo: descrição"
git push
```

Exemplos:

```text
feat: cria dashboard inicial
feat: adiciona navegação da oficina
style: ajusta layout do dashboard
refactor: reorganiza componentes
docs: atualiza planejamento
fix: corrige navegação
```

Evitar commits genéricos como:

```text
update
alterações
coisas
teste
```

---

# 9. Como executar localmente

Dentro da pasta do projeto:

```powershell
cd "C:\Users\Williarts\Downloads\teste\oficina-web"
```

Restaurar dependências:

```powershell
dotnet restore
```

Compilar:

```powershell
dotnet build
```

Executar:

```powershell
dotnet run
```

O terminal informará o endereço local, por exemplo:

```text
http://localhost:5276
```

Para encerrar:

```text
Ctrl + C
```

---

# 10. Desenvolvimento com VS Code

Abrir o projeto:

```powershell
code .
```

Extensão utilizada:

```text
C# Dev Kit
```

O projeto deve ser reconhecido pelo arquivo:

```text
Oficina.Web.csproj
```

O VS Code não é requisito arquitetural. O projeto continua independente da IDE porque sua compilação e execução são realizadas pelo .NET CLI.

Isso permite trabalhar futuramente com:

```text
VS Code
Visual Studio
ou outra ferramenta compatível
```

sem converter o projeto.

---

# 11. Estado atual do Git

Commits iniciais:

```text
chore: inicializa projeto Blazor
feat: cria página inicial da oficina
```

O próximo desenvolvimento deve continuar a partir desse estado.

Antes de iniciar uma nova tarefa:

```powershell
git status
git pull
```

---

# 12. Documentação

A pasta `docs/` contém documentos de planejamento e decisões técnicas.

Arquivos atualmente relacionados ao planejamento:

```text
docs/
├── mapeamento-recomendado-aimode.md
├── stack-recomendada-oficina.md
├── planejamento-recomendado-oficina.md
└── planejamento-recomendado-oficina-vs2.md
```

Esses documentos devem ser considerados material de planejamento, não especificações imutáveis.

Quando uma decisão mudar, atualizar a documentação correspondente.

O `README.md` apresenta a visão consolidada do projeto.

---

# 13. Próxima tarefa

A próxima tarefa concreta é:

## Construir a base visual do sistema

Ordem recomendada:

```text
1. Limpar páginas demonstrativas desnecessárias
        ↓
2. Definir Layout principal
        ↓
3. Criar Header
        ↓
4. Criar navegação lateral/menu
        ↓
5. Criar área principal
        ↓
6. Criar Dashboard
        ↓
7. Criar cards de resumo
        ↓
8. Criar tabela/lista de veículos
        ↓
9. Criar estados visuais
        ↓
10. Tornar responsivo
        ↓
11. Executar e revisar
        ↓
12. Commit
```

### Dados fictícios iniciais

Podemos utilizar temporariamente dados como:

```text
Cliente:
João da Silva

Telefone:
(17) 99999-9999

Veículo:
Honda Civic
ABC1D23
2020
Prata
```

Esses dados são apenas para validar a interface e não representam dados reais.

---

# 14. O que não fazer agora

Não adicionar ainda:

```text
❌ PostgreSQL
❌ EF Core
❌ API
❌ Blazor WebAssembly
❌ DDD
❌ Repository Pattern
❌ Docker
❌ CQRS
❌ MediatR
❌ autenticação complexa
```

A prioridade imediata é:

```text
LAYOUT
↓
NAVEGAÇÃO
↓
UX
↓
MVP VISUAL
↓
PUBLICAÇÃO
```

Depois:

```text
MODELO
↓
BANCO
↓
DADOS REAIS
↓
REGRAS
↓
FLUXO
```

---

## Princípio central

> **Construir a menor solução capaz de resolver o problema atual e deixar espaço para evoluir quando a necessidade aparecer.**

A arquitetura deve acompanhar a complexidade do negócio.

Não devemos construir uma arquitetura complexa para provar que sabemos construir uma arquitetura complexa.
