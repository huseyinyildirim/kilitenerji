using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetim_HaberDuzenle : System.Web.UI.Page
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
        string SQL = "SELECT * FROM haber USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haber");

        if (DS.Tables[0].Rows.Count > 0)
        {
            form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
            form_onay.Text = DS.Tables[0].Rows[0]["Onay"].ToString();

            kayittarih.Text = DS.Tables[0].Rows[0]["KayitTarih"].ToString();

            form_ozet.Text = DS.Tables[0].Rows[0]["Ozet"].ToString();
            form_detay.Text = DS.Tables[0].Rows[0]["Detay"].ToString();;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Haber.aspx");
    }

    protected void KayitEkle()
    {
        Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE haber SET Baslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', Ozet='" + form_ozet.Text + "', Detay='" + form_detay.Text + "', Onay=" + form_onay.SelectedValue + " WHERE ID=" + Request.QueryString["ID"].ToString() + "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            KayitEkle();

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Haber bilgileri düzenlenmiştir.", "HaberDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "HaberDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            KayitEkle();

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Haber bilgileri düzenlenmiştir. Şimdi resim yüklemeye geçiyorsunuz", "HaberResim.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "HaberDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("HaberEkle.aspx");
    }
}