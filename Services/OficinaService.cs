/// <summary>
/// Pendente indica que a solicitação de peça ainda não foi processada.
/// Solicitada indica que a solicitação de peça foi enviada para o fornecedor.
/// Recebida indica que a peça solicitada foi recebida na oficina.
/// Cancelada indica que a solicitação de peça foi cancelada, seja por decisão do cliente ou por algum motivo interno da oficina.
/// </summary>

using Oficina.Web.Models;

namespace Oficina.Web.Services;

public sealed class OficinaService
{
    // Enquanto não existe persistência, os atendimentos demonstrativos preservam o grafo do domínio em memória.
    private static readonly IReadOnlyList<Atendimento> Atendimentos = Array.AsReadOnly(CriarAtendimentosDemonstracao());

    // O Dashboard ainda consome StatusServico. A conversão é temporária e fica centralizada nesta projeção.
    public IReadOnlyList<ResumoAtendimentoDashboard> ObterVeiculosEmAtendimento(StatusServico? filtroStatus = null) => ObterResumosAtendimentos()
        .Where(resumo => filtroStatus.HasValue
            ? resumo.Status == filtroStatus.Value
            : resumo.Status != StatusServico.Finalizado)
        .ToArray();

    public IReadOnlyList<ResumoAtendimentoDashboard> ObterOrcamentosPendentes() => ObterResumosAtendimentos()
        .Where(resumo => resumo.Status == StatusServico.OrcamentoEmAnalise)
        .ToArray();

    public IReadOnlyList<ResumoAtendimentoDashboard> ObterEntradasAguardandoPagamento() => ObterResumosAtendimentos()
        .Where(resumo => resumo.Status == StatusServico.AguardandoEntrada)
        .ToArray();

    public IReadOnlyList<ResumoAtendimentoDashboard> ObterVeiculosAguardandoPecas() => ObterResumosAtendimentos()
        .Where(resumo => resumo.Status == StatusServico.PecasSolicitadas)
        .ToArray();

    public IReadOnlyList<ResumoAtendimentoDashboard> ObterServicosEmExecucao() => ObterResumosAtendimentos()
        .Where(resumo => resumo.Status == StatusServico.EmExecucao)
        .ToArray();

    public IReadOnlyList<ResumoOrcamento> ObterOrcamentos() => Atendimentos
    .SelectMany(atendimento => atendimento.Orcamentos)
    .Select(orcamento => new ResumoOrcamento(
        $"ORC-{orcamento.Id.ToString()[..8].ToUpperInvariant()}",
        orcamento.Atendimento!.Veiculo!.Cliente!.Nome,
        orcamento.Atendimento.Veiculo.Descricao,
        orcamento.ValorTotal,
        orcamento.Status))
    .ToArray();

    public IReadOnlyList<ResumoOrdemServico> ObterOrdensServico() => Atendimentos
    .Where(atendimento => atendimento.OrdemServico is not null)
    .Select(atendimento => new ResumoOrdemServico(
        $"OS-{atendimento.OrdemServico!.Id.ToString()[..8].ToUpperInvariant()}",
        atendimento.Veiculo.Cliente.Nome,
        atendimento.Veiculo.Descricao,
        "Não definido",
        atendimento.OrdemServico.Status,
        atendimento.Orcamentos.LastOrDefault()?.ValorTotal ?? 0m))
    .ToArray();

    public IReadOnlyList<ResumoVeiculo> ObterVeiculos() => Atendimentos
    .Select(atendimento => new ResumoVeiculo(
        atendimento.Veiculo.Placa,
        atendimento.Veiculo.Descricao,
        atendimento.Veiculo.Cliente.Nome,
        ObterStatusDeApresentacao(atendimento)))
    .ToArray();

    public decimal ObterValorTotalEntradas() => ObterEntradasAguardandoPagamento()
        .Sum(resumo => resumo.ValorOrcamento / 2);

    private static IReadOnlyList<ResumoAtendimentoDashboard> ObterResumosAtendimentos() => Atendimentos
        .Select(atendimento => new ResumoAtendimentoDashboard(
            atendimento.Veiculo.Placa,
            atendimento.Veiculo.Descricao,
            atendimento.Veiculo.Cliente.Nome,
            atendimento.Orcamentos.LastOrDefault()?.ValorTotal ?? 0m,
            ObterStatusDeApresentacao(atendimento)))
        .ToArray();

    private static StatusServico ObterStatusDeApresentacao(Atendimento atendimento)
    {
        var orcamentoAtual = atendimento.Orcamentos.LastOrDefault();

        if (orcamentoAtual?.Status == StatusOrcamento.AguardandoAprovacao)
        {
            return StatusServico.OrcamentoEmAnalise;
        }

        if (orcamentoAtual?.Status == StatusOrcamento.Aprovado && atendimento.LancamentosFinanceiros.Any(lancamento =>
                lancamento.Tipo == TipoLancamentoFinanceiro.Entrada &&
                lancamento.Situacao == SituacaoFinanceira.Pendente))
        {
            return StatusServico.AguardandoEntrada;
        }

        if (atendimento.OrdemServico?.Status == StatusOrdemServico.AguardandoPecas)
        {
            return StatusServico.PecasSolicitadas;
        }

        if (atendimento.OrdemServico?.Status == StatusOrdemServico.EmExecucao)
        {
            return StatusServico.EmExecucao;
        }

        if (atendimento.OrdemServico?.Status == StatusOrdemServico.Concluida && atendimento.LancamentosFinanceiros.Any(lancamento =>
                lancamento.Tipo == TipoLancamentoFinanceiro.Pagamento &&
                lancamento.Situacao == SituacaoFinanceira.Pendente))
        {
            return StatusServico.AguardandoPagamento;
        }

        return atendimento.Status is StatusAtendimento.Finalizado or StatusAtendimento.Entregue
            ? StatusServico.Finalizado
            : StatusServico.CadastroRealizado;
    }

    private static Atendimento[] CriarAtendimentosDemonstracao() =>
    [
        CriarAtendimento("João da Silva", "(17) 99999-1234", "ABC1D23", "Honda Civic 2020", StatusAtendimento.AguardandoPecas, StatusOrcamento.Aprovado, 0m, StatusOrdemServico.AguardandoPecas, SituacaoSolicitacaoPeca.Solicitada),
        CriarAtendimento("Carlos Mendes", "(17) 98888-5678", "DEF4G56", "Toyota Corolla 2021", StatusAtendimento.EmOrcamento, StatusOrcamento.Aprovado, 2400m, situacaoEntrada: SituacaoFinanceira.Pendente),
        CriarAtendimento("Ana Pereira", "(17) 97777-9012", "HIJ7K89", "Volkswagen T-Cross 2022", StatusAtendimento.EmExecucao, StatusOrcamento.Aprovado, 0m, StatusOrdemServico.EmExecucao),
        CriarAtendimento("Ricardo Alves", "(17) 96666-3456", "LMN0P12", "Fiat Toro 2023", StatusAtendimento.EmExecucao, StatusOrcamento.Aprovado, 0m, StatusOrdemServico.EmExecucao),
        CriarAtendimento("Mariana Costa", "(17) 95555-7890", "QRS2T34", "Chevrolet Onix 2019", StatusAtendimento.EmOrcamento, StatusOrcamento.AguardandoAprovacao, 1850m),
        CriarAtendimento("Felipe Rocha", "(17) 94444-9012", "UVW5X67", "Renault Duster 2020", StatusAtendimento.EmOrcamento, StatusOrcamento.AguardandoAprovacao, 920m),
        CriarAtendimento("Patrícia Lima", "(17) 93333-4567", "YZA8B90", "Jeep Renegade 2022", StatusAtendimento.EmOrcamento, StatusOrcamento.Aprovado, 1600m, situacaoEntrada: SituacaoFinanceira.Pendente)
    ];

    private static Atendimento CriarAtendimento(
        string nomeCliente,
        string contatoCliente,
        string placa,
        string descricaoVeiculo,
        StatusAtendimento statusAtendimento,
        StatusOrcamento statusOrcamento,
        decimal valorOrcamento,
        StatusOrdemServico? statusOrdemServico = null,
        SituacaoSolicitacaoPeca? situacaoPeca = null,
        SituacaoFinanceira? situacaoEntrada = null)
    {
        var cliente = new Cliente { Id = Guid.NewGuid(), Nome = nomeCliente, Contato = contatoCliente };
        var veiculo = new Veiculo
        {
            Id = Guid.NewGuid(), ClienteId = cliente.Id, Placa = placa, Descricao = descricaoVeiculo, Cliente = cliente
        };
        cliente.Veiculos.Add(veiculo);

        var atendimento = new Atendimento
        {
            Id = Guid.NewGuid(), VeiculoId = veiculo.Id, DataAbertura = new DateTime(2026, 8, 27), Status = statusAtendimento, Veiculo = veiculo
        };
        veiculo.Atendimentos.Add(atendimento);

        var orcamento = new Orcamento
        {
            Id = Guid.NewGuid(), AtendimentoId = atendimento.Id, DataCriacao = atendimento.DataAbertura, Status = statusOrcamento, Atendimento = atendimento
        };
        atendimento.Orcamentos.Add(orcamento);
        orcamento.Itens.Add(new ItemOrcamento
        {
            Id = Guid.NewGuid(), OrcamentoId = orcamento.Id, Descricao = "Serviços e peças previstos", Tipo = TipoItemOrcamento.Servico,
            Quantidade = 1, ValorUnitario = valorOrcamento, Orcamento = orcamento
        });

        if (statusOrdemServico.HasValue)
        {
            var ordemServico = new OrdemServico
            {
                Id = Guid.NewGuid(), AtendimentoId = atendimento.Id, Status = statusOrdemServico.Value, Atendimento = atendimento
            };
            atendimento.OrdemServico = ordemServico;

            if (situacaoPeca.HasValue)
            {
                ordemServico.SolicitacoesPeca.Add(new SolicitacaoPeca
                {
                    Id = Guid.NewGuid(), OrdemServicoId = ordemServico.Id, DescricaoPeca = "Peça em acompanhamento",
                    Quantidade = 1, Situacao = situacaoPeca.Value, OrdemServico = ordemServico
                });
            }
        }

        if (situacaoEntrada.HasValue)
        {
            atendimento.LancamentosFinanceiros.Add(new LancamentoFinanceiro
            {
                Id = Guid.NewGuid(), AtendimentoId = atendimento.Id, DataLancamento = atendimento.DataAbertura,
                Tipo = TipoLancamentoFinanceiro.Entrada, Valor = orcamento.ValorTotal / 2,
                Situacao = situacaoEntrada.Value, Atendimento = atendimento
            });
        }

        return atendimento;
    }
}
