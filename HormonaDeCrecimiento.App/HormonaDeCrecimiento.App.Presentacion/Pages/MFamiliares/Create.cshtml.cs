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
    public class CreateModel : PageModel
    {
 [BindProperty]
        public Familiar Familiar{get;set;}
        private readonly IRepositorioFamiliarMemoria RepositorioFamiliarMemoria;
        public CreateModel(IRepositorioFamiliarMemoria RepositorioFamiliarMemoria)
        {
            this.RepositorioFamiliarMemoria = RepositorioFamiliarMemoria;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            // if(ModelState.IsValid){
            //     Familiar = RepositorioFamiliarMemoria.AddFamiliar(Familiar);
            //     return RedirectToPage("Index");
            // }
            // else{
            //     //Se queda en la misma pagina
            //     return Page();

            // }
            Familiar = RepositorioFamiliarMemoria.AddFamiliar(Familiar);
            return RedirectToPage("Index");
        }

    }
}
