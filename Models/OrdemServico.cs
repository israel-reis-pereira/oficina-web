namespace Oficina.Web.Models;

public sealed class OrdemServico
{
    public Guid Id { get; init; }

    public Guid AtendimentoId { get; init; }

    public StatusOrdemServico Status { get; init; }

    public Atendimento Atendimento { get; set; } = null!;

    public ICollection<SolicitacaoPeca> SolicitacoesPeca { get; } = [];
}
