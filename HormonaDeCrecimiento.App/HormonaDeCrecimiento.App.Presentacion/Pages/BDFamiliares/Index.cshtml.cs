using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Pages_BDFamiliares
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioFamiliar RepositorioFamiliar;
        public IEnumerable<Familiar> Familiares{get;set;}

        public IndexModel(IRepositorioFamiliar RepositorioFamiliar)
        {
            this.RepositorioFamiliar = RepositorioFamiliar;
        }

        
        public void OnGet()
        {
            Familiares = RepositorioFamiliar.GetAllFamiliares();
        }
    }
}
