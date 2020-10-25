using System;
using System.Data;

public partial class Library_Include_Manset : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        manset.InnerHtml = "<ul class=\"aviaslider\" id=\"frontpage-slider\">";

        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir("SELECT * FROM manset WHERE Onay=1 ORDER BY RAND()", "manset");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                manset.InnerHtml += "<li><a href=\"" + DS.Tables[0].Rows[i]["Url"].ToString() + "\"><img src=\"Library/Include/ResimGoster.aspx?R=/Upload/Manset/" + DS.Tables[0].Rows[i]["Resim"].ToString() + "&G=940&Y=250\" alt=\"" + DS.Tables[0].Rows[i]["Baslik"].ToString() + " :: " + DS.Tables[0].Rows[i]["Aciklama"].ToString() + "\" /></a></li>";
            }
        }

        manset.InnerHtml += "</ul>";
    }
}