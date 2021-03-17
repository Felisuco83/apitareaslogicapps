using ApiTareasLogicApps.Models;
using ApiTareasLogicApps.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareasLogicApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        RepositoryTareas repo;

        public TareasController(RepositoryTareas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Tarea>> GetTareas()
        {
            return this.repo.GetTareas();
        }

        [HttpGet("{id}")]
        public ActionResult<Tarea> BuscarTarea(int id)
        {
            return this.repo.BuscarTarea(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void InsertarTarea(Tarea tarea)
        {
            this.repo.CrearTarea(tarea.Nombre, tarea.Descripcion, tarea.IdEmpleado);
        }

        [HttpGet]
        [Route("[action]/{idempleado}/tasks")]
        public ActionResult<List<Tarea>> TareasEmpleado(int idempleado)
        {
            var model = new
            {
                value = this.repo.GetTareasEmpleado(idempleado)
            };
            return Ok(model);
        }
    }
}
