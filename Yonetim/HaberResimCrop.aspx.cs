using System;
using System.Drawing;
using System.IO;


public partial class Yonetim_GolfResimCrop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        example1.ImageUrl = "../Upload/Haber/" + Request.QueryString["Url"].ToString() + "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(input_x.Text);
        int y = Convert.ToInt32(input_y.Text);
        int w = Convert.ToInt32(input_w.Text);
        int h = Convert.ToInt32(input_h.Text);

        System.Drawing.Image image = Bitmap.FromFile(Server.MapPath("~/Upload/Haber/" + Request.QueryString["Url"].ToString() + ""));

        Bitmap bmp = new Bitmap(w, h, image.PixelFormat);
        Graphics g = Graphics.FromImage(bmp);
        g.DrawImage(image, new Rectangle(0, 0, w, h),
        new Rectangle(x, y, w, h), GraphicsUnit.Pixel);

        bmp.Save(Server.MapPath("~/Upload/Haber/" + Request.QueryString["Url"].ToString().Replace("_", "") + ""), image.RawFormat);
        bmp.Dispose();

        /*if (File.Exists(Server.MapPath("~/Upload/Saha/" + Request.QueryString["Url"].ToString() + "")))
        {
            File.Delete(Server.MapPath("~/Upload/Saha/" + Request.QueryString["Url"].ToString() + ""));
        }*/

        Response.Redirect("HaberResim.aspx?ID=" + Request.QueryString["ID"] + "");
    }
}