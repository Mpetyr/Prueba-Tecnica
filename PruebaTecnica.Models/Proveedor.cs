using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public long? TelefonoProveedor { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
