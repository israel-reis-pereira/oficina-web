using System.ComponentModel.DataAnnotations;

namespace Oficina.Web.Models;

public class OrcamentoFormModel
{
    [Required(ErrorMessage = "Informe seu nome.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe seu telefone.")]
    [Phone(ErrorMessage = "Informe um telefone válido.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o veículo.")]
    [StringLength(100, ErrorMessage = "O veículo deve ter no máximo 100 caracteres.")]
    public string Veiculo { get; set; } = string.Empty;

    [StringLength(10, ErrorMessage = "A placa deve ter no máximo 10 caracteres.")]
    public string? Placa { get; set; }

    [Required(ErrorMessage = "Descreva o serviço ou problema.")]
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
}
