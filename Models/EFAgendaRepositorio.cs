using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Agenda_GitHub.Models
{
    public class EFAgendaRepositorio : IAgendaRepositorio
    {
        private ApplicationDbContext context;

        public EFAgendaRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Agenda> Agendas => context.Agendas;
    }
}
