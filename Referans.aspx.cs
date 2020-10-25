using System;
using System.Web.UI;
using System.Data;

public partial class _Referans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Referanslar | " + Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        Sayfa();
    }

    protected void Sayfa()
    {
        string SQL = "SELECT Baslik, Resim FROM referans WHERE Onay=1 ORDER BY Baslik ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "referans");

        referans.DataSource = DS.Tables[0].DefaultView;
        referans.DataBind();
    }
}