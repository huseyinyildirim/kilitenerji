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
            DropDoldurYer();
            Kayitlar();
        }
    }

    protected void DropDoldurYer()
    {
        string SQL = "SELECT Baslik, ID FROM kategori WHERE UstID=0";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count > 0)
        {
            form_ustid.Items.Add(new ListItem("Ana Kategori","0"));

            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                form_ustid.Items.Add(new ListItem(DS.Tables[0].Rows[i]["Baslik"].ToString(), DS.Tables[0].Rows[i]["ID"].ToString()));
            }
        }
    }

    protected void Kayitlar()
    {
        string SQL = "SELECT (SELECT UstID FROM kategori WHERE ID=a.ID) AS UstKategori, a.* FROM kategori a USE INDEX (ID) WHERE a.ID=" + Request.QueryString["ID"].ToString() + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count > 0)
        {
            form_ustid.Text = DS.Tables[0].Rows[0]["UstKategori"].ToString();
            form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
            form_onay.Text = DS.Tables[0].Rows[0]["Onay"].ToString();

            kayittarih.Text = DS.Tables[0].Rows[0]["KayitTarih"].ToString();
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Kategori.aspx");
    }

    protected void KayitEkle()
    {
        Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE kategori SET Baslik='" + Class.Fonksiyonlar.Genel.SQLTemizle(form_baslik.Text) + "', UstID=" + form_ustid.SelectedValue + ", Onay=" + form_onay.SelectedValue + " WHERE ID=" + Request.QueryString["ID"].ToString() + "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            KayitEkle();

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Kategori bilgileri düzenlenmiştir.", "KategoriDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "KategoriDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            KayitEkle();

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Kategori bilgileri düzenlenmiştir.", "KategoriDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "KategoriDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("KategoriEkle.aspx");
    }
}