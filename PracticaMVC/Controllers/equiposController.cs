using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;

        public equiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext= equiposDbContext;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listadeEstados = (from m in _equiposDbContext.estados_equipo
                                 select m).ToList();
            ViewData["listadeEstados"] = new SelectList(listadeEstados, "id_estados_equipo", "descripcion");

            var listadeTipos = (from m in _equiposDbContext.tipo_equipo
                                 select m).ToList();
            ViewData["listadeTipos"] = new SelectList(listadeTipos, "id_tipo_equipo", "descripcion");

            var listadoDeEquipos = (from e in _equiposDbContext.equipos
                                    join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                    select new {
                                            nombre= e.nombre,
                                            descripcion= e.descripcion,
                                            marca_id= e.marca_id,
                                            marca_nombre= m.nombre_marca
                                        }).ToList();

            ViewData["listadoEquipo"] = listadoDeEquipos;

            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
