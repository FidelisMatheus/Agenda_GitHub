using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_GitHub.Models
{
    public interface IAgendaRepositorio
    {
        IQueryable<Agenda> Agendas { get; }
    }
}
