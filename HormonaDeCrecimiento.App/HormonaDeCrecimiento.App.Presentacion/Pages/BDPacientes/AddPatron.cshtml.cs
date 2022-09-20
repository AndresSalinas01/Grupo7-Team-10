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
    public class AddPatronModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;

        [BindProperty]
        public Patron Patron{get;set;}

        [BindProperty]
        public Paciente Paciente{get;set;}

        public AddPatronModel(IRepositorioPaciente RepositorioPaciente)
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
            if(Paciente.Id>0){
                var paciente = RepositorioPaciente.GetPaciente(Paciente.Id);
                if(paciente != null){
                    if(paciente.Patrones != null){
                        paciente.Patrones.Add(Patron);
                    }
                    else{
                        paciente.Patrones = new List<Patron>{
                            new Patron {
                                FechaHora = Patron.FechaHora,
                                Valor = Patron.Valor,
                                TipoPatron = Patron.TipoPatron
                            }
                        };
                    }
                    RepositorioPaciente.UpdatePaciente(paciente);
                }
                return RedirectToPage("Index");
            }
            
            else{
                return Page();
            }
            
        
        }
    }
}
