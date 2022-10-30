using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models
{
    public partial class Producto
    {
        public int CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string EstadoProducto { get; set; }
        public DateTime? FechaFabricacion { get; set; }
        public DateTime? FechaValidez { get; set; }
        public int CodigoProveedorId { get; set; }

        public virtual Proveedor CodigoProveedor { get; set; }
    }
}
