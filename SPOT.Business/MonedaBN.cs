using SPOT.Data;
using SPOT.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPOT.Business
{
    public class MonedaBN
    {
        public List<MonedaBE> getAllMoneda() {
            MonedaDA obj1 = new MonedaDA();
            return obj1.getAllMoneda();
        }
        
    }
}
