using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Agenda_GitHub.Models
{
    public class EFAgendaRepositorio : IAgendaRepositorio
    {
        public ApplicationDbContext context;

        public EFAgendaRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Agenda> Agendas => context.Agendas;

        public void Create(Agenda agenda)
        {
            context.Add(agenda);
            context.SaveChanges();
        }

        public Agenda ObterAgenda(int id)
        {
            var agenda = context.Agendas
            .FirstOrDefault(a => a.AgendaID == id);
            return agenda;
        }
        public void Edit(Agenda agenda)
        {
            context.Entry(agenda).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Agenda agenda)
        {
            context.Remove(agenda);
            context.SaveChanges();
        }

    }
}
