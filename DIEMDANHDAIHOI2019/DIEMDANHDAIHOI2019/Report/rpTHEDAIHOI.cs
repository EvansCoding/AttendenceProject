using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DIEMDANHDAIHOI2019.Report
{
    public partial class rpTHEDAIHOI : DevExpress.XtraReports.UI.XtraReport
    {
        public rpTHEDAIHOI()
        {
            InitializeComponent();
        }
        public void BindList()
        {
            xrLabel1.DataBindings.Add("Text", DataSource, "colTEN");
            xrLabel2.DataBindings.Add("Text", DataSource, "colDONVI");
            xrPictureBox2.DataBindings.Add("Image", DataSource, "colPIC");
            xrPictureBox3.DataBindings.Add("Image", DataSource, "colQRDB");
            xrPictureBox4.DataBindings.Add("Image", DataSource, "colQRVK");
        }
    }
}
