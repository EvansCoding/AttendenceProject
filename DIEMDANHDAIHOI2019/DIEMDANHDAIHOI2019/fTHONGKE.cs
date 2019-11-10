using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DIEMDANHDAIHOI2019.Report;
using DTODLL;

namespace DIEMDANHDAIHOI2019
{
    public partial class fTHONGKE : DevExpress.XtraEditors.XtraForm
    {
        public fTHONGKE(Guid guid)
        {
            InitializeComponent();
            _maDH = guid;
            load();
        }

        Guid _maDH; rpTHONGKE report;
        public void load()
        {
            report = new rpTHONGKE(_maDH);
            report.load();
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                        exportDOCX(fbd.SelectedPath + "\\");
                        this.Close();
                    }
                }
            }
        }

        private void exportDOCX(string path, string ID = null)
        {
            report.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            report.Margins.Bottom = 0;
            report.PrintingSystem.ShowPrintStatusDialog = false;
            report.PrintingSystem.ShowMarginsWarning = false;
            using (var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report))
            {
                printTool.Report.CreateDocument(false); // <- ADD THIS LINE  
                printTool.PrintingSystem.ExportToDocx(path + daiHoiDTO.Instance.gyByChuDe(_maDH) + "_Export.docx");
            }
        }
    }
}