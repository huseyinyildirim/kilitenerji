using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetim_GolfEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO haber (Baslik, Onay) VALUES ('" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', " + form_onay.SelectedValue + ")");

            string SQL = "SELECT ID FROM haber ORDER BY ID DESC LIMIT 1";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haber");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Haber eklenmiştir.", "HaberDuzenle.aspx?ID=" + DS.Tables[0].Rows[0]["ID"].ToString() + "");
                }
            }

            
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "HaberEkle.aspx");
        }
    }
}