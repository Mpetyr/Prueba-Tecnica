using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnica.AplicacionWeb.Models;
using PruebaTecnica.AplicacionWeb.Models.ViewModels;
using PruebaTecnica.BLL.Service;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.AplicacionWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoServ)
        {
            _productoService = productoServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Producto> queryProductoSQL = await _productoService.ObtenerTodos();

            List<VMProducto> lista = queryProductoSQL
                                     .Select(c => new VMProducto()
                                     {
                                         CodigoProducto = c.CodigoProducto,
                                         DescripcionProducto = c.DescripcionProducto,
                                         EstadoProducto = c.EstadoProducto,
                                         FechaFabricacion = c.FechaFabricacion.Value.ToString("dd/MM/yyyy"),
                                         FechaValidez = c.FechaValidez.Value.ToString("dd/MM/yyyy"),
                                         CodigoProveedorId = c.CodigoProveedorId.ToString(),
                                     }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMProducto modelo)
        {
            Producto NuevoProducto = new Producto()
            {
                DescripcionProducto = modelo.DescripcionProducto,
                EstadoProducto = modelo.EstadoProducto,
                FechaFabricacion = DateTime.ParseExact(modelo.FechaFabricacion, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                FechaValidez = DateTime.ParseExact(modelo.FechaValidez, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                CodigoProveedorId = int.Parse(modelo.CodigoProveedorId),
            };

            bool respuesta = await _productoService.Insertar(NuevoProducto);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMProducto modelo)
        {
            Producto NuevoProducto = new Producto()
            {
                CodigoProducto = modelo.CodigoProducto,
                DescripcionProducto = modelo.DescripcionProducto,
                EstadoProducto = modelo.EstadoProducto,
                FechaFabricacion = DateTime.ParseExact(modelo.FechaFabricacion, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                FechaValidez = DateTime.ParseExact(modelo.FechaValidez, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                CodigoProveedorId = int.Parse(modelo.CodigoProveedorId),
            };

            bool respuesta = await _productoService.Actualizar(NuevoProducto);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Eliminar([FromBody] VMProducto modelo)
        {

            Producto EliminarProducto = new Producto()
            {
                CodigoProducto = modelo.CodigoProducto,
                DescripcionProducto = modelo.DescripcionProducto,
                EstadoProducto = "Inactivo",
                FechaFabricacion = DateTime.ParseExact(modelo.FechaFabricacion, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                FechaValidez = DateTime.ParseExact(modelo.FechaValidez, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-CO")),
                CodigoProveedorId = int.Parse(modelo.CodigoProveedorId),
            };
            bool respuesta = await _productoService.Eliminar(EliminarProducto);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

