using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Pages_BDMedicos
{
    public class IndexModel : PageModel
    {
       private readonly IRepositorioMedico RepositorioMedico;
        public IEnumerable<Medico> medicos{get;set;}

        public IndexModel(IRepositorioMedico RepositorioMedico)
        {
            this.RepositorioMedico = RepositorioMedico;
        }

        
        public void OnGet()
        {
            medicos = RepositorioMedico.GetAllMedicos();
        }
    }
}
