namespace DTODLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class daiHoiDTO
    {
        private static daiHoiDTO instance;

        public static daiHoiDTO Instance
        {
            get
            {
                if (instance == null) return instance = new daiHoiDTO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public string gyByChuDe(Guid _maDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    string chuDe = db.DAIHOIs.Where(p => p.MASODH == _maDH).Select(c => c.CHUDE).SingleOrDefault();
                    return chuDe;
                }
            }
            catch (Exception)
            {
            }
            return "";
        }
        public bool InsertDH(DAIHOI dh)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    db.DAIHOIs.InsertOnSubmit(dh);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public List<DAIHOI> listDAIHOI(object _guid = null)
        {
            try
            {
                List<DAIHOI> tempList = new List<DAIHOI>();
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    if (_guid == null)
                    {
                        tempList = db.DAIHOIs.Select(c => c).ToList();
                        return tempList;
                    }
                    else
                    {
                        Guid guid = new Guid(_guid as string);
                        tempList = db.DAIHOIs.Where(c => c.MASODH == guid).ToList();
                        return tempList;
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }


        public bool deleteDH(Guid _maDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    var dh = db.DAIHOIs.Where(p => p.MASODH == _maDH).SingleOrDefault();
                    db.DAIHOIs.DeleteOnSubmit(dh);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public DateTime? getByNGAYDH(Guid _maDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    var time = db.DAIHOIs.Where(p => p.MASODH == _maDH).Select(c => c.NGAY).SingleOrDefault();
                    return time;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
