/// <summary>
/// Representa os tipos de lançamentos financeiros que podem ocorrer em um atendimento na oficina.
/// Entrada indica que o lançamento financeiro é uma entrada de recursos, como um pagamento recebido do cliente.
/// Pagamento indica que o lançamento financeiro é um pagamento realizado pela oficina, como o pagamento de fornecedores ou despesas operacionais.
/// </summary>

namespace Oficina.Web.Models;

public enum TipoLancamentoFinanceiro
{
    Entrada,
    Pagamento
}
