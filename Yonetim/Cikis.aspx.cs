using System;

public partial class Yonetim_Cikis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieSil();
        Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Başarıyla çıkış yaptınız. Tekrar bekleriz!", "Default.aspx");
    }
}