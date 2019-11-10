namespace BUS
{
    using BUS.Classes;
    using DTODLL;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class daiHoiBUS
    {
        private static daiHoiBUS instance;

        public static daiHoiBUS Instance
        {
            get
            {
                if (instance == null) return instance = new daiHoiBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public Guid insertDH(string _chuDe, DateTime _ngay)
        {
            DAIHOI dh = new DAIHOI();
            dh.MASODH = GuidComb.GenerateComb();
            dh.CHUDE = _chuDe;
            dh.NGAY = _ngay;

            if (daiHoiDTO.Instance.InsertDH(dh))
                return dh.MASODH;
            Guid guid = new Guid("ebcc01db-fb22-4107-988a-bcd40f80ac3b");
            return guid;
        }

        public object[] displayInfo(object _maDH = null)
        {
            DataTable data = new DataTable();
            data.Columns.Add("colSTT", typeof(string));
            data.Columns.Add("colCHUDE", typeof(string));
            data.Columns.Add("colNGAY", typeof(string));
            data.Columns.Add("colGIO", typeof(string));
            data.Columns.Add("colSOLUONG", typeof(string));
            List<string> guids = new List<string>();
            int i = 1;
            List<DAIHOI> dhList = daiHoiDTO.Instance.listDAIHOI(_maDH);
            foreach (var item in dhList)
            {
                DataRow dataRow = data.NewRow();
                guids.Add(item.MASODH.ToString());
                dataRow[0] = (i++).ToString();
                dataRow[1] = item.CHUDE.ToUpper();
                string date;
                if (item.NGAY == null)
                    date = "";
                else date = item.NGAY.Value.ToString("dd/M/yyy");

                dataRow[2] = date;

                dataRow[3] = item.NGAY.Value.ToString("HH:mm");
                dataRow[4] = thamDuDaiHoiDTO.Instance.soLuongThamDu(item);
                data.Rows.Add(dataRow);
            }
            object[] dataGuid = new object[] { data, guids };
            return dataGuid;
        }

        public bool deleteDaiHoi(Guid _maDH)
        {
            if (daiHoiDTO.Instance.deleteDH(_maDH)) return true;
            return false;
        }        
    }
}
