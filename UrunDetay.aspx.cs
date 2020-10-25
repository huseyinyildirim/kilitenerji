using System;
using System.Web.UI;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        Bilgiler();
        OtelGaleri();
    }

    protected void Bilgiler()
    {
        string SQL = "SELECT (SELECT Url FROM urunresim WHERE UrunID=a.ID AND Varsayilan=1) AS Resim, (SELECT UstID FROM kategori WHERE ID=a.KatID) UstID, (SELECT Baslik FROM kategori WHERE ID=a.KatID) Kategori, a.* FROM urun a WHERE a.ID=" + Request.QueryString["ID"].ToString() + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "urun");

        if (DS.Tables[0].Rows.Count > 0)
        {
            Page.Title = DS.Tables[0].Rows[0]["Baslik"].ToString() + " | " + Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
            detay.Text = "<h2>" + DS.Tables[0].Rows[0]["Baslik"].ToString() + "</h2><table style=\"margin-top:10px;\"><tr><td style=\"width:210px;\"><img src=\"/Library/Include/ResimGoster.aspx?R=/Upload/Urun/" + DS.Tables[0].Rows[0]["Resim"].ToString() + "&G=200&Y=200\" alt=\"\" /></td><td valign=\"top\"><strong>Ana Kategori:</strong> " + Class.Fonksiyonlar.Genel.KategoriAl(DS.Tables[0].Rows[0]["UstID"].ToString()) + "<br /><br /><strong>Kategori:</strong> " + DS.Tables[0].Rows[0]["Kategori"].ToString() + "</td></tr></table>";
            tab1.InnerHtml = DS.Tables[0].Rows[0]["Detay"].ToString();

            form_fiyat_urun.Text = Class.Fonksiyonlar.Genel.KategoriAl(DS.Tables[0].Rows[0]["UstID"].ToString()) + " " + DS.Tables[0].Rows[0]["Kategori"].ToString() + " " + DS.Tables[0].Rows[0]["Baslik"].ToString();
        }
    }

    protected void OtelGaleri()
    {
        string SQL = "SELECT * FROM urunresim USE INDEX (UrunID) WHERE UrunID=" + Request.QueryString["ID"].ToString() + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "urunresim");

        if (DS.Tables[0].Rows.Count > 0)
        {
            resim.InnerHtml = "<ul>";
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                resim.InnerHtml += "<li><a href=\"/Library/Include/ResimGoster.aspx?R=/Upload/Urun/" + DS.Tables[0].Rows[i]["Url"].ToString() + "&G=200&Y=200\" title=\"\"><img src=\"/Library/Include/ResimGoster.aspx?R=/Upload/Urun/" + DS.Tables[0].Rows[i]["Url"].ToString() + "&G=100&Y=100\" alt=\"\" /></a></li>";
            }
            resim.InnerHtml += "</ul>";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mailicerik = "<strong>Adı Soyadı:</strong> " + form_fiyat_ad.Text.Trim() + "<br /><br />";
        mailicerik += "<strong>Telefon:</strong> " + form_fiyat_telefon.Text.Trim() + "<br />";
        mailicerik += "<strong>E-Posta:</strong> " + form_fiyat_eposta.Text.Trim() + "<br /><br />";
        mailicerik += "<strong>Ürüm Adı:</strong> " + form_fiyat_urun.Text.Trim() + "<br /><br />";
        mailicerik += "<strong>Mesaj:</strong> " + form_fiyat_mesaj.Text.Trim() + "";

        try
        {
            Class.Fonksiyonlar.Genel.MailGonder(form_fiyat_ad.Text.Trim(), form_fiyat_eposta.Text.Trim(), Class.Fonksiyonlar.Genel.ParametreAl("SmtpEPosta").ToString(), Class.Fonksiyonlar.Genel.ParametreAl("Baslik").ToString(), "Teklif isteği var!", mailicerik.ToString());
            //Class.Fonksiyonlar.Genel.MailGonder(Class.Fonksiyonlar.Genel.ParametreAl("SmtpEPosta").ToString(), form_ad.Text.Trim(), form_konu.Text.Trim(), mailicerik.ToString());
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Teklif isteğiniz başarıyla gönderilmiştir. En kısa zamanda tarafınıza dönüş yapılacaktır.", "UrunDetay.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception ex)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Beklenmedik bir hata oluştu. Lütfen tekrar deneyiniz. Hata: " + ex.Message + "");
            throw;
        }
    }
}