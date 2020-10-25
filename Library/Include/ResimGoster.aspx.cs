using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class Library_Include_ResimGoster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int yeni_genislik = Convert.ToInt32(Request.QueryString["G"].ToString());
            int yeni_yukseklik = Convert.ToInt32(Request.QueryString["Y"].ToString());

            Response.ContentType = "image/jpg";

            using (Bitmap alinan_resim = new Bitmap(Server.MapPath(Request.QueryString["R"])))
            {
                decimal genislik = alinan_resim.Width;
                decimal yukseklik = alinan_resim.Height;

                decimal genislik_oran = (decimal)genislik / yeni_genislik;
                decimal yukseklik_oran = (decimal)yukseklik / yeni_yukseklik;

                int olacak_genislik, olacak_yukseklik;

                if (genislik_oran > yukseklik_oran)
                {
                    olacak_genislik = (int)(genislik / yukseklik_oran);
                    olacak_yukseklik = yeni_yukseklik;
                }
                else
                {
                    olacak_genislik = yeni_genislik;
                    olacak_yukseklik = (int)(yukseklik / genislik_oran);
                }

                using (Bitmap Resim_Ciktisi = new Bitmap(alinan_resim, olacak_genislik, olacak_yukseklik))
                {
                    EncoderParameters enkoder_parametresi;
                    enkoder_parametresi = new EncoderParameters(1);
                    enkoder_parametresi.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                    // ISTERSENIZ 30L KISMINI 100L YAPIP, AŞAĞIDA Kİ SATIRLARI DA DEVREYE SOKABİLİRSİNİZ.

                    Graphics.FromImage(Resim_Ciktisi).CompositingQuality = CompositingQuality.HighSpeed;
                    Graphics.FromImage(Resim_Ciktisi).SmoothingMode = SmoothingMode.HighSpeed;
                    Graphics.FromImage(Resim_Ciktisi).PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Graphics.FromImage(Resim_Ciktisi).InterpolationMode = InterpolationMode.HighQualityBicubic;


                    Resim_Ciktisi.Save(Response.OutputStream, EnkoderBul(ImageFormat.Jpeg), enkoder_parametresi);
                    Resim_Ciktisi.Dispose();
                }
            }
        }

        catch (System.ArgumentException)
        {
            ResimYok();
        }
    }

    private ImageCodecInfo EnkoderBul(ImageFormat format)
    {
        ImageCodecInfo[] resim_kodekleri = ImageCodecInfo.GetImageDecoders();

        foreach (ImageCodecInfo i in resim_kodekleri)
        {
            if (i.FormatID == format.Guid)
            {
                return i;
            }
        }
        return null;
    }

    void ResimYok()
    {
        Response.ContentType = "image/gif";
        Bitmap resimyok = new Bitmap(Server.MapPath("/Library/Image/resimyok.gif"));
        resimyok.Save(Response.OutputStream, ImageFormat.Gif);
    }
}