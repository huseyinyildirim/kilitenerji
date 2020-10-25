using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

public partial class Yonetim_GolfResim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string SqlDosyaAdi = DateTime.Now.ToString("dd''MM''yyyy''HH''mm''ss");
            Process.Start("D:\\MySQL\\Program\\bin\\mysqldump.exe", "-u " + Class.Degiskenler.MySQL.Kullanici + " -p " + Class.Degiskenler.MySQL.Sifre + " " + Class.Degiskenler.MySQL.Veritabani + " -r C:\\webspace\\husam\\kilitenerji.com\\www\\Yedek\\" + SqlDosyaAdi + ".sql");
            FileStream st = new FileStream("C:\\webspace\\husam\\kilitenerji.com\\www\\Yedek\\" + SqlDosyaAdi + ".sql", FileMode.Open);
            StreamReader sr = new StreamReader(st);
            string metin = sr.ReadToEnd();
            st.Close();
            Response.Write(metin);
        try
        {
            
        }
        catch (Exception ex)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz. Hata: " + ex.Message + "", "Bakim.aspx");
            throw;
        }
    }
}