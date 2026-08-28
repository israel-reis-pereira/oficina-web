/// <summary>
/// Representa os status possíveis para um serviço na oficina.
/// CadastroRealizado indica que o serviço foi cadastrado na base de dados.
/// OrcamentoEmAnalise indica que o orçamento para o serviço está em análise.
/// AguardandoEntrada indica que o serviço está aguardando a entrada do veículo.
/// PecasSolicitadas indica que as peças necessárias para o serviço foram solicitadas.
/// EmExecucao indica que o serviço está em execução.
/// AguardandoPagamento indica que o serviço está aguardando pagamento do cliente.
/// Finalizado indica que o serviço foi finalizado.
/// </summary>

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
