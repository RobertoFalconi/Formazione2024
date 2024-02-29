using System;
using System.Collections.Generic;

namespace WebApplication9WebApi.Models.DB;

public partial class Comune
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Persona> Persona { get; set; } = new List<Persona>();
}
