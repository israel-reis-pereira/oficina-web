/// <summary>
/// Representa um lançamento financeiro associado a um atendimento na oficina.
/// public Guid AtendimentoId { get; init; } é uma propriedade que armazena o identificador único do atendimento ao qual o lançamento financeiro está vinculado, permitindo rastrear e associar os lançamentos financeiros aos atendimentos correspondentes. Sendo uma chave estrangeira, garante a integridade referencial entre as entidades Atendimento e LancamentoFinanceiro.
/// </summary>

namespace Oficina.Web.Models;

public sealed class LancamentoFinanceiro
{
    public Guid Id { get; init; }

    public Guid AtendimentoId { get; init; }

    public DateTime DataLancamento { get; init; }

    public TipoLancamentoFinanceiro Tipo { get; init; }

    public decimal Valor { get; init; }

    public SituacaoFinanceira Situacao { get; init; }

    public Atendimento Atendimento { get; init; } = null!;
}
