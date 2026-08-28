/// <summary>
/// Representa os status possíveis para a situação financeira de um lançamento financeiro na oficina.
/// Pendente indica que o lançamento financeiro ainda não foi pago.
/// Pago indica que o lançamento financeiro foi quitado.
/// Cancelado indica que o lançamento financeiro foi cancelado, seja por decisão do cliente ou por algum motivo interno da oficina.
/// </summary>

namespace Oficina.Web.Models;

public enum SituacaoFinanceira
{
    Pendente,
    Pago,
    Cancelado
}
