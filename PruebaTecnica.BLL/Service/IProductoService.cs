using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BLL.Service
{
    public interface IProductoService
    {
        Task<bool> Insertar(Producto modelo);
        Task<bool> Actualizar(Producto modelo);
        Task<bool> Eliminar(Producto modelo);
        Task<IQueryable<Producto>> Obtener(int id);
        Task<IQueryable<Producto>> ObtenerTodos();

    }
}
