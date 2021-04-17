using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_GitHub.Models
{
    public interface IAgendaRepositorio
    {
        IQueryable<Agenda> Agendas { get; }
        public void Create(Agenda agenda);
        public Agenda ObterAgenda(int id);
        public void Edit(Agenda agenda);
        public void Delete(Agenda agenda);
    }
}
