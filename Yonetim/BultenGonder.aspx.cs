using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetim_TurEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        Kisiler();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < kisiler.Items.Count; i++)
        {
            if (kisiler.Items[i].Selected)
            {
                Class.Fonksiyonlar.Genel.MailGonder(Class.Fonksiyonlar.Genel.ParametreAl("Firma").ToString(), Class.Fonksiyonlar.Genel.ParametreAl("EPosta").ToString(), kisiler.Items[i].Value.ToString(), kisiler.Items[i].Text.ToString(), form_konu.Text.Trim(), mesaj.Text);
            }
        }

        try
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("E-posta adreslerine gönderim başlamıştır.", "BultenGonder.aspx");
        }
        catch (Exception ex)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Beklenmeyen bir hata oluştu. Hata: " + ex + "");
        }
    }

    protected void Kisiler()
    {
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir("SELECT * FROM bulteneposta", "bulteneposta");

        for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
        {
            kisiler.Items.Add(new ListItem(DS.Tables[0].Rows[i]["Isim"].ToString() + " (" + DS.Tables[0].Rows[i]["EPosta"].ToString() + ")", DS.Tables[0].Rows[i]["EPosta"].ToString()));
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bulten.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("BultenEkle.aspx");
    }
}