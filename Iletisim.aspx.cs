using System;
using System.Web.UI;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "İletişim | " + Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        Sayfa();
    }

    protected void Sayfa()
    {
        string SQL = "SELECT Baslik, Detay FROM sayfa USE INDEX (ID) WHERE ID=8";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

        if (DS.Tables[0].Rows.Count>0)
        {
            detay.InnerHtml = "<h2>" + DS.Tables[0].Rows[0]["Baslik"].ToString() + "</h2><div>" + DS.Tables[0].Rows[0]["Detay"].ToString() + "</div>";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string mailicerik = "<strong>Adı Soyadı:</strong> " + form_ad.Text.Trim() + "<br /><br />";
        mailicerik += "<strong>Telefon:</strong> " + form_tel.Text.Trim() + "<br />";
        mailicerik += "<strong>E-Posta:</strong> <a href=\"mailto:" + form_eposta.Text.Trim() + "\">" + form_eposta.Text.Trim() + "</a><br /><br />";
        mailicerik += "<strong>Konu:</strong> " + form_konu.Text.Trim() + "<br /><br />";
        mailicerik += "<strong>Mesaj:</strong> " + form_mesaj.Text.Trim() + "";

        try
        {
            Class.Fonksiyonlar.Genel.MailGonder(form_ad.Text.Trim(), form_eposta.Text.Trim(), Class.Fonksiyonlar.Genel.ParametreAl("SmtpEPosta").ToString(), Class.Fonksiyonlar.Genel.ParametreAl("Baslik").ToString(), form_konu.Text.Trim(), mailicerik.ToString());
            //Class.Fonksiyonlar.Genel.MailGonder(Class.Fonksiyonlar.Genel.ParametreAl("SmtpEPosta").ToString(), form_ad.Text.Trim(), form_konu.Text.Trim(), mailicerik.ToString());
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Mesajınız başarıyla gönderilmiştir. En kısa zamanda tarafınıza dönüş yapılacaktır.","Iletisim.aspx");
        }
        catch (Exception ex)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Beklenmedik bir hata oluştu. Lütfen tekrar deneyiniz.");
            throw;
        }
    }
}