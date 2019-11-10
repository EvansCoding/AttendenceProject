namespace DIEMDANHDAIHOI2019.Report
{
    using System;
    using DTODLL;

    public partial class rpTHONGKE : DevExpress.XtraReports.UI.XtraReport
    {
        Guid _maDH;

        public rpTHONGKE(Guid guid)
        {
            InitializeComponent();
            _maDH = guid;
        }

        public void load()
        {
            object[] oj = thamDuDaiHoiDTO.Instance.soLuongDaiBieu(_maDH);

            lbTongSo.Text = oj[0].ToString();
            lbCoMat.Text = oj[1].ToString();
            lbVangMat.Text = oj[2].ToString();

            oj = thamDuDaiHoiDTO.Instance.coCauDaiBieu(_maDH);
            blSoCanBoDoan.Text = oj[0].ToString();
            lbPTCanBoDoan.Text = String.Format("{0:0.0}", oj[1]);
            lbSoCanBoDang.Text = oj[2].ToString();
            lbPTCanBoDang.Text = String.Format("{0:0.0}", oj[3]);
            lbSoDaiBieuNam.Text = oj[4].ToString();
            lbPTDaiBieuNam.Text = String.Format("{0:0.0}", oj[5]);
            lbSoDaiBieuNu.Text = oj[6].ToString();
            lbPTDaiBieuNu.Text = String.Format("{0:0.0}", oj[7]);

            oj = thamDuDaiHoiDTO.Instance.dtKINH(_maDH);
            lbDanToc.Text = oj[0].ToString();
            lbPTDanToc.Text = String.Format("{0:0.0}", oj[1]);
            lbDao.Text = oj[2].ToString();
            lbPTDao.Text = String.Format("{0:0.0}", oj[3]);

            oj = thamDuDaiHoiDTO.Instance.doTuoi(_maDH);
            lbTuoiTB.Text = String.Format("{0:0.0}", oj[0]);
            lbTuoiCao.Text = oj[1].ToString();
            lbTuoiThap.Text = oj[2].ToString();

            oj = thamDuDaiHoiDTO.Instance.trinhDoHocVan(_maDH);
            lbTrenDH.Text = oj[0].ToString();
            lbPTTrenDH.Text = String.Format("{0:0.0}", oj[1]);
            lbDH.Text = oj[2].ToString();
            lbPTDH.Text = String.Format("{0:0.0}", oj[3]);
            lbTrungCap.Text = oj[4].ToString();
            lbPTTrungCap.Text = String.Format("{0:0.0}", oj[5]);
            lbTHPT.Text = oj[6].ToString();
            lbPTTHPT.Text = String.Format("{0:0.0}", oj[7]);

            oj = thamDuDaiHoiDTO.Instance.lyLuanChinhTri(_maDH);
            lbCaoCap.Text = oj[0].ToString();
            lbPTCaoCap.Text = String.Format("{0:0.0}", oj[1]);
            lbllTrungCap.Text = oj[2].ToString();
            lbPTllTrungCap.Text = String.Format("{0:0.0}", oj[3]);
            lbSoCap.Text = oj[4].ToString();
            lbPTSoCap.Text = String.Format("{0:0.0}", oj[5]);

        }
    }
}
