using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Pages_MMedicos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMedicoMemoria RepositorioMedicoMemoria;
        public IEnumerable<Medico> medicos{get;set;}

        public IndexModel(IRepositorioMedicoMemoria RepositorioMedicoMemoria)
        {
            this.RepositorioMedicoMemoria = RepositorioMedicoMemoria;
        }

        
        public void OnGet()
        {
            medicos = RepositorioMedicoMemoria.GetAllMedicos();
        }
    }
}
