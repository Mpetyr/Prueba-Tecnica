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
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _ProveedorService;

        public ProveedorController(IProveedorService ProveedorServ)
        {
            _ProveedorService = ProveedorServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Proveedor> queryProveedorSQL = await _ProveedorService.ObtenerTodos();

            List<VMProveedor> lista = queryProveedorSQL
                                     .Select(c => new VMProveedor()
                                     {
                                         CodigoProveedor = c.CodigoProveedor,
                                         DescripcionProveedor = c.DescripcionProveedor,
                                         TelefonoProveedor = c.TelefonoProveedor.ToString()

                                     }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMProveedor modelo)
        {
            Proveedor NuevoProveedor = new Proveedor()
            {
                DescripcionProveedor = modelo.DescripcionProveedor,
                TelefonoProveedor = long.Parse(modelo.TelefonoProveedor)
                
            };

            bool respuesta = await _ProveedorService.Insertar(NuevoProveedor);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMProveedor modelo)
        {
            Proveedor NuevoProveedor = new Proveedor()
            {
                CodigoProveedor = modelo.CodigoProveedor,
                DescripcionProveedor = modelo.DescripcionProveedor,
                TelefonoProveedor = long.Parse(modelo.TelefonoProveedor)

            };

            bool respuesta = await _ProveedorService.Actualizar(NuevoProveedor);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody] VMProveedor modelo)
        {

            Proveedor NuevoProveedor = new Proveedor()
            {
                CodigoProveedor = modelo.CodigoProveedor,
                DescripcionProveedor = modelo.DescripcionProveedor,
                TelefonoProveedor = long.Parse(modelo.TelefonoProveedor)

            };

            bool respuesta = await _ProveedorService.Actualizar(NuevoProveedor);

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

