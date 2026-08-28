/// <summary>
/// Representa uma passagem específica de um veículo pela oficina.
/// public DateTime? DataFinalizacao { get; init; } é uma propriedade que armazena a data e hora em que o atendimento foi finalizado, podendo ser nula caso o atendimento ainda esteja em andamento.
/// public Guid VeiculoId { get; init; } é uma propriedade que armazena o identificador único do veículo associado ao atendimento, permitindo rastrear e associar os atendimentos aos veículos correspondentes. Sendo uma chave estrangeira, garante a integridade referencial entre as entidades Veiculo e Atendimento.
/// public OrdemServico? OrdemServico { get; set; } é uma propriedade que representa a ordem de serviço associada ao atendimento, podendo ser nula caso ainda não tenha sido gerada. E aceita set, permitindo que a ordem de serviço seja atribuída posteriormente.
/// </summary>

namespace Oficina.Web.Models;

public sealed class Atendimento
{
    public Guid Id { get; init; }

    public Guid VeiculoId { get; init; }

    public DateTime DataAbertura { get; init; }

    public DateTime? DataFinalizacao { get; init; }

    public StatusAtendimento Status { get; init; }

    public Veiculo Veiculo { get; init; } = null!;

    public ICollection<Orcamento> Orcamentos { get; } = [];

    public OrdemServico? OrdemServico { get; set; }

    public ICollection<LancamentoFinanceiro> LancamentosFinanceiros { get; } = [];
}
