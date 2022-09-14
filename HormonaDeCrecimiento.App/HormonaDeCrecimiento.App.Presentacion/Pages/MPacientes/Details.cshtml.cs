using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Pages_MPacientes
{
    public class DetailsModel : PageModel
    {
        
        private readonly IRepositorioPacienteMemoria RepositorioPacienteMemoria;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Paciente Paciente{get;set;}

        public DetailsModel(IRepositorioPacienteMemoria RepositorioPacienteMemoria)
        {
            this.RepositorioPacienteMemoria = RepositorioPacienteMemoria;
        }

        public IActionResult OnGet(int id)
        {
            Paciente = RepositorioPacienteMemoria.GetPaciente(id);

            if(Paciente==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }
    }
}
