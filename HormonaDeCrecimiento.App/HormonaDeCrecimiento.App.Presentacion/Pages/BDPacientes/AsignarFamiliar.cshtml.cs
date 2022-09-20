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
    public class AsignarFamiliarModel : PageModel
    {
        private readonly IRepositorioPaciente RepositorioPaciente;
        private readonly IRepositorioFamiliar RepositorioFamiliar;
        //Lo que le aplicamos a la etiqueta va a ser visible en el HTML
        public IEnumerable<Familiar> Familiares{get;set;}
        
        public int familiarId;
        [BindProperty]
        public Familiar Familiar{get;set;}
        [BindProperty]
        public Paciente Paciente{get;set;}
        public AsignarFamiliarModel(IRepositorioPaciente RepositorioPaciente, IRepositorioFamiliar RepositorioFamiliar)
        {
            this.RepositorioPaciente = RepositorioPaciente;
            this.RepositorioFamiliar = RepositorioFamiliar;
        }
        public IActionResult OnGet(int id)
        {
            Familiares = RepositorioFamiliar.GetAllFamiliares();
            Paciente = RepositorioPaciente.GetPaciente(id);

            if(Paciente==null){
                return RedirectToPage("./NotFound");
            }    
            else{
                return Page();
            }
        
        }

        public IActionResult OnPostToAssign(int familiarId)
        {
            Familiar = RepositorioPaciente.AsignarFamiliar(Paciente.Id,familiarId);
            return RedirectToPage("Index");           
        
        }
    
    }
}
