using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda_GitHub.Models.ViewModels;
using Agenda_GitHub.Models;

namespace Agenda_GitHub.Controllers
{
    public class AgendaController : Controller
    {
        private ApplicationDbContext _context;
        private IAgendaRepositorio repositorio;
        public int PageSize = 2;

        public AgendaController(IAgendaRepositorio repo, ApplicationDbContext ctx)
        {
            repositorio = repo;
            _context = ctx;
        }

        public ViewResult List(int pagina = 1) =>
           View(new AgendaListViewModel
           {
               Agendas = repositorio.Agendas
               .OrderBy(p => p.AgendaID)
           });

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agendas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        public IActionResult Create([Bind("AgendaID,Anotacao,Data")] Agenda agenda)
        {
            repositorio.Create(agenda);
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var agenda = repositorio.ObterAgenda(id);
            return View(agenda);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agenda = _context.Agendas.Find(id);
            return View(agenda);
        }
        [HttpPost]
        public IActionResult Edit(Agenda agenda)
        {
            repositorio.Edit(agenda);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var agenda = repositorio.ObterAgenda(id);
            return View(agenda);
        }
        [HttpPost]
        public IActionResult Delete(Agenda agenda)
        {
            repositorio.Delete(agenda);
            return RedirectToAction("List");
        }

    }
}
