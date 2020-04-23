using Payer.Entities.ToastrNotification;
using System.Collections.Generic;

namespace Payer.BusinessLayer
{
    public class BusinessLayerResult<T> where T : class
    {
        public T BlResult;

        public List<T> BlResultList;

        public int IsDone;

        public ToastrNotificationObject ToastrNotificationObject { get; set; }

        public BusinessLayerResult()
        {
            IsDone = -1;
            ToastrNotificationObject = null;
            BlResult = null;
            BlResultList = new List<T>();
        }
    }
}