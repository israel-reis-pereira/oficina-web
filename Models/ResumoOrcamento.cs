namespace Oficina.Web.Models;

public sealed record ResumoOrcamento(
    string Identificacao,
    string Cliente,
    string Veiculo,
    decimal Valor,
    StatusOrcamento Status);