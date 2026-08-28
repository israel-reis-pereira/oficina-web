namespace Oficina.Web.Models;

public sealed record ResumoOrdemServico(
    string Identificacao,
    string Cliente,
    string Veiculo,
    string Responsavel,
    StatusOrdemServico Status,
    decimal Total);