/// <summary>
/// Representa os status possíveis para um orçamento na oficina.
/// EmElaboracao indica que o orçamento está em processo de elaboração e ainda não foi finalizado.
/// AguardandoAprovacao indica que o orçamento foi finalizado e está aguardando a aprovação do cliente.
/// Aprovado indica que o orçamento foi aprovado pelo cliente e está pronto para prosseguir com a execução do serviço.
/// Recusado indica que o orçamento foi recusado pelo cliente e não será executado.
/// Cancelado indica que o orçamento foi cancelado, seja por decisão do cliente ou por algum motivo interno da oficina.
/// </summary>

namespace Oficina.Web.Models;

public enum StatusOrcamento
{
    EmElaboracao,
    AguardandoAprovacao,
    Aprovado,
    Recusado,
    Cancelado
}
