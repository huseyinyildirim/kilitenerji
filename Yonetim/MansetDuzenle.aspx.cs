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
            string SQL = "SELECT a.* FROM manset a USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "manset");

            if (DS.Tables[0].Rows.Count > 0)
            {
                form_url.Text = DS.Tables[0].Rows[0]["Url"].ToString();
                form_onay.Text = DS.Tables[0].Rows[0]["Onay"].ToString();
                form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
                form_aciklama.Text = DS.Tables[0].Rows[0]["Aciklama"].ToString();

                kayittarih.Text = DS.Tables[0].Rows[0]["KayitTarih"].ToString();
            }
        }
        else
        {
            Response.Redirect("Manset.aspx");
        }
    }

    protected void ResimYukle()
    {
        string SQL = "SELECT Resim FROM manset USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "manset");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                otelresim.InnerHtml = "<div class=\"fotolar\"><img src=\"../Library/Include/ResimGoster.aspx?R=/Upload/Manset/" + DS.Tables[0].Rows[i]["Resim"].ToString() + "&G=800&Y=170\" alt=\"\" />";
            }   
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string ResimAdi = "_" + DateTime.Now.ToString("dd''MM''yyyy''HH''mm''ss") + ".jpg";
            Class.Fonksiyonlar.Genel.ResimYukle(resim.PostedFile, 1200, 768, Server.MapPath("~/Upload/Manset/" + ResimAdi.ToString() + ""));

            string SQL = "SELECT Resim FROM manset WHERE ID=" + Request.QueryString["ID"].ToString() + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "manset");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    if (File.Exists(Server.MapPath("~/Upload/Manset/" + DS.Tables[0].Rows[i]["Resim"].ToString() + "")))
                    {
                        File.Delete(Server.MapPath("~/Upload/Manset/" + DS.Tables[0].Rows[i]["Resim"].ToString() + ""));
                    }
                }
            }

            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE manset SET Resim='" + ResimAdi.ToString().Replace("_", "") + "' WHERE ID=" + Request.QueryString["ID"].ToString() + "");
            Response.Redirect("MansetResimCrop.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Url=" + ResimAdi.ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Resim yüklerken hata oluştu! Lütfen tekrar deneyiniz.", "MansetDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE manset SET Url='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_url.Text) + "', Onay=" + form_onay.SelectedValue + ", Baslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', Aciklama='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_aciklama.Text) + "' WHERE ID=" + Request.QueryString["ID"].ToString() + "");
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Manşet bilgileri düzenlenmiştir.", "MansetDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz.", "MansetDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("MansetEkle.aspx");
    }
}