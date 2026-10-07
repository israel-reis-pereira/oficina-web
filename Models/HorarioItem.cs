namespace Oficina.Web.Models;

public class HorarioItem
{
    public string Dia { get; set; } = string.Empty;
    public string Periodo { get; set; } = string.Empty;
    public int DiaInicio { get; set; }
    public int DiaFim { get; set; }
    public string HoraInicio { get; set; } = string.Empty;
    public string HoraFim { get; set; } = string.Empty;
}
