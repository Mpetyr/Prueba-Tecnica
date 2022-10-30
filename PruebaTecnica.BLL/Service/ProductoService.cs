using PruebaTecnica.DAL.Repository;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BLL.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _contacRepo;

        public ProductoService(IGenericRepository<Producto> _contactRepo)
        {
            _contacRepo = _contactRepo;
        }

        public async Task<bool> Actualizar(Producto modelo)
        {
            return await _contacRepo.Actualizar(modelo);
        }

        //public async Task<bool> Eliminar(Producto modelo)
        //{
        //    return await _contacRepo.Eliminar(modelo);
        //}

        public async Task<bool> Eliminar(Producto modelo)
        {
            return await _contacRepo.Eliminar(modelo);
        }

        public async Task<bool> Insertar(Producto modelo)
        {
            return await _contacRepo.Insertar(modelo);
        }

        public async Task<IQueryable<Producto>> Obtener(int id)
        {
            return await _contacRepo.Obtener(id);
        }

        public async Task<IQueryable<Producto>> ObtenerTodos()
        {
            return await _contacRepo.ObtenerTodos();
        }
    }
}
