using System;
using System.IO;
using System.Data;

public partial class Yonetim_GolfResim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        Islemler();
        Kayitlar();
        ResimYukle();
    }

    protected void Islemler()
    {
        switch (Request.QueryString["Islem"])
        {
            case "varsayilan":
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE haberresim SET Varsayilan=0 WHERE HaberID=" + Request.QueryString["ID"].ToString() + "");
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE haberresim SET Varsayilan=1 WHERE ID=" + Request.QueryString["ResimID"].ToString() + "");
                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Varsayılan resim ayarlanmıştır.", "HaberResim.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
                break;

            case "sil":
                if (File.Exists(Server.MapPath("~/Upload/Haber/" + Request.QueryString["Url"].ToString() + "")))
                {
                    File.Delete(Server.MapPath("~/Upload/Haber/" + Request.QueryString["Url"].ToString() + ""));
                    Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM haberresim WHERE ID=" + Request.QueryString["ResimID"].ToString() + "");
                    Class.Fonksiyonlar.JavaScript.MesajKutusu("Resim silinmiştir.");
                }
                else
                {
                    Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM haberresim WHERE ID=" + Request.QueryString["ResimID"].ToString() + "");
                    Class.Fonksiyonlar.JavaScript.MesajKutusu("Sunucuda resim yüklü değildir ama veritabanından kayıdını sildik.");
                }
                break;
        }
    }

    protected void Kayitlar()
    {
        if (Class.Fonksiyonlar.Genel.NumerikKontrol(Request.QueryString["ID"].ToString()))
        {
            string SQL = "SELECT a.ID, a.Baslik, (CASE WHEN a.Onay=1 THEN 'EVET' ELSE 'HAYIR' END) AS Onay FROM haber a USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "saha");

            if (DS.Tables[0].Rows.Count > 0)
            {
                otelbilgi.InnerHtml = "<strong>Haber Başlık: </strong>" + DS.Tables[0].Rows[0]["Baslik"].ToString() + "<br /><strong>Durumu: </strong>" + DS.Tables[0].Rows[0]["Onay"].ToString() + "";
            }
        }
        else
        {
            Response.Redirect("Haber.aspx");
        }
    }

    protected void ResimYukle()
    {
        string SQL = "SELECT * FROM haberresim USE INDEX (HaberID) WHERE HaberID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haberresim");

        if (DS.Tables[0].Rows.Count > 0)
        {
            otelresim.InnerHtml = "";
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                if (DS.Tables[0].Rows[i]["Varsayilan"].ToString() == "1")
                {
                    otelresim.InnerHtml += "<div class=\"fotolar\" style=\"border:2px solid Red;\"><img src=\"../Library/Include/ResimGoster.aspx?R=/Upload/Haber/" + DS.Tables[0].Rows[i]["Url"].ToString() + "&G=150&Y=100\" alt=\"\" /><br /><a href=\"?Islem=varsayilan&ResimID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\">Varsayılan</a> - <a class=\"ask\" href=\"?Islem=sil&ResimID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&Url=" + DS.Tables[0].Rows[i]["Url"].ToString() + "\">Sil</a></div>";
                }
                else
                {
                    otelresim.InnerHtml += "<div class=\"fotolar\"><img src=\"../Library/Include/ResimGoster.aspx?R=/Upload/Haber/" + DS.Tables[0].Rows[i]["Url"].ToString() + "&G=150&Y=100\" alt=\"\" /><br /><a href=\"?Islem=varsayilan&ResimID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\">Varsayılan</a> - <a class=\"ask\" href=\"?Islem=sil&ResimID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&Url=" + DS.Tables[0].Rows[i]["Url"].ToString() + "\">Sil</a></div>";
                }
            }   
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string ResimAdi = "_" + DateTime.Now.ToString("dd''MM''yyyy''HH''mm''ss") + ".jpg";
            Class.Fonksiyonlar.Genel.ResimYukle(resim.PostedFile, 1200, 800, Server.MapPath("~/Upload/Haber/" + ResimAdi.ToString() + ""));

            string SQL = "SELECT COUNT(ID) FROM haberresim USE INDEX (HaberID) WHERE HaberID=" + Request.QueryString["ID"].ToString() + " AND Varsayilan=1";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haberresim");
            if (DS.Tables[0].Rows[0][0].ToString() == "0")
            {
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO haberresim (HaberID, Url, KullaniciID, Varsayilan) VALUES (" + Request.QueryString["ID"].ToString() + ", '" + ResimAdi.ToString().Replace("_", "") + "', " + Request.Cookies["" + Class.Fonksiyonlar.Genel.ParametreAl("GuvenlikKodu") + "KullaniciID"].Value + ", 1)");
            }
            else
            {
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO haberresim (HaberID, Url, KullaniciID) VALUES (" + Request.QueryString["ID"].ToString() + ", '" + ResimAdi.ToString().Replace("_", "") + "', " + Request.Cookies["" + Class.Fonksiyonlar.Genel.ParametreAl("GuvenlikKodu") + "KullaniciID"].Value + ")");
            }
            Response.Redirect("HaberResimCrop.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Url=" + ResimAdi.ToString() + "");
            //Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Resim yüklendi!", "GolfResimCrop.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Url=" + ResimAdi.ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Resim yüklerken hata oluştu! Lütfen tekrar deneyiniz.", "HaberResim.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Haber.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("HaberDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("HaberEkle.aspx");
    }
}