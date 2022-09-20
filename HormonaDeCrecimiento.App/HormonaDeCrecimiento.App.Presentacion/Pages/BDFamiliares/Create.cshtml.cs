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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Familiar Familiar{get;set;}
        private readonly IRepositorioFamiliar RepositorioFamiliar;
        public CreateModel(IRepositorioFamiliar RepositorioFamiliar)
        {
            this.RepositorioFamiliar = RepositorioFamiliar;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            // if(ModelState.IsValid){
            //     Familiar = RepositorioFamiliar.AddFamiliar(Familiar);
            //     return RedirectToPage("Index");
            // }
            // else{
            //     //Se queda en la misma pagina
            //     return Page();

            // }
            Familiar = RepositorioFamiliar.AddFamiliar(Familiar);
            return RedirectToPage("Index");
        }

    }
}
