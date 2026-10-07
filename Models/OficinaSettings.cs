namespace Oficina.Web.Models;

public class OficinaSettings
{
    public const string SectionName = "Oficina";

    public string Nome { get; set; } = string.Empty;
    public string NomeCurto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string WhatsApp { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string PontoReferencia { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string GoogleMapsEmbedUrl { get; set; } = string.Empty;
    public string GoogleMapsDirectionsUrl { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public List<HorarioItem> Horarios { get; set; } = [];
    public List<ServicoItem> Servicos { get; set; } = [];
}
