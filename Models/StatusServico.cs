namespace Oficina.Web.Models;

// O domínio usa valores fechados para o fluxo de atendimento, sem depender de textos da interface.
public enum StatusServico
{
    CadastroRealizado,
    OrcamentoEmAnalise,
    AguardandoEntrada,
    PecasSolicitadas,
    EmExecucao,
    AguardandoPagamento,
    Finalizado
}
