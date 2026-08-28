/// <summary>
/// Representa os status possíveis para um atendimento na oficina.
/// EmOrcamento indica que o atendimento está em fase de orçamento, aguardando a definição dos serviços e peças necessários.
/// AguardandoPecas indica que o atendimento está aguardando a chegada das peças necessárias para a execução do serviço.
/// EmExecucao indica que o atendimento está em andamento, com os serviços sendo realizados no veículo.
/// Finalizado indica que o atendimento foi concluído, com todos os serviços realizados e o veículo pronto para entrega.
/// Entregue indica que o atendimento foi finalizado e o veículo foi entregue ao cliente.
/// Cancelado indica que o atendimento foi cancelado, seja por decisão do cliente ou por algum motivo interno da oficina.
/// </summary>

namespace Oficina.Web.Models;

public enum StatusAtendimento
{
    EmOrcamento,
    AguardandoPecas,
    EmExecucao,
    Finalizado,
    Entregue,
    Cancelado
}
