using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BLL.Service
{
    public interface IProveedorService
    {
        Task<bool> Insertar(Proveedor modelo);
        Task<bool> Actualizar(Proveedor modelo);
        Task<bool> Eliminar(Proveedor modelo);
        Task<Proveedor> Obtener(int id);
        Task<IQueryable<Proveedor>> ObtenerTodos();

    }
}
