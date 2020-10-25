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
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO dokuman (Baslik, Onay) VALUES ('" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', " + form_onay.SelectedValue + ")");

            string SQL = "SELECT ID FROM dokuman ORDER BY ID DESC LIMIT 1";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "dokuman");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Döküman eklenmiştir.", "DokumanDuzenle.aspx?ID=" + DS.Tables[0].Rows[0]["ID"].ToString() + "");
                }
            }
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz.", "DokumanEkle.aspx");
            throw;
        }
    }
}