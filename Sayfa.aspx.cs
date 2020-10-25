using System;
using System.Web.UI;
using System.Data;

public partial class _Sayfa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        //SolMenu();
        Sayfa();
    }

    protected void SolMenu()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["UstID"]))
        {
            if (Request["UstID"] != "0")
            {
                string SQL = "SELECT (SELECT Baslik FROM sayfa WHERE ID=a.UstID) AS UstBaslik, a.ID, a.UstID, a.Baslik FROM sayfa a USE INDEX (UstID) WHERE a.UstID=" + Class.Fonksiyonlar.Genel.SQLTemizle(Request["UstID"]) + "";
                DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

                if (DS.Tables[0].Rows.Count > 0)
                {
                    blok.Visible = true;
                    blok.Text = "<div class=\"blok\"><h5>" + DS.Tables[0].Rows[0]["UstBaslik"].ToString().ToUpper() + "</h5><div><ul>";
                    for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                    {
                        blok.Text += "<li><a href=\"Sayfa.aspx?ID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "&UstID=" + DS.Tables[0].Rows[i]["UstID"].ToString() + "\">" + DS.Tables[0].Rows[i]["Baslik"].ToString() + "</a></li>";
                    }
                    blok.Text += "</ul></div></div><div class=\"y10\"></div>";
                }
            }
        }
    }

    protected void Sayfa()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            string SQL = "SELECT Baslik, Detay FROM sayfa USE INDEX (ID) WHERE ID=" + Class.Fonksiyonlar.Genel.SQLTemizle(Request["ID"]) + "";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

            if (DS.Tables[0].Rows.Count > 0)
            {
                Page.Title = DS.Tables[0].Rows[0]["Baslik"].ToString() + " | " + Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
                detay.InnerHtml = "<h2>" + DS.Tables[0].Rows[0]["Baslik"].ToString() + "</h2><div>" + DS.Tables[0].Rows[0]["Detay"].ToString() + "</div>";
            }
            else
            {
                Page.Title = Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
            }
        }
    }
}