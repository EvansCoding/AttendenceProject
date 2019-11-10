namespace DIEMDANHDAIHOI2019.Report
{
    using System;
    using System.Windows.Forms;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using BUS;

    public partial class fSUB : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fSUB(Guid _id)
        {
            InitializeComponent();
            id = _id;
        }

        Guid id;
        rpTHEDAIHOI reportItem;

        private void exportPDF(string path, string ID = null)
        {
            reportItem.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportItem.Margins.Bottom = 0;
            reportItem.PrintingSystem.ShowPrintStatusDialog = false;
            reportItem.PrintingSystem.ShowMarginsWarning = false;
            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(reportItem))
            {
                printTool.Report.CreateDocument(false); // <- ADD THIS LINE  
                printTool.PrintingSystem.ExportToPdf(path + id.ToString() + "_Export.pdf");
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (fbd.SelectedPath == "")
                        XtraMessageBox.Show("LƯU KHÔNG THÀNH CÔNG!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        XtraMessageBox.Show("LƯU THÀNH CÔNG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        exportPDF(fbd.SelectedPath + "\\");
                        this.Close();
                    }
                }
            }
        }

        private void fSUB_Load(object sender, EventArgs e)
        {
            reportItem = new rpTHEDAIHOI();
            reportItem.DataSource = doanVienBUS.Instance.printDSDV(id);
            reportItem.BindList();
            documentViewer1.PrintingSystem = reportItem.PrintingSystem;
            reportItem.CreateDocument();
        }
    }
}