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
            string SQL = "SELECT a.* FROM dokuman a USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "dokuman");

            if (DS.Tables[0].Rows.Count > 0)
            {
                form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
                form_onay.Text = DS.Tables[0].Rows[0]["Onay"].ToString();

                kayittarih.Text = DS.Tables[0].Rows[0]["KayitTarih"].ToString();
            }
        }
        else
        {
            Response.Redirect("Dokuman.aspx");
        }
    }

    protected void ResimYukle()
    {
        string SQL = "SELECT Url FROM dokuman USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.StringTemizle(Request.QueryString["ID"].ToString()) + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "dokuman");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                otelresim.InnerHtml = "<img src=\"../Library/Image/indir.png\" /> <a href=\"/Upload/Dokuman/" + DS.Tables[0].Rows[i]["Url"].ToString() + "\" />Dökümanı İndir</a>";
            }   
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (dosya.HasFile)
            {
                dosya.PostedFile.SaveAs(Server.MapPath("/Upload/Dokuman/") + dosya.FileName);
                
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE dokuman SET Url='" + dosya.FileName + "' WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Döküman başarıyla yüklenmiştir.", "DokumanDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            }

            
        }
        catch (Exception ex)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Döküman yüklerken hata oluştu! Lütfen tekrar deneyiniz. Hata: " + ex.Message + "", "DokumanDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE dokuman SET Baslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', Onay=" + form_onay.SelectedValue + " WHERE ID=" + Request.QueryString["ID"].ToString() + "");
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Döküman bilgileri düzenlenmiştir.", "DokumanDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz.", "DokumanDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
            throw;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("DokumanEkle.aspx");
    }
}