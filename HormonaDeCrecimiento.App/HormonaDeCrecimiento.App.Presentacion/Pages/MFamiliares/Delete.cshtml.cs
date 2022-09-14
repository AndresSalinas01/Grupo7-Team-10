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
    public class DeleteModel : PageModel
    {
   private readonly IRepositorioFamiliarMemoria RepositorioFamiliarMemoria;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Familiar Familiar{get;set;}
        
        public DeleteModel(IRepositorioFamiliarMemoria RepositorioFamiliarMemoria)
        {
            this.RepositorioFamiliarMemoria = RepositorioFamiliarMemoria;
        }
        public IActionResult OnGet(int id)
        {
            Familiar = RepositorioFamiliarMemoria.GetFamiliar(id);

            if(Familiar==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }

        public IActionResult OnPostSave()
        {
            Console.WriteLine("Elimino Familiar: "+ Familiar.Id);
            RepositorioFamiliarMemoria.DeleteFamiliar(Familiar.Id);
            return RedirectToPage("Index");
            
        
        }
    
    }
}
