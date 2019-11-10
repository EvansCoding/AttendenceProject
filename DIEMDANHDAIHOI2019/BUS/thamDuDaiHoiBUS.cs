using DTODLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class thamDuDaiHoiBUS
    {
        private static thamDuDaiHoiBUS instance;

        public static thamDuDaiHoiBUS Instance
        {
            get
            {
                if (instance == null) return instance = new thamDuDaiHoiBUS();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public bool insertTHAMDU(Guid _maDH, List<DOANVIEN> dvList)
        {
            List<THAMDUDAIHOI> list = new List<THAMDUDAIHOI>();
            foreach (var item in dvList)
            {
                THAMDUDAIHOI td = new THAMDUDAIHOI();
                td.MASODH = _maDH;
                td.MASODV = item.MASODV;
                list.Add(td);
            }

            if (thamDuDaiHoiDTO.Instance.InsertListTHAMDU(list))
                return true;
            return false;
        }

        public bool deleteDanhSachThamDu(Guid _maDH)
        {
            try
            {
                return thamDuDaiHoiDTO.Instance.deleteDVTHAMDU(_maDH); ;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public DataTable dsDoanVienThamGia(Guid _maDH)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("colSTT1", typeof(string));
                data.Columns.Add("colHOLOT", typeof(string));
                data.Columns.Add("colTEN", typeof(string));
                data.Columns.Add("colTINHTRANG", typeof(string));
                data.Columns.Add("colHINH", typeof(Image));
                int i = 1;
                List<Guid> guidDV = thamDuDaiHoiDTO.Instance.doanVienThamDu(_maDH);
                foreach (var item in guidDV)
                {
                    DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                    if (dv != null && item != null)
                    {
                        DataRow dataRow = data.NewRow();
                        dataRow[0] = (i++).ToString();
                        dataRow[1] = dv.HOLOT.ToUpper();
                        dataRow[2] = dv.TEN.ToUpper();

                        DateTime ngayDH = daiHoiDTO.Instance.getByNGAYDH(_maDH) ?? new DateTime(2000, 1, 1);
                        DateTime ngayCOMAT = thamDuDaiHoiDTO.Instance.getStatus(_maDH, dv.MASODV) ?? new DateTime(2000, 1, 1);
                        TimeSpan temp;
                        if (ngayDH != new DateTime(2000, 1, 1) && ngayCOMAT != new DateTime(2000, 1, 1))
                        {
                            temp = ngayCOMAT.Subtract(ngayDH);
                            if (temp.Hours < 0 || temp.Minutes < 0)
                            {
                                dataRow[3] = "ĐÚNG GIỜ";
                            }
                            else
                             dataRow[3] = "TRỄ";
                        }
                        else dataRow[3] = "VẮNG";
                        dataRow[4] = Image.FromFile(Application.StartupPath + "\\Images\\" + dv.CMND + ".jpg");
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception)
            {
            }
            return null;

        }

        public bool setStatus(Guid idDV, Guid idDH)
        {
            if (thamDuDaiHoiDTO.Instance.setStatus(idDV, idDH) == true)
                return true;
            return false;
        }

        public DateTime? getTime(Guid idDV, Guid idDH)
        {
            return thamDuDaiHoiDTO.Instance.getTime(idDV, idDH);
        }
    }
}
