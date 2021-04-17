using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_GitHub.Models;

namespace Agenda_GitHub.Models.ViewModels
{
    public class AgendaListViewModel
    {
        public IEnumerable<Agenda> Agendas { get; set; }

    }
}
