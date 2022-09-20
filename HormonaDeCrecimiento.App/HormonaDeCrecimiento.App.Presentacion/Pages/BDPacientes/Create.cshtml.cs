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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Paciente Paciente{get;set;}
        public CreateModel(IRepositorioPaciente RepositorioPaciente)
        {
            this.RepositorioPaciente = RepositorioPaciente;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSave(){
            // if(ModelState.IsValid){
            //     Paciente = RepositorioPaciente.AddPaciente(Paciente);
            //     return RedirectToPage("Index");
            // }
            // else{
            //     //Se queda en la misma pagina
            //     return Page();

            // }
                Console.WriteLine("Latitud: " + Paciente.Latitud);
                Paciente = RepositorioPaciente.AddPaciente(Paciente);
                return RedirectToPage("Index");
        
        }

    }
}
