using Oficina.Web.Models;

namespace Oficina.Web.Components;

// Detalhes de texto e Bootstrap pertencem à apresentação, não ao domínio nem às consultas da oficina.
public static class StatusServicoApresentacao
{
    public static string ObterTexto(StatusServico status) => status switch
    {
        StatusServico.CadastroRealizado => "Cadastro realizado",
        StatusServico.OrcamentoEmAnalise => "Aguardando aprovação",
        StatusServico.AguardandoEntrada => "Aguardando entrada (50%)",
        StatusServico.PecasSolicitadas => "Aguardando peças",
        StatusServico.EmExecucao => "Em execução",
        StatusServico.AguardandoPagamento => "Aguardando pagamento final",
        StatusServico.Finalizado => "Finalizado",
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
    };

    public static string ObterClasseBadge(StatusServico status) => status switch
    {
        StatusServico.OrcamentoEmAnalise => "text-bg-warning",
        StatusServico.AguardandoEntrada or StatusServico.AguardandoPagamento => "text-bg-danger",
        StatusServico.PecasSolicitadas => "text-bg-info",
        StatusServico.EmExecucao => "text-bg-primary",
        StatusServico.Finalizado => "text-bg-success",
        _ => "text-bg-secondary"
    };
}
