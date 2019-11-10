namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    using System.Drawing;

    public partial class US_ShortInfor1366x768 : DevExpress.XtraEditors.XtraUserControl
    {
        public US_ShortInfor1366x768(Image _picture, string _text)
        {
            InitializeComponent();
            pictureBox1.Image = _picture;
            label1.Text = _text;
        }
    }
}
