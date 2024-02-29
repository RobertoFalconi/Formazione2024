using System;
using System.Collections.Generic;

namespace WebApplication9WebApi.Models.DB;

public partial class Persona
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string? Numero { get; set; }

    public int IdComuneNascita { get; set; }

    public virtual Comune IdComuneNascitaNavigation { get; set; } = null!;
}
