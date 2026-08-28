namespace Oficina.Web.Models;

public sealed class SolicitacaoPeca
{
    public Guid Id { get; init; }

    public Guid OrdemServicoId { get; init; }

    public required string DescricaoPeca { get; init; }

    public int Quantidade { get; init; }

    public SituacaoSolicitacaoPeca Situacao { get; init; }

    public OrdemServico OrdemServico { get; init; } = null!;
}
