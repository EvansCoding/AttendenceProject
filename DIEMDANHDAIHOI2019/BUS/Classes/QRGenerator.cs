namespace BUS.Classes
{
    using System.Drawing;
    using ZXing;
    using ZXing.Common;
    using System.Windows.Forms;
    using ZXing.Rendering;
    using ZXing.QrCode.Internal;

    public class QRGenerator
    {
        private static QRGenerator instance;

        public static QRGenerator Instance
        {
            get
            {
                if (instance == null) return instance = new QRGenerator();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public void createQRCode(string code)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 300, Height = 300, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(code);
            Bitmap logo = new Bitmap(Properties.Resources.logoDthu);            
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
            saveQR(bitmap as Image, code);
        }

        private void saveQR(Image image, string code)
        {
            image.Save(Application.StartupPath + "\\QRCode\\" + code + ".jpg");
        }
    }
}
