using System;
using System.Data;

public partial class Library_Include_SolBlok : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Menu();
    }

    protected void Menu()
    {
        string SQL = "SELECT ID, Baslik FROM kategori USE INDEX (Onay, UstID) WHERE Onay=1 AND UstID=0 ORDER BY Baslik ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count>0)
        {
            menu.InnerHtml = "<ul>";
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                menu.InnerHtml += "<li><strong>&raquo; <a href=\"Kategori.aspx?ID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "\">" + DS.Tables[0].Rows[i]["Baslik"].ToString() + "</a></strong></li>";
            }
            menu.InnerHtml += "</ul>";
        }
    }

    protected void bulten_buton_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir("SELECT EPosta FROM bulteneposta WHERE EPosta='" + bulten_eposta.Text + "'", "bulteneposta");
            if (DS.Tables[0].Rows.Count == 0)
            {
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO bulteneposta (Isim, EPosta) VALUES ('" + Class.Fonksiyonlar.Genel.StringTemizle(bulten_isim.Text) + "', '" + bulten_eposta.Text + "')");
                Class.Fonksiyonlar.JavaScript.MesajKutusu("Sayın " + Class.Fonksiyonlar.Genel.StringTemizle(bulten_isim.Text) + ", bilgileriniz kayıt edilmiştir.");
            }
            else
            {
                Class.Fonksiyonlar.JavaScript.MesajKutusu("Sistemimize zaten kayıtlısınız!");
            }
        }
        catch
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Beklenmedik bir hata oluştu, lütfen tekrar deneyiniz.");
        }

        bulten_eposta.Text = "";
        bulten_isim.Text = "";
    }
}