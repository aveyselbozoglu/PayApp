using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payer.BusinessLayer
{
    public class BusinessLayerResult<T> where T :class
    {
        public T BlResult;

        public List<T> BlResultList;



        public BusinessLayerResult()
        {
            BlResult = null;
            BlResultList = new List<T>();
        }

    }
}
