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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;

        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        [BindProperty]
        public Paciente Paciente{get;set;}
        [BindProperty]
        public Medico Endocrino{get;set;}
        [BindProperty]
        public Medico Pediatra{get;set;}
        [BindProperty]
        public Familiar Familiar{get;set;}

        public DetailsModel(IRepositorioPaciente RepositorioPaciente)
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
                if(RepositorioPaciente.ConsultarEndocrino(id)==null){
                    Endocrino = new Medico{
                        Nombre = "Sin Asignar"

                    };
                    Paciente.Endocrino = Endocrino;
                }
                else{
                    Paciente.Endocrino= RepositorioPaciente.ConsultarEndocrino(id);
                }

                if(RepositorioPaciente.ConsultarPediatra(id)==null){
                    Pediatra = new Medico{
                        Nombre = "Sin Asignar"

                    };
                    Paciente.Pediatra = Pediatra;
                }
                else{
                    Paciente.Pediatra= RepositorioPaciente.ConsultarPediatra(id);
                }

                if(RepositorioPaciente.ConsultarFamiliar(id)==null){
                    Familiar = new Familiar{
                        Nombre = "Sin Asignar"

                    };
                    Paciente.Familiar = Familiar;
                }
                else{
                    Paciente.Familiar= RepositorioPaciente.ConsultarFamiliar(id);
                }

                return Page();
            }
        
        }
    }
}
