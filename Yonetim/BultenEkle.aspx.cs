using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetim_TurEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO bulteneposta (Isim, EPosta) VALUES ('" + form_isim.Text.Trim() + "', '" + form_eposta.Text.Trim() + "')");

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("E-posta eklenmiştir.", "BultenEkle.aspx");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "BultenEkle.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bulten.aspx");
    }
}