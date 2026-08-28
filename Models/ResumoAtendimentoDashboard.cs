/// <summary>
/// Projeção temporária que preserva o contrato atual de apresentação do Dashboard.
/// </summary>

namespace Oficina.Web.Models;

// Projeção temporária que preserva o contrato atual de apresentação do Dashboard.
public sealed record ResumoAtendimentoDashboard(
    string Placa,
    string Descricao,
    string Cliente,
    decimal ValorOrcamento,
    StatusServico Status);
