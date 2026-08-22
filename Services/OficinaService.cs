using Oficina.Web.Models;

namespace Oficina.Web.Services;

public sealed class OficinaService
{
    // Enquanto não existe persistência, os dados simulados ficam centralizados no serviço, não na página.
    private static readonly IReadOnlyList<Veiculo> Veiculos = Array.AsReadOnly(
    [
        new Veiculo
        {
            Placa = "ABC1D23",
            Descricao = "Honda Civic 2020",
            Cliente = "João da Silva",
            ValorOrcamento = 0m,
            Status = StatusServico.PecasSolicitadas
        },
        new Veiculo
        {
            Placa = "DEF4G56",
            Descricao = "Toyota Corolla 2021",
            Cliente = "Carlos Mendes",
            ValorOrcamento = 2400m,
            Status = StatusServico.AguardandoEntrada
        },
        new Veiculo
        {
            Placa = "HIJ7K89",
            Descricao = "Volkswagen T-Cross 2022",
            Cliente = "Ana Pereira",
            ValorOrcamento = 0m,
            Status = StatusServico.EmExecucao
        },
        new Veiculo
        {
            Placa = "LMN0P12",
            Descricao = "Fiat Toro 2023",
            Cliente = "Ricardo Alves",
            ValorOrcamento = 0m,
            Status = StatusServico.EmExecucao
        },
        new Veiculo
        {
            Placa = "QRS2T34",
            Descricao = "Chevrolet Onix 2019",
            Cliente = "Mariana Costa",
            ValorOrcamento = 1850m,
            Status = StatusServico.OrcamentoEmAnalise
        },
        new Veiculo
        {
            Placa = "UVW5X67",
            Descricao = "Renault Duster 2020",
            Cliente = "Felipe Rocha",
            ValorOrcamento = 920m,
            Status = StatusServico.OrcamentoEmAnalise
        },
        new Veiculo
        {
            Placa = "YZA8B90",
            Descricao = "Jeep Renegade 2022",
            Cliente = "Patrícia Lima",
            ValorOrcamento = 1600m,
            Status = StatusServico.AguardandoEntrada
        }
    ]);

    // A filtragem operacional fica no serviço para que a página apenas apresente a coleção recebida.
    public IReadOnlyList<Veiculo> ObterVeiculosEmAtendimento(StatusServico? filtroStatus = null) => Veiculos
        .Where(veiculo => filtroStatus.HasValue
            ? veiculo.Status == filtroStatus.Value
            : veiculo.Status != StatusServico.Finalizado)
        .ToArray();

    // Esta consulta representa os atendimentos que ainda dependem da aprovação do orçamento.
    public IReadOnlyList<Veiculo> ObterOrcamentosPendentes() => Veiculos
        .Where(veiculo => veiculo.Status == StatusServico.OrcamentoEmAnalise)
        .ToArray();

    public IReadOnlyList<Veiculo> ObterEntradasAguardandoPagamento() => Veiculos
        .Where(veiculo => veiculo.Status == StatusServico.AguardandoEntrada)
        .ToArray();

    // O alerta reutiliza esta consulta para que a página não replique o critério operacional de peças.
    public IReadOnlyList<Veiculo> ObterVeiculosAguardandoPecas() => Veiculos
        .Where(veiculo => veiculo.Status == StatusServico.PecasSolicitadas)
        .ToArray();

    public IReadOnlyList<Veiculo> ObterServicosEmExecucao() => Veiculos
        .Where(veiculo => veiculo.Status == StatusServico.EmExecucao)
        .ToArray();

    // O total usa o mesmo critério de entrada pendente, evitando que a página replique a regra de cálculo.
    public decimal ObterValorTotalEntradas() => Veiculos
        .Where(veiculo => veiculo.Status == StatusServico.AguardandoEntrada)
        .Sum(veiculo => veiculo.ValorOrcamento / 2);
}
