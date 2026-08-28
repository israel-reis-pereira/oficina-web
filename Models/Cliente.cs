/// <summary>
/// Representa um cliente da oficina, que pode possuir um ou mais veículos.
/// public sealed class nomeDaClasse impede que a classe seja herdada, garantindo que a implementação permaneça consistente e não seja alterada por subclasses.
/// Guid é um identificador único global alfa-numérico aleatorio de 128 bits, útil para identificar clientes de forma única em todo o sistema.
/// init é um modificador de propriedade que permite que a propriedade seja definida apenas durante a inicialização do objeto, garantindo que o valor não possa ser alterado posteriormente.
/// required é um modificador de propriedade que indica que a propriedade deve ser obrigatoriamente inicializada durante a criação do objeto, garantindo que o valor não seja nulo ou vazio.
/// ICollection<Veiculo> Veiculos { get; } = []; é uma coleção de veículos associados ao cliente, permitindo que o cliente possua múltiplos veículos registrados na oficina. A inicialização com [] garante que a coleção esteja sempre pronta para uso, evitando problemas de referência nula.
/// </summary>

namespace Oficina.Web.Models;

public sealed class Cliente
{
    public Guid Id { get; init; }

    public required string Nome { get; init; }

    public required string Contato { get; init; }

    public ICollection<Veiculo> Veiculos { get; } = [];
}
