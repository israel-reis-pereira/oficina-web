/// <summary>
/// Representa os status possíveis para uma ordem de serviço na oficina.
/// Aberta indica que a ordem de serviço foi aberta e está em andamento.
/// AguardandoPecas indica que a ordem de serviço está aguardando a chegada das peças necessárias.
/// EmExecucao indica que a ordem de serviço está em execução.
/// Concluida indica que a ordem de serviço foi concluída.
/// Cancelada indica que a ordem de serviço foi cancelada.
/// </summary>

namespace Oficina.Web.Models;

public enum StatusOrdemServico
{
    Aberta,
    AguardandoPecas,
    EmExecucao,
    Concluida,
    Cancelada
}
