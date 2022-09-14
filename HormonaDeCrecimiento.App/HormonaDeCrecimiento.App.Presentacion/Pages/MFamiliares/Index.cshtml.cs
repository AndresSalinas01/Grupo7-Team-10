using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Pages_MFamiliares
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioFamiliarMemoria RepositorioFamiliarMemoria;
        public IEnumerable<Familiar> Familiares{get;set;}

        public IndexModel(IRepositorioFamiliarMemoria RepositorioFamiliarMemoria)
        {
            this.RepositorioFamiliarMemoria = RepositorioFamiliarMemoria;
        }

        
        public void OnGet()
        {
            Familiares = RepositorioFamiliarMemoria.GetAllFamiliares();
        }
    }
}
