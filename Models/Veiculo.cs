/// <summary>
/// Representa um veículo da oficina, associado a um cliente.
/// ClienteId é um identificador único global alfa-numérico aleatorio de 128 bits, útil para identificar o cliente ao qual o veículo pertence de forma única em todo o sistema. Sendo uma chave estrangeira que referencia a entidade Cliente.
/// public Cliente Cliente { get; init; } = null!; é uma propriedade de navegação que permite acessar os detalhes do cliente associado ao veículo. O operador null-forgiving (!) indica que a propriedade não será nula, garantindo que o veículo sempre terá um cliente associado.
/// public ICollection<Atendimento> Atendimentos { get; } = []; é uma coleção de atendimentos associados ao veículo, permitindo que o veículo tenha múltiplos registros de atendimentos na oficina. A inicialização com [] garante que a coleção esteja sempre pronta para uso, evitando problemas de referência nula.
/// </summary>

namespace Oficina.Web.Models;

public sealed class Veiculo
{
    public Guid Id { get; init; }

    public Guid ClienteId { get; init; }

    public required string Placa { get; init; }

    // Mantida por compatibilidade com a apresentação atual.
    public required string Descricao { get; init; }

    public Cliente Cliente { get; init; } = null!;

    public ICollection<Atendimento> Atendimentos { get; } = [];
}
