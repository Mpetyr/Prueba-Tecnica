using PruebaTecnica.DAL.Repository;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BLL.Service
{
    public class ProveedorService : IProveedorService
    {
        private readonly IGenericRepository<Proveedor> _contacRepo;

        public ProveedorService(IGenericRepository<Proveedor> _contactRepo)
        {
            _contacRepo = _contactRepo;
        }

        public async Task<bool> Actualizar(Proveedor modelo)
        {
            return await _contacRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(Proveedor modelo)
        {
            return await _contacRepo.Eliminar(modelo);
        }

        public async Task<bool> Insertar(Proveedor modelo)
        {
            return await _contacRepo.Insertar(modelo);
        }

        public async Task<IQueryable<Proveedor>> Obtener(int id)
        {
            return await _contacRepo.Obtener(id);
        }

        public async Task<IQueryable<Proveedor>> ObtenerTodos()
        {
            return await _contacRepo.ObtenerTodos();
        }

        Task<Proveedor> IProveedorService.Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
