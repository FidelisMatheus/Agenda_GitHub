using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace Agenda_GitHub.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Agendas.Any())
            {
                context.Agendas.AddRange(
                    new Agenda
                    {
                        Anotacao = "Consulta com Doutor Fidelis",
                        Data = "20/04/2021"
                    },
                    new Agenda
                    {
                        Anotacao = "Consulta com Dentista",
                        Data = "15/07/2021"
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
