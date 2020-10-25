using System;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

public partial class Yonetim_GolfResim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        if (!Page.IsPostBack)
        {
            Kayitlar();
        }
        
        ResimYukle();
    }

    protected void Kayitlar()
    {
        if (Class.Fonksiyonlar.Genel.NumerikKontrol(Request.QueryString["ID"].ToString()))
        {
            string SQL = "SELECT a.* FROM referans a USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "referans");

            if (DS.Tables[0].Rows.Count > 0)
            {
                form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
                form_onay.Text = DS.Tables[0].Rows[0]["Onay"].ToString();

                kayittarih.Text = DS.Tables[0].Rows[0]["KayitTarih"].ToString();
            }
        }
        else
        {
            Response.Redirect("Referans.aspx");
        }
    }

    protected void ResimYukle()
    {
        string SQL = "SELECT Resim FROM referans USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "referans");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                otelresim.InnerHtml = "<div class=\"fotolar\"><img src=\"../Library/Include/ResimGoster.aspx?R=/Upload/Referans/" + DS.Tables[0].Rows[i]["Resim"].ToString() + "&G=100&Y=100\" alt=\"\" />";
            }   
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string ResimAdi = "_" + DateTime.Now.ToString("dd''MM''yyyy''HH''mm''ss") + ".jpg";
            Class.Fonksiyonlar.Genel.ResimYukle(resim.PostedFile, 1200, 768, Server.MapPath("~/Upload/Referans/" + ResimAdi.ToString() + ""));

            string SQL = "SELECT Resim FROM referans WHERE ID=" + Request.QueryString["ID"].ToString() + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "referans");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    if (File.Exists(Server.MapPath("~/Upload/Referans/" + DS.Tables[0].Rows[i]["Resim"].ToString() + "")))
                    {
                        File.Delete(Server.MapPath("~/Upload/Referans/" + DS.Tables[0].Rows[i]["Resim"].ToString() + ""));
                    }
                }
            }

            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE referans SET Resim='" + ResimAdi.ToString().Replace("_", "") + "' WHERE ID=" + Request.QueryString["ID"].ToString() + "");
            Response.Redirect("ReferansResimCrop.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Url=" + ResimAdi.ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Resim yüklerken hata oluştu! Lütfen tekrar deneyiniz.", "ReferansDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE referans SET Baslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', Onay=" + form_onay.SelectedValue + " WHERE ID=" + Request.QueryString["ID"].ToString() + "");
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Referans bilgileri düzenlenmiştir.", "ReferansDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz.", "ReferansDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReferansEkle.aspx");
    }
}