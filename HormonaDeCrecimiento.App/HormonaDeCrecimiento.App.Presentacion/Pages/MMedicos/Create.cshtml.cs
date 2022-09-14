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
    public class CreateModel : PageModel
    {
//Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Medico Medico{get;set;}
        private readonly IRepositorioMedicoMemoria RepositorioMedicoMemoria;
        public CreateModel(IRepositorioMedicoMemoria RepositorioMedicoMemoria)
        {
            this.RepositorioMedicoMemoria = RepositorioMedicoMemoria;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            // if(ModelState.IsValid){
            //     Medico = RepositorioMedicoMemoria.AddMedico(Medico);
            //     return RedirectToPage("Index");
            // }
            // else{
            //     //Se queda en la misma pagina
            //     return Page();

            // }
            Medico = RepositorioMedicoMemoria.AddMedico(Medico);
            return RedirectToPage("Index");
        }

    }
}
