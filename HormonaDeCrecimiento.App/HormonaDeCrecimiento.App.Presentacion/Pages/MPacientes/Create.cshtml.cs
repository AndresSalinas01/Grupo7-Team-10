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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPacienteMemoria RepositorioPacienteMemoria;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Paciente Paciente{get;set;}
        public CreateModel(IRepositorioPacienteMemoria RepositorioPacienteMemoria)
        {
            this.RepositorioPacienteMemoria = RepositorioPacienteMemoria;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            // if(ModelState.IsValid){
            //     Paciente = RepositorioPacienteMemoria.AddPaciente(Paciente);
            //     return RedirectToPage("Index");
            // }
            // else{
            //     //Se queda en la misma pagina
            //     return Page();

            // }
            //Console.WriteLine("Entrooo");
                Paciente = RepositorioPacienteMemoria.AddPaciente(Paciente);
                return RedirectToPage("Index");
        
        }

    }
}
