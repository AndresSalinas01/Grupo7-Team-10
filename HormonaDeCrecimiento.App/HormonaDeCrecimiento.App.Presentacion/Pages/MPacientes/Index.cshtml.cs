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
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPacienteMemoria RepositorioPacienteMemoria;
        public IEnumerable<Paciente> pacientes{get;set;}

        public IndexModel(IRepositorioPacienteMemoria RepositorioPacienteMemoria)
        {
            this.RepositorioPacienteMemoria = RepositorioPacienteMemoria;
        }

        
        public void OnGet()
        {
            pacientes = RepositorioPacienteMemoria.GetAllPacientes();
        }
    }
}
