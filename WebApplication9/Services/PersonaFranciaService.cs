namespace WebApplication9.Services;

public class PersonaFranciaService : IPersonaService<PersonaFranciaService>
{
    public string AggiungiPrefisso(string numero)
    {
        return "+33" + numero;
    }
}
