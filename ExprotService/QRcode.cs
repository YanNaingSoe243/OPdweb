using QRCoder;
using System;
using System.IO;

namespace OPdWebApp.ExprotService
{
    public class WebCamOptions
    {
        public int Width { get; set; } = 480;
        public string VideoID { get; set; }
        public string CanvasID { get; set; }
        public string Filter { get; set; } = null;
    }
    public class QRcode
    {
        public string QRCODE(string Code)
        {
            string qrcodestr = "";
            try
            {


                using (MemoryStream stream = new MemoryStream())
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();

                    //QRCodeData qrCodeData = qrGenerator.CreateQrCode(Code, QRCodeGenerator.ECCLevel.Q);

                    //QRCode qrCode = new QRCode(qrCodeData);

                    //using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    //{
                    //    qrCodeImage.Save(stream, ImageFormat.Png);
                    //    qrcodestr = Convert.ToBase64String(stream.ToArray());
                    //}

                    var z = qrGenerator.CreateQrCode(Code, QRCoder.QRCodeGenerator.ECCLevel.H);
                    QRCoder.PngByteQRCode png = new QRCoder.PngByteQRCode();
                    png.SetQRCodeData(z);
                    var arr = png.GetGraphic(10);
                    stream.Write(arr, 0, arr.Length);
                    qrcodestr = Convert.ToBase64String(stream.ToArray());
                }
            }
            catch (Exception e)
            {

            }
            return qrcodestr;
        }

    }
}
