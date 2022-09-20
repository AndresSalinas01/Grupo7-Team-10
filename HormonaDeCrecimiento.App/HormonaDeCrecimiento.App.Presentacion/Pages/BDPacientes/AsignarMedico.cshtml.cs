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
    public class AsignarMedicoModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;
        private readonly IRepositorioMedico RepositorioMedico;
        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        public IEnumerable<Medico> Medicos{get;set;}
        
        public int medicoId;
        [BindProperty]
        public Medico Medico{get;set;}
        [BindProperty]
        public Paciente Paciente{get;set;}
        public AsignarMedicoModel(IRepositorioPaciente RepositorioPaciente, IRepositorioMedico RepositorioMedico)
        {
            this.RepositorioPaciente = RepositorioPaciente;
            this.RepositorioMedico = RepositorioMedico;
        }
        public IActionResult OnGet(int id)
        {
            Medicos = RepositorioMedico.GetAllMedicos();
            Paciente = RepositorioPaciente.GetPaciente(id);

            if(Paciente==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }

        public IActionResult OnPostToAssign(int medicoId)
        {
            Medico = RepositorioPaciente.AsignarMedico(Paciente.Id,medicoId);
            return RedirectToPage("Index");           
        
        }
    }
}
