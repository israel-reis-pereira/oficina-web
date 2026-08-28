/// <summary>
/// Representa um orçamento associado a um atendimento na oficina.
/// public Guid AtendimentoId { get; init; } é uma propriedade que armazena o identificador único do atendimento ao qual o orçamento está vinculado, permitindo rastrear e associar os orçamentos aos atendimentos correspondentes. Sendo uma chave estrangeira, garante a integridade referencial entre as entidades Atendimento e Orcamento.
/// public decimal ValorTotal => Itens.Sum(item => item.ValorTotal); é uma propriedade calculada que retorna o valor total do orçamento, somando os valores totais de cada item presente na coleção Itens. Essa propriedade permite obter rapidamente o valor total do orçamento sem a necessidade de cálculos adicionais fora da classe Orcamento.
/// </summary>  

namespace Oficina.Web.Models;

public sealed class Orcamento
{
    public Guid Id { get; init; }

    public Guid AtendimentoId { get; init; }

    public DateTime DataCriacao { get; init; }

    public StatusOrcamento Status { get; init; }

    public Atendimento Atendimento { get; init; } = null!;

    public ICollection<ItemOrcamento> Itens { get; } = [];

    public decimal ValorTotal => Itens.Sum(item => item.ValorTotal);
}
