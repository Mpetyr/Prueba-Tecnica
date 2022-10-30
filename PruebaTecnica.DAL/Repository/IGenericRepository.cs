using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DAL.Repository
{
    public interface IGenericRepository<TEntityModel> where TEntityModel:class
    {
        Task<bool> Insertar(TEntityModel modelo);
        Task<bool> Actualizar(TEntityModel modelo);
        Task<bool> Eliminar(TEntityModel modelo);
        Task<IQueryable<TEntityModel>> Obtener(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();
    }
}
