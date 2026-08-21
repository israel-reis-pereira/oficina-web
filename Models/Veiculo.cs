namespace Oficina.Web.Models;

public sealed class Veiculo
{
    public required string Placa { get; init; }

    public required string Descricao { get; init; }

    public required string Cliente { get; init; }

    public decimal ValorOrcamento { get; init; }

    // O estado é parte do domínio; o Dashboard decidirá apenas como apresentá-lo.
    public required StatusServico Status { get; init; }
}
