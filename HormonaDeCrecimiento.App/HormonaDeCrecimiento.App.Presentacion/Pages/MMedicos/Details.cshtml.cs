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
    public class DetailsModel : PageModel
    {
                
        private readonly IRepositorioMedicoMemoria RepositorioMedicoMemoria;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Medico Medico{get;set;}

        public DetailsModel(IRepositorioMedicoMemoria RepositorioMedicoMemoria)
        {
            this.RepositorioMedicoMemoria = RepositorioMedicoMemoria;
        }

        public IActionResult OnGet(int id)
        {
            Medico = RepositorioMedicoMemoria.GetMedico(id);

            if(Medico==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }
    }
}
