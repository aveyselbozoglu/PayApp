using Payer.Entities;
using System.Web;

namespace Payer.WebClasses
{
    public static class CurrentSession
    {
        // public static Login Login => Get<Login>("login");

        public static Login Login
        {
            get
            {
                return Get<Login>("login");
            }
        }

        public static void Set<T>(string key, T obj)
        {
            if (obj != null)
            {
                HttpContext.Current.Session[key] = obj;
            }
        }

        public static T Get<T>(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                return (T)HttpContext.Current.Session[key];
            }

            return default;
        }


        public static void Remove(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
            {
                HttpContext.Current.Session.Remove("key");
            }

        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}