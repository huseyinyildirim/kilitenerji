using System;
using System.Data;

public partial class Yonetim_Giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE parametre SET Sifre='" + Class.Fonksiyonlar.Genel.Sifrele("admin") + "' WHERE ID=1");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        KullaniciDenetle();
    }

    protected void KullaniciDenetle()
    {
        string SQL = "SELECT KullaniciAd FROM parametre WHERE KullaniciAd='" + Class.Fonksiyonlar.Genel.StringTemizle(giris_kullaniciadi.Text) + "'";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "parametre");

        if (DS.Tables[0].Rows.Count == 0)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Kullanıcı adı bulunamadı!");
        }
        else if (DS.Tables[0].Rows.Count == 1)
        {
            SifreDenetle();
        }
        else
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Bu kullanıcı adından sistemde mükerrer kayıt bulunmaktadır. Lütfen sistem yöneticinizle görüşün!");
        }
    }

    protected void SifreDenetle()
    {
        string SQL = "SELECT a.ID, a.KullaniciAd, a.Sifre FROM parametre a WHERE a.KullaniciAd='" + Class.Fonksiyonlar.Genel.StringTemizle(giris_kullaniciadi.Text) + "' AND a.Sifre='" + Class.Fonksiyonlar.Genel.StringTemizle(giris_sifre.Text) + "' AND ID=1";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kullanici");

        if (DS.Tables[0].Rows.Count == 0)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Şifreniz hatalıdır!");
        }
        else if (DS.Tables[0].Rows.Count == 1)
        {
                Class.Fonksiyonlar.Genel.OturumIslemleri.CookieOlustur("" + Class.Fonksiyonlar.Genel.ParametreAl("GuvenlikKodu") + "Giris", "7777777");
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE parametre SET SonGiris='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ID=1");
                Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Kimlik doğrulaması başarılı. Kontrol paneline yönlendiriliyorsunuz!", "Default.aspx");
        }
        else
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusu("Bu kullanıcı adından sistemde mükerrer kayıt bulunmaktadır. Lütfen sistem yöneticinizle görüşün!");
        }
    }
}