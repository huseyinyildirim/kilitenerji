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
            Kategori();
            Kayitlar();
        }
    }

    protected void AltKategori(int ID)
    {
        string SQL = "SELECT (SELECT Baslik FROM kategori WHERE ID=a.UstID) AS UstKategori, a.Baslik, a.ID FROM kategori a WHERE a.UstID=" + ID + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                form_katid.Items.Add(new ListItem(DS.Tables[0].Rows[i]["UstKategori"].ToString() + " > " + DS.Tables[0].Rows[i]["Baslik"].ToString(), DS.Tables[0].Rows[i]["ID"].ToString()));
            }
        }
    }

    protected void Kategori()
    {
        string SQL = "SELECT Baslik, ID FROM kategori WHERE UstID=0";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                form_katid.Items.Add(new ListItem(DS.Tables[0].Rows[i]["Baslik"].ToString(), DS.Tables[0].Rows[i]["ID"].ToString()));

                AltKategori(Int32.Parse(DS.Tables[0].Rows[i]["ID"].ToString()));
            }
        }
    }

    protected void Kayitlar()
    {
        string SQL = "SELECT * FROM urun USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "urun");

        if (DS.Tables[0].Rows.Count > 0)
        {
            form_baslik.Text = DS.Tables[0].Rows[0]["Baslik"].ToString();
            form_katid.Text = DS.Tables[0].Rows[0]["KatID"].ToString();
            form_onay.Text = DS.Tables[0].Rows[0]["Onay"].ToString();

            kayittarih.Text = DS.Tables[0].Rows[0]["KayitTarih"].ToString();
            degistarih.Text = DS.Tables[0].Rows[0]["DegisTarih"].ToString();

            form_detay.Text = DS.Tables[0].Rows[0]["Detay"].ToString();;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Urun.aspx");
    }

    protected void KayitEkle()
    {
        Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE urun SET KatID=" + form_katid.SelectedValue + ", Baslik='" + form_baslik.Text + "', Detay='" + form_detay.Text + "', Onay=" + form_onay.SelectedValue + " WHERE ID=" + Request.QueryString["ID"].ToString() + "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            KayitEkle();

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Ürün bilgileri düzenlenmiştir.", "UrunDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "UrunDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            KayitEkle();

            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Ürün bilgileri düzenlenmiştir. Şimdi resim yüklemeye geçiyorsunuz", "UrunResim.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "UrunDuzenle.aspx?ID=" + Request.QueryString["ID"].ToString() + "");
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("UrunEkle.aspx");
    }
}