using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTODLL
{
    public class Entities
    {
        private static Entities instance;

        public static Entities Instance
        {
            get
            {
                if (instance == null) return instance = new Entities();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool deleteAll()
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    db.THAMDUDAIHOIs.DeleteAllOnSubmit(db.THAMDUDAIHOIs);
                    db.DAIHOIs.DeleteAllOnSubmit(db.DAIHOIs);
                    db.DOANVIENs.DeleteAllOnSubmit(db.DOANVIENs);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
