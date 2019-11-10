namespace BUS
{
    using DTODLL;
    using System;
    using System.Collections.Generic;

    public class GeneralClass
    {
        private static GeneralClass instance;

        public static GeneralClass Instance
        {
            get
            {
                if (instance == null) return instance = new GeneralClass();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public bool INSERTALL(string _chuDe, DateTime _ngay, string _pathExcel, string _pathImages)
        {
            Guid guid = new Guid("ebcc01db-fb22-4107-988a-bcd40f80ac3b");
            Guid maDH = daiHoiBUS.Instance.insertDH(_chuDe, _ngay);
            List<DOANVIEN> dvList = new List<DOANVIEN>();
            try
            {
                dvList = doanVienBUS.Instance.InsertAllDV(_pathExcel, _pathImages);
                if(dvList != null)
                {
                    if (maDH != guid && dvList != null)
                    {
                        if (thamDuDaiHoiBUS.Instance.insertTHAMDU(maDH, dvList))
                            return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            daiHoiBUS.Instance.deleteDaiHoi(maDH);
            dvList.Clear();
            return false;
        }
    }
}
