/// <summary>
/// Representa os tipos de itens que podem compor um orçamento na oficina.
/// Peca indica que o item de orçamento é uma peça de reposição ou componente necessário para a execução do serviço.
/// Servico indica que o item de orçamento é um serviço específico a ser realizado no veículo, como manutenção, reparo ou inspeção.
/// MaoDeObra indica que o item de orçamento é referente ao custo da mão de obra envolvida na execução do serviço, incluindo o tempo e o esforço do profissional responsável pelo atendimento.
/// </summary>

namespace Oficina.Web.Models;

public enum TipoItemOrcamento
{
    Peca,
    Servico,
    MaoDeObra
}
