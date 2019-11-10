using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTODLL
{
    public class doanVienDTO
    {
        private static doanVienDTO instance;

        public static doanVienDTO Instance
        {
            get
            {
                if (instance == null) return instance = new doanVienDTO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool InsertDV(DOANVIEN dv)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    db.DOANVIENs.InsertOnSubmit(dv);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        public bool InsertListDV(List<DOANVIEN> dv)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    db.DOANVIENs.InsertAllOnSubmit(dv);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public DOANVIEN getByCMND(string _cmnd)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    var dv = db.DOANVIENs.Where(p => p.CMND == _cmnd).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public DOANVIEN getByGUIDOANVIEN(Guid id)
        {
            try
            {
                DOANVIEN dv;
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.MASODV == id).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        public DOANVIEN getByHash(string _hashing)
        {
            try
            {
                DOANVIEN dv;
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    dv = db.DOANVIENs.Where(p => p.HASHING == _hashing).SingleOrDefault();
                    return dv;
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
