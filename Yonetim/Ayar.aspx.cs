using System;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

public partial class Yonetim_GolfResim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        if (!Page.IsPostBack)
        {
            Kayitlar();
        }
    }

    protected void Kayitlar()
    {
        string SQL = "SELECT * FROM parametre WHERE ID=1";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "parametre");

        if (DS.Tables[0].Rows.Count>0)
        {
            form_sistembaslik.Text = DS.Tables[0].Rows[0]["SistemBaslik"].ToString();
            form_sistemadres.Text = DS.Tables[0].Rows[0]["SistemAdres"].ToString();
            form_siteadres.Text = DS.Tables[0].Rows[0]["SiteAdres"].ToString();
            form_smtp.Text = DS.Tables[0].Rows[0]["Smtp"].ToString();
            form_smtpeposta.Text = DS.Tables[0].Rows[0]["SmtpEPosta"].ToString();
            form_smtpepostasifre.Text = DS.Tables[0].Rows[0]["SmtpEPostaSifre"].ToString();
            form_guvenlikkodu.Text = DS.Tables[0].Rows[0]["GuvenlikKodu"].ToString();

            form_anasayfa.Text = DS.Tables[0].Rows[0]["AnaSayfa"].ToString();

            form_kullaniciad.Text = DS.Tables[0].Rows[0]["KullaniciAd"].ToString();
            form_sifre.Text = DS.Tables[0].Rows[0]["Sifre"].ToString();
            form_songiris.Text = DS.Tables[0].Rows[0]["SonGiris"].ToString();

            degistarih.Text = DS.Tables[0].Rows[0]["DegisTarih"].ToString();

            form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
            form_anahtar.Text = DS.Tables[0].Rows[0]["Anahtar"].ToString();
            form_aciklama.Text = DS.Tables[0].Rows[0]["Aciklama"].ToString();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE parametre SET AnaSayfa='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_anasayfa.Text) + "', SistemBaslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_sistembaslik.Text) + "', SistemAdres='" + form_sistemadres.Text + "', SiteAdres='" + form_siteadres.Text + "', Smtp='" + form_smtp.Text + "', SmtpEPosta='" + form_smtpeposta.Text + "', SmtpEPostaSifre='" + form_smtpepostasifre.Text + "', GuvenlikKodu='" + form_guvenlikkodu.Text + "', KullaniciAd='" + form_kullaniciad.Text + "', Sifre='" + form_sifre.Text + "', Baslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', Aciklama='" +Class.Fonksiyonlar.Genel.SQLTemizle(form_aciklama.Text) + "', Anahtar='" + form_anahtar.Text + "' WHERE ID=1");
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Parametreler düzenlenmiştir.", "Ayar.aspx");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik hata oluştu! Lütfen tekrar deneyiniz.", "Ayar.aspx");
            throw;
        }
    }
}