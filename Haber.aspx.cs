using System;
using System.Web.UI;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        Haber();
        DigerHaber();
    }

    protected void Haber()
    {
        string SQL = "SELECT (SELECT Url FROM haberresim USE INDEX (HaberID, Varsayilan) WHERE HaberID=a.ID AND Varsayilan=1) AS Resim, a.ID, a.Baslik, a.Ozet, a.Detay, a.KayitTarih FROM haber a USE INDEX (Onay) WHERE a.Onay=1 AND ID='" + Request.QueryString["ID"].ToString() + "'";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haber");

        haber.DataSource = DS.Tables[0].DefaultView;
        haber.DataBind();
    }

    protected void DigerHaber()
    {
        string SQL = "SELECT (SELECT Url FROM haberresim USE INDEX (HaberID, Varsayilan) WHERE HaberID=a.ID AND Varsayilan=1) AS Resim, a.ID, a.Baslik, a.Ozet, a.Detay, a.KayitTarih FROM haber a USE INDEX (Onay) WHERE a.Onay=1 ORDER BY a.KayitTarih DESC LIMIT 15";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haber");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                digerhaber.InnerHtml += "&raquo; " + DS.Tables[0].Rows[i]["KayitTarih"].ToString() + " - <a href=\"Haber.aspx?ID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "\">" + DS.Tables[0].Rows[i]["Baslik"].ToString() + "</a><br />";
            }
        }
    }
}