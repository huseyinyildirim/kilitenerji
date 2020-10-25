using System;
using System.Web.UI;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Page.MetaDescription = Class.Fonksiyonlar.Genel.ParametreAl("Aciklama");
        Page.MetaKeywords = Class.Fonksiyonlar.Genel.ParametreAl("Anahtar");

        string SQL = "SELECT Baslik FROM kategori WHERE ID=" + Request.QueryString["ID"].ToString() + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count > 0)
        {
            Page.Title = DS.Tables[0].Rows[0]["Baslik"].ToString() + " | " + Class.Fonksiyonlar.Genel.ParametreAl("Baslik");
            baslik.Text = "<h2>" + DS.Tables[0].Rows[0]["Baslik"].ToString() + "</h2>";
        }

        Urunler();
        AltKategori();
    }

    protected void Urunler()
    {
        string SQL = "SELECT (SELECT Url FROM urunresim WHERE UrunID=a.ID AND Varsayilan=1) AS Resim, (SELECT UstID FROM kategori WHERE ID=a.KatID) AS UstID, (SELECT Baslik FROM kategori WHERE ID=a.KatID) AS Kategori, a.ID, a.Baslik FROM urun a USE INDEX (ID, Onay, KatID) WHERE a.KatID=" + Request.QueryString["ID"].ToString() + " AND a.Onay=1 ORDER BY a.Baslik DESC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "urun");

        if (DS.Tables[0].Rows.Count > 0)
        {
            urunliste.DataSource = DS;
            urunliste.DataBind();
        }
        else
        {
            string SQL2 = "SELECT ID FROM kategori WHERE UstID=" + Request.QueryString["ID"].ToString() + "";
            DataSet DS2 = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL2, "kategori");

            if (DS2.Tables[0].Rows.Count > 0)
            {
                string SQL3 = "SELECT (SELECT Url FROM urunresim WHERE UrunID=a.ID AND Varsayilan=1) AS Resim, (SELECT UstID FROM kategori WHERE ID=a.KatID) AS UstID, (SELECT Baslik FROM kategori WHERE ID=a.KatID) AS Kategori, a.ID, a.Baslik FROM urun a USE INDEX (ID, Onay, KatID) WHERE a.KatID in (";

                for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                {
                    SQL3 += "" + DS2.Tables[0].Rows[i]["ID"].ToString() + ",";
                }

                SQL3 += "0) AND a.Onay=1 ORDER BY RaND() LIMIT 10";
                DataSet DS3 = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL3, "urun");

                if (DS3.Tables[0].Rows.Count > 0)
                {
                    urunliste.DataSource = DS3;
                    urunliste.DataBind();
                }
                else
                {
                    mesaj.Visible = true;
                }
            }
            else
            {
                mesaj.Visible = true;
            }
        }
    }


    protected void AltKategori()
    {
        string SQL = "SELECT ID, Baslik FROM kategori WHERE UstID=" + Request.QueryString["ID"].ToString() + " ORDER BY Baslik ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count > 0)
        {
            altkategori.Text = "<h2>Markalarımız</h2><table style=\"margin-top:10px;\" width=\"100%\"><tr>";

            int x = 1;
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                altkategori.Text += "<td><strong><a href=\"Kategori.aspx?ID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "\">&raquo; " + DS.Tables[0].Rows[i]["Baslik"].ToString() + "</a></strong></td>";

                if (x==3)
                {
                    altkategori.Text += "</tr><tr>";
                }
                else
                {
                    x = x + 1;
                }
            }

            altkategori.Text += "</tr></table><div class=\"\">&nbsp;</div>";
        }
    }
}