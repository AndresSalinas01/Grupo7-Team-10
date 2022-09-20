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
    public class EditModel : PageModel
    {
       private readonly IRepositorioMedico RepositorioMedico;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Medico Medico{get;set;}
        
        public EditModel(IRepositorioMedico RepositorioMedico)
        {
            this.RepositorioMedico = RepositorioMedico;
        }
        public IActionResult OnGet(int id)
        {
            Medico = RepositorioMedico.GetMedico(id);

            if(Medico==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }

        public IActionResult OnPostSave()
        {
            Console.WriteLine("Edito Medico: "+ Medico.Id);
            RepositorioMedico.UpdateMedico(Medico);
            return RedirectToPage("Index");
            
        
        }
    }
}
