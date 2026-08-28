/// <summary>
/// Representa os status possíveis para a situação de uma solicitação de peça na oficina.
/// Pendente indica que a solicitação de peça ainda não foi processada.
/// Solicitada indica que a solicitação de peça foi enviada para o fornecedor.
/// Recebida indica que a peça solicitada foi recebida na oficina.
/// Cancelada indica que a solicitação de peça foi cancelada, seja por decisão do cliente ou por algum motivo interno da oficina.
/// </summary>

namespace Oficina.Web.Models;

public enum SituacaoSolicitacaoPeca
{
    Pendente,
    Solicitada,
    Recebida,
    Cancelada
}
