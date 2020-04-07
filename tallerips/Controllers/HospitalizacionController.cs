using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using tallerips.Models;

namespace tallerips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizacionController : ControllerBase
    {
        private readonly HospitalizacionService _hospitalizacionService;
        public IConfiguration Configuration { get; }
        public HospitalizacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _hospitalizacionService = new HospitalizacionService(connectionString);
        }
        // GET: api/Hospitalizacion
        [HttpGet]
        public IEnumerable<HospitalizacionViewModel> Gets()
        {
            var personas = _hospitalizacionService.ConsultarTodos().Select(p=> new HospitalizacionViewModel(p));
            return personas;
        }

        // GET: api/Hospitalizacion/5
        [HttpGet("{identificacion}")]
        public ActionResult<HospitalizacionViewModel> Get(string identificacion)
        {
            var hospitalizacion = _hospitalizacionService.BuscarxIdentificacion(identificacion);
            if (hospitalizacion == null) return NotFound();
            var hospitalizacionViewModel = new HospitalizacionViewModel(hospitalizacion);
            return hospitalizacionViewModel;
        }
        // POST: api/Hospitalizacion
        [HttpPost]
        public ActionResult<HospitalizacionViewModel> Post(HospitalizacionInputModel hospitalizacionInput)
        {
            Hospitalizacion hospitalizacion = MapearHospitalizacion(hospitalizacionInput);
            var response = _hospitalizacionService.Guardar(hospitalizacion);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Hospitalizacion);
        }
        // DELETE: api/Persona/5
        /*[HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _personaService.Eliminar(identificacion);
            return Ok(mensaje);
        }*/
        private Hospitalizacion MapearHospitalizacion(HospitalizacionInputModel hospitalizacionInput)
        {
            var hospitalizacion = new Hospitalizacion
            {
                Identificacion = hospitalizacionInput.Identificacion,
                ValorServicio = hospitalizacionInput.ValorServicio,
                SalarioTrabajador = hospitalizacionInput.SalarioTrabajador
            };
            return hospitalizacion;
        }
        // PUT: api/Persona/5
        /*[HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Persona persona)
        {
            throw new NotImplementedException();
        }*/
    }
}