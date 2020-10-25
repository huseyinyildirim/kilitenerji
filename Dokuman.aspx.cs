using System;
using System.Web.UI;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Dökümanlar | " + Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        Sayfa();
    }

    protected void Sayfa()
    {
        string SQL = "SELECT Baslik, Url FROM dokuman USE INDEX (Onay) WHERE Onay=1";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "dokuman");

        kayitlar.DataSource = DS;
        kayitlar.DataBind();
    }
}