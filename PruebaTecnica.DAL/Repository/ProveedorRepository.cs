using PruebaTecnica.DAL.DataContext;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DAL.Repository
{
    public class ProveedorRepository : IGenericRepository<Proveedor>
    {
        private readonly PruebaTecnicaDB2Context _dbcontext;

        public ProveedorRepository(PruebaTecnicaDB2Context context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Proveedor modelo)
        {
            _dbcontext.Proveedores.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(Proveedor modelo)
        {
            _dbcontext.Proveedores.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Proveedor modelo)
        {
            _dbcontext.Proveedores.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Proveedor>> Obtener(int id)
        {
            IQueryable<Proveedor> queryProductoSQL = _dbcontext.Proveedores;
            return queryProductoSQL;
        }

        public async Task<IQueryable<Proveedor>> ObtenerTodos()
        {
            IQueryable<Proveedor> queryProductoSQL = _dbcontext.Proveedores;
            return queryProductoSQL;
        }
    }
}
