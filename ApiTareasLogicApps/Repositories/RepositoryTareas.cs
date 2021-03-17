using ApiTareasLogicApps.Data;
using ApiTareasLogicApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareasLogicApps.Repositories
{
    public class RepositoryTareas
    {
        TareasContext context;

        public RepositoryTareas(TareasContext context)
        {
            this.context = context;
        }

        public List<Tarea> GetTareas()
        {
            return this.context.Tareas.ToList();
        }

        public Tarea BuscarTarea(int idtarea)
        {
            return this.context.Tareas.SingleOrDefault(x => x.IdTarea == idtarea);
        }

        private int GetMaxTarea()
        {
            return this.context.Tareas.Max(x => x.IdTarea) + 1;
        }

        public void CrearTarea(String nombre, String descripcion, int idempleado)
        {
            Tarea tarea = new Tarea();
            tarea.IdTarea = this.GetMaxTarea();
            tarea.Nombre = nombre;
            tarea.Descripcion = descripcion;
            tarea.IdEmpleado = idempleado;
            tarea.Estado = "NEW";
            this.context.Tareas.Add(tarea);
            this.context.SaveChanges();
        }

        //METODO UN METODO (QUE UTILIZARA LOGIC APP COMO TRIGGER)
        //PARA COMPROBAR QUE EL EMPLEADO TIENE NUEVAS TAREAS
        public List<Tarea> GetTareasEmpleado(int idempleado)
        {
            return this.context.Tareas.Where(z => z.IdEmpleado == idempleado
            && z.Estado == "NEW").OrderByDescending(x => x.IdTarea).ToList();
        }
    }
}
