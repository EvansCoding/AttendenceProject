namespace DIEMDANHDAIHOI2019.DIEMDANH
{
    using System.Drawing;
    public partial class US_ShortInfo1920x1080 : DevExpress.XtraEditors.XtraUserControl
    {
        public US_ShortInfo1920x1080(Image _picture, string _text)
        {
            InitializeComponent();
            pictureBox1.Image = _picture;
            label1.Text = _text;
        }
    }
}
