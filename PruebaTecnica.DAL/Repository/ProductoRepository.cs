using PruebaTecnica.DAL.DataContext;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DAL.Repository
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly PruebaTecnicaDB2Context _dbcontext;

        public ProductoRepository(PruebaTecnicaDB2Context context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Producto modelo)
        {
            _dbcontext.Productos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(Producto modelo)
        {
            _dbcontext.Productos.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Insertar(Producto modelo)
        {
            _dbcontext.Productos.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Producto>> Obtener(int id)
        {
            IQueryable<Producto> queryProductoSQL = _dbcontext.Productos;
            return queryProductoSQL;
        }

        public async Task<IQueryable<Producto>> ObtenerTodos()
        {
            IQueryable<Producto> queryProductoSQL = _dbcontext.Productos;
            return queryProductoSQL;
        }
    }
}
