/// <summary>
/// Representa um item de orçamento associado a um atendimento na oficina.
/// public Guid OrcamentoId { get; init; } é uma propriedade que armazena o identificador único do orçamento ao qual o item de orçamento está vinculado, permitindo rastrear e associar os itens de orçamento aos orçamentos correspondentes. Sendo uma chave estrangeira, garante a integridade referencial entre as entidades Orcamento e ItemOrcamento.
/// public decimal ValorTotal => Quantidade * ValorUnitario; é uma propriedade calculada que retorna o valor total do item de orçamento, obtido multiplicando a quantidade pelo valor unitário. Essa propriedade não é armazenada no banco de dados, mas é calculada dinamicamente com base nos valores das propriedades Quantidade e ValorUnitario, fornecendo uma visão precisa do custo total do item de orçamento.
/// </summary>

namespace Oficina.Web.Models;

public sealed class ItemOrcamento
{
    public Guid Id { get; init; }

    public Guid OrcamentoId { get; init; }

    public required string Descricao { get; init; }

    public TipoItemOrcamento Tipo { get; init; }

    public int Quantidade { get; init; }

    public decimal ValorUnitario { get; init; }

    public Orcamento Orcamento { get; init; } = null!;

    public decimal ValorTotal => Quantidade * ValorUnitario;
}
