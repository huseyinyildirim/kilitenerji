using System;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

public partial class Yonetim_GolfResim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO manset (Url, Onay, Resim) VALUES ('" + Class.Fonksiyonlar.Genel.SQLTemizle(form_url.Text) + "', " + form_onay.SelectedValue + ", 'default.jpg')");

            string SQL = "SELECT ID FROM manset ORDER BY ID DESC LIMIT 1";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "manset");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Manşet eklenmiştir.", "MansetDuzenle.aspx?ID=" + DS.Tables[0].Rows[0]["ID"].ToString() + "");
                }
            }
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz.", "MansetEkle.aspx");
            throw;
        }
    }
}