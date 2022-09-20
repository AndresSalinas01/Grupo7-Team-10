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
    public class DetailsModel : PageModel
    {                
        private readonly IRepositorioFamiliar RepositorioFamiliar;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Familiar Familiar{get;set;}

        public DetailsModel(IRepositorioFamiliar RepositorioFamiliar)
        {
            this.RepositorioFamiliar = RepositorioFamiliar;
        }

        public IActionResult OnGet(int id)
        {
            Familiar = RepositorioFamiliar.GetFamiliar(id);

            if(Familiar==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }
    }
}
