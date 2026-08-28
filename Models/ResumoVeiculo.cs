using Oficina.Web.Models;

namespace Oficina.Web.Models;

public sealed record ResumoVeiculo(
    string Placa,
    string Descricao,
    string Cliente,
    StatusServico Status);