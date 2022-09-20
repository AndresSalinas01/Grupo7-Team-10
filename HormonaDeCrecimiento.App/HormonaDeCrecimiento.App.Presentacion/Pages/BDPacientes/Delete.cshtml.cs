using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Pages_BDPacientes
{
    public class DeleteModel : PageModel
    {        
        private readonly IRepositorioPaciente RepositorioPaciente;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Paciente Paciente{get;set;}
        
        public DeleteModel(IRepositorioPaciente RepositorioPaciente)
        {
            this.RepositorioPaciente = RepositorioPaciente;
        }
        public IActionResult OnGet(int id)
        {
            Paciente = RepositorioPaciente.GetPaciente(id);

            if(Paciente==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }

        public IActionResult OnPostSave()
        {
            Console.WriteLine("Elimino paciente: "+ Paciente.Id);
            RepositorioPaciente.DeletePaciente(Paciente.Id);
            return RedirectToPage("Index");
            
        
        }
    }
}
