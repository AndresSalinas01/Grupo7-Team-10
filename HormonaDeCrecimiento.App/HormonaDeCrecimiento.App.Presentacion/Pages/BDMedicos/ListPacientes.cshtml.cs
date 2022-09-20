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
    public class ListPacientesModel : PageModel
    {
        private readonly IRepositorioMedico RepositorioMedico;
        public IEnumerable<Paciente> Pacientes{get;set;}
        [BindProperty(SupportsGet=true)]

        public int GetFilters{get;set;}
        public Medico Medico{get;set;}
        


        public ListPacientesModel(IRepositorioMedico RepositorioMedico)
        {
            this.RepositorioMedico = RepositorioMedico;
        }

        public IActionResult OnGet(int id)
        {
            Pacientes = RepositorioMedico.PacientesMedico(id);
            Medico = RepositorioMedico.GetMedico(id);

            if(Medico==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }
    }
}

