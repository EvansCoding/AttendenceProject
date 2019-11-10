using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTODLL
{
    public class thamDuDaiHoiDTO
    {
        private static thamDuDaiHoiDTO instance;

        public static thamDuDaiHoiDTO Instance
        {
            get
            {
                if (instance == null) return instance = new thamDuDaiHoiDTO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool InsertTHAMDU(THAMDUDAIHOI td)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    db.THAMDUDAIHOIs.InsertOnSubmit(td);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool InsertListTHAMDU(List<THAMDUDAIHOI> td)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    db.THAMDUDAIHOIs.InsertAllOnSubmit(td);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public int soLuongThamDu(DAIHOI dh)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    int count = db.THAMDUDAIHOIs.Where(p => p.MASODH == dh.MASODH).ToList().Count;
                    return count;
                }
            }
            catch (Exception)
            {
            }
            return -1;
        }

        public bool deleteDVTHAMDU(Guid _maDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    var removeDsDV = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH).ToList();
                    db.THAMDUDAIHOIs.DeleteAllOnSubmit(removeDsDV);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public DateTime? getStatus(Guid _maDH, Guid _maDV)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    DateTime? status = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH && p.MASODV == _maDV).Select(c => c.THOIGIANCOMAT).SingleOrDefault();
                    return status;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Guid> doanVienThamDu(Guid _maDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    List<Guid> dsTemp = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH).Select(c => c.MASODV).ToList();

                    return dsTemp;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public bool setStatus(Guid idDV, Guid idDH)
        {
            THAMDUDAIHOI data = new THAMDUDAIHOI();
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    data = db.THAMDUDAIHOIs.Where(p => p.MASODH == idDH && p.MASODV == idDV).SingleOrDefault();
                    if (data != null)
                    {
                        data.THOIGIANCOMAT = DateTime.Now;
                        db.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        public DateTime? getTime(Guid _idDV, Guid _idDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    var time = db.THAMDUDAIHOIs.Where(p => p.MASODV == _idDV && p.MASODH == _idDH).Select(c => c.THOIGIANCOMAT).SingleOrDefault();
                    return time;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
        public List<DOANVIEN> dvTake5(Guid _maDH)
        {
            try
            {
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    List<DOANVIEN> dvl = new List<DOANVIEN>();
                    List<Guid> guids = dvMaDVTake5(_maDH);
                    foreach (var item in guids)
                    {
                        var dv = db.DOANVIENs.Where(p => p.MASODV == item).SingleOrDefault();
                        dvl.Add(dv);
                    }
                    return dvl;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Guid> dvMaDVTake5(Guid _maDH)
        {
            try
            {
                List<Guid> guids = new List<Guid>();
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    List<Guid> dsTemp = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH && p.THOIGIANCOMAT != null).OrderByDescending(m => m.THOIGIANCOMAT).Select(c => c.MASODV).Take(6).ToList();
                    //foreach (var item in dsTemp)
                    //{
                    //    Guid guid = new Guid(item.ToString());
                    //    guids.Add(guid);
                    //}
                    return dsTemp;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object[] soLuongDaiBieu(Guid _maDH)
        {
            try
            {
                object[] oj = new object[3];
                using (HTDIEMDANHDataContext db = new HTDIEMDANHDataContext())
                {
                    oj[0] = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH).ToList().Count;
                    oj[1] = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH && p.THOIGIANCOMAT != null).ToList().Count;
                    oj[2] = db.THAMDUDAIHOIs.Where(p => p.MASODH == _maDH && p.THOIGIANCOMAT == null).ToList().Count;
                    return oj;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object[] coCauDaiBieu(Guid _maDH)
        {
            try
            {
                int doan = 0, dang = 0, nam = 0, nu = 0, tong = 0;
                object[] oj = new object[8];
                List<Guid> guids = doanVienThamDu(_maDH);
                tong = guids.Count;
                foreach (var item in guids)
                {
                    DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                    if (dv != null)
                    {
                        if (dv.NGAYVAODANG != null)
                            dang += 1;
                        else
                        {
                            doan += dv.NGAYVAODOAN == null ? 0 : 1;
                        }


                        nam += dv.NAM == true ? 1 : 0;
                        nu += dv.NAM == true ? 0 : 1;
                    }
                }
                oj[0] = doan;
                oj[1] = ((float)doan / tong) * 100;
                oj[2] = dang;
                oj[3] = ((float)dang / tong) * 100;
                oj[4] = nam;
                oj[5] = ((float)nam / tong) * 100;
                oj[6] = nu;
                oj[7] = ((float)nu / tong) * 100;

                return oj;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object[] dtKINH(Guid _maDH)
        {
            try
            {
                int tong = 0, kinh = 0, tonGiao = 0; ;
                List<Guid> guids = doanVienThamDu(_maDH);
                object[] oj = new object[4];
                tong = guids.Count;
                foreach (var item in guids)
                {
                    DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                    if (dv != null)
                    {
                        kinh += dv.DANTOC.Contains("KINH") == true ? 1 : 0;
                        tonGiao += dv.TONGIAO == "" ? 0 : 1;
                    }
                }
                oj[0] = kinh;
                oj[1] = ((float)kinh / tong) * 100;
                oj[2] = tonGiao;
                oj[3] = ((float)tonGiao / tong) * 100;

                return oj;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object[] trinhDoHocVan(Guid _maDH)
        {
            try
            {
                int tong = 0, trenDH = 0, daihoc = 0, trungCap = 0, totNghiepTHPT = 0;
                List<Guid> guids = doanVienThamDu(_maDH);
                object[] oj = new object[8];
                tong = guids.Count;
                foreach (var item in guids)
                {
                    DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                    if (dv != null)
                    {
                        string[] temp = dv.CMNV.Split('.');
                        if(temp[0].ToLower() == "ThS".ToLower() || temp[0].ToLower() == "TS".ToLower())
                            trenDH++;
                        else if (temp[0].ToLower() == "CN".ToLower() || temp[0].ToLower() == "KS".ToLower())
                            daihoc++;
                        else if (temp[0].ToLower() == "TC".ToLower())
                            trungCap++;
                        else 
                            totNghiepTHPT++;

                    }
                }
                oj[0] = trenDH;
                oj[1] = ((float)trenDH / tong) * 100;
                oj[2] = daihoc;
                oj[3] = ((float)daihoc / tong) * 100;
                oj[4] = trungCap;
                oj[5] = ((float)trungCap / tong) * 100;
                oj[6] = totNghiepTHPT;
                oj[7] = ((float)totNghiepTHPT / tong) * 100;
                return oj;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object[] lyLuanChinhTri(Guid _maDH)
        {
            try
            {
                int tong = 0, caoCap = 0, trungCap = 0, soCap = 0;
                List<Guid> guids = doanVienThamDu(_maDH);
                object[] oj = new object[8];
                tong = guids.Count;
                foreach (var item in guids)
                {
                    DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                    if (dv != null)
                    {
                        if (dv.LLCT.Equals("CAO CẤP"))
                            caoCap++;
                        else if (dv.LLCT.Equals("TRUNG CẤP"))
                            trungCap++;
                        else if (dv.LLCT.Equals("SƠ CẤP"))
                            soCap++;
                    }
                }
                oj[0] = caoCap;
                oj[1] = ((float)caoCap / tong) * 100;
                oj[2] = trungCap;
                oj[3] = ((float)trungCap / tong) * 100;
                oj[4] = soCap;
                oj[5] = ((float)soCap / tong) * 100;
                return oj;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public object[] doTuoi(Guid _maDH)
        {
            try
            {
                int tong = 0;
                List<Guid> guids = doanVienThamDu(_maDH);
                object[] oj = new object[3];
                tong = guids.Count;
                int maxTuoi = 0;
                int minTuoi = 0;
                int tuoiTrungBinh = 0;
                bool check = true;
                foreach (var item in guids)
                {
                    DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                    if (dv != null)
                    {
                        int tuoi = (DateTime.Now.Year - Convert.ToInt32(dv.NAMSINH));
                        if (check)
                        {
                            maxTuoi = tuoi;
                            minTuoi = tuoi;
                            check = false;
                        }
                       
                        tuoiTrungBinh += tuoi;
                        if (maxTuoi < tuoi)
                        {
                            maxTuoi = tuoi;
                        }
                        if(minTuoi > tuoi)
                        {
                            minTuoi = tuoi;
                        }
                    }
                }
                oj[0] = (float)tuoiTrungBinh/tong;
                oj[1] = maxTuoi;
                oj[2] = minTuoi;

                return oj;
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
