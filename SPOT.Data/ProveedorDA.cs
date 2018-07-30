using SPOT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOT.Data
{
    public class ProveedorDA
    {
        public List<ProveedorBE> GetAll()
        {
            var list = new List<ProveedorBE>();
            for (var i = 10; i < 100; i++)
            {
                var entity = new ProveedorBE
                {
                    IdProveedor = i,
                    RUC = "RUC " + i,
                    Proveedor = "Proveedor " + i,
                    Contacto = "Contacto " + i,
                    Direccion = "Direccion " + i,
                };
                list.Add(entity);
            }
            return list;
        }
    }
}
