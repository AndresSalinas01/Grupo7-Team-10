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
    public class GetPatronesModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;
        public IEnumerable<Patron> Patrones{get;set;}
        public Paciente Paciente{get;set;}
        
        public GetPatronesModel(IRepositorioPaciente RepositorioPaciente)
        {
            this.RepositorioPaciente = RepositorioPaciente;
        }

        public IActionResult OnGet(int id)
        {
            Patrones = RepositorioPaciente.GetPatronesPacientes(id);
            Paciente = RepositorioPaciente.GetPaciente(id);

            if(Paciente==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }

       
        
    }
}
