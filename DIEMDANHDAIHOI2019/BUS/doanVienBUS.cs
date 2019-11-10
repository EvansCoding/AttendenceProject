namespace BUS
{
    using BUS.Classes;
    using DTODLL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class doanVienBUS
    {
        private static doanVienBUS instance;

        public static doanVienBUS Instance
        {
            get
            {
                if (instance == null) return instance = new doanVienBUS();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<DOANVIEN> InsertAllDV(string _pathExcel,string _pathImage)
        {
            List<DOANVIEN> list = insertDVtoEXCEL(openFileExcel(_pathExcel), _pathImage);

            return list;
        }

        private List<DOANVIEN> insertDVtoEXCEL(DataTable dataTable, string _pathImage)
        {
            List<DOANVIEN> dvList = new List<DOANVIEN>();
            List<DOANVIEN> tempList = new List<DOANVIEN>();
            foreach (DataRow item in dataTable.Rows)
            {
                DOANVIEN dv = doanVienDTO.Instance.getByCMND(item[0].ToString());
                if (dv == null)
                {
                    dv = new DOANVIEN();
                    dv.MASODV = GuidComb.GenerateComb();
                    dv.CMND = item[0].ToString();
                    dv.HOLOT = item[1].ToString();
                    dv.TEN = item[2].ToString();
                    dv.NAMSINH = item[3].ToString();
                    dv.NAM = item[4].ToString() == "NAM" ? true : false;
                    dv.NGUYENQUAN = item[5].ToString();
                    dv.DANTOC = item[6].ToString();
                    dv.TONGIAO = item[7].ToString();
                    dv.CMNV = item[8].ToString();
                    dv.LLCT = item[9].ToString();
                    if (String.Empty == item[10].ToString())
                    {
                        dv.NGAYVAODOAN = null;
                    }
                    else
                    {
                        DateTime temp = (DateTime)item[10];
                        dv.NGAYVAODOAN = new DateTime(temp.Year, temp.Month, temp.Day);
                    }
                    if (String.Empty == item[11].ToString())
                    {
                        dv.NGAYVAODANG = null;
                    }
                    else
                    {
                        DateTime temp = (DateTime)item[11];
                        dv.NGAYVAODANG = new DateTime(temp.Year, temp.Month, temp.Day);
                    }
                    dv.DONVI = item[12].ToString();
                    dv.HASHING = Hash.ComputeSha256Hash(dv.CMND + dv.HOLOT + dv.TEN + dv.NAM);
                    dv.NGAYTAO = DateTime.Now;
                    dv.NGAYCAPNHAT = DateTime.Now;
                    QRGenerator.Instance.createQRCode(dv.HASHING);
                    tempList.Add(dv);
                    dvList.Add(dv);
                    continue;
                }
                tempList.Add(dv);
            }

            if (dvList != null && doanVienDTO.Instance.InsertListDV(dvList))
            {
                if(saveImages.Instance.saveImageToFolderImages(_pathImage))
                    return tempList;
            }
            if (tempList != null)
                return tempList;

            return null;
        }

        private DataTable openFileExcel(string pathExcel)
        {
            return ExcelDataBaseHelper.OpenFile(pathExcel);
        }

        public DataTable printDSDV(Guid _maDH)
        {
            List<DOANVIEN> tam = new List<DOANVIEN>();

            DataTable dt = new DataTable();
            dt.Columns.Add("colTEN", Type.GetType("System.String"));
            dt.Columns.Add("colDONVI", Type.GetType("System.String"));
            dt.Columns.Add("colPIC", typeof(Image));
            dt.Columns.Add("colQRDB", typeof(Image));
            dt.Columns.Add("colQRVK", typeof(Image));

            List<Guid> guids = thamDuDaiHoiDTO.Instance.doanVienThamDu(_maDH);
            foreach (var item in guids)
            {
                DOANVIEN dv = doanVienDTO.Instance.getByGUIDOANVIEN(item);
                if (dv != null)
                {
                    DataRow dataRow = dt.NewRow();
                    dataRow[0] = dv.HOLOT.ToUpper() + " " + dv.TEN.ToUpper();
                    dataRow[1] = dv.DONVI.ToUpper();
                    Image image = Image.FromFile(Application.StartupPath + "\\" + "Images\\" + dv.CMND + ".jpg");
                    dataRow[2] = image;
                    image = Image.FromFile(Application.StartupPath + "\\" + "QRCode\\" + dv.HASHING + ".jpg");
                    dataRow[3] = image;
                    image = Properties.Resources.vankien;
                    dataRow[4] = image;
                    dt.Rows.Add(dataRow);
                }
            }
            return dt;
        }

        public object[] getByHash(string _hashing)
        {
            DOANVIEN dv = doanVienDTO.Instance.getByHash(_hashing);
            if (dv == null)
                return null;

            object[] oj = new object[14];
            oj[0] = dv.CMND;
            oj[1] = dv.HOLOT;
            oj[2] = dv.TEN;
            oj[3] = dv.NAMSINH;
            oj[4] = dv.NAM == true ? "NAM" : "NỮ";
            oj[5] = dv.NGUYENQUAN == "" ? "KHÔNG CÓ" : dv.NGUYENQUAN.ToUpper(); ;
            oj[6] = dv.DANTOC == "" ? "KHÔNG CÓ" : dv.DANTOC.ToUpper();
            oj[7] = dv.TONGIAO == "" ? "KHÔNG CÓ" : dv.TONGIAO.ToUpper();
            oj[8] = dv.CMNV == "" ? "KHÔNG CÓ" : dv.CMNV.ToUpper();
            oj[9] = dv.LLCT == "" ? "KHÔNG CÓ" : dv.LLCT.ToUpper(); ;
            oj[10] = dv.NGAYVAODOAN == null ? "KHÔNG CÓ" : dv.NGAYVAODOAN.Value.ToShortDateString(); 
            oj[11] = dv.NGAYVAODANG == null ? "KHÔNG CÓ" : dv.NGAYVAODANG.Value.ToShortDateString(); ;
            oj[12] = dv.DONVI == "" ? "KHÔNG CÓ" : dv.DONVI.ToUpper();
            oj[13] = dv.MASODV.ToString();
            return oj;
        }
    }
}
