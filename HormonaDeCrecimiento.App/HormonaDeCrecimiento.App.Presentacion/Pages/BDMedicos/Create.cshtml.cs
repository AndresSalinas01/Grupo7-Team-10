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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Medico Medico{get;set;}
        private readonly IRepositorioMedico RepositorioMedico;
        public CreateModel(IRepositorioMedico RepositorioMedico)
        {
            this.RepositorioMedico = RepositorioMedico;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            // if(ModelState.IsValid){
            //     Medico = RepositorioMedico.AddMedico(Medico);
            //     return RedirectToPage("Index");
            // }
            // else{
            //     //Se queda en la misma pagina
            //     return Page();

            // }
            Medico = RepositorioMedico.AddMedico(Medico);
            return RedirectToPage("Index");
        }
    }
}
