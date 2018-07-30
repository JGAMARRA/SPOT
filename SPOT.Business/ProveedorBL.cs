using SPOT.Data;
using SPOT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOT.Business
{
    public class ProveedorBL
    {
        public List<ProveedorBE> GetAll()
        {
            return new ProveedorDA().GetAll();
        }
    }
}
