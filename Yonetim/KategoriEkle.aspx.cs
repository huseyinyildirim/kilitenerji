using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class Yonetim_GolfEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        if (!Page.IsPostBack)
        {
            DropDoldurYer();
        }
    }

    protected void DropDoldurYer()
    {
        string SQL = "SELECT Baslik, ID FROM kategori WHERE UstID=0";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        form_ustid.Items.Add(new ListItem("Ana Kategori Oluştur", "0"));

        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                form_ustid.Items.Add(new ListItem(DS.Tables[0].Rows[i]["Baslik"].ToString(), DS.Tables[0].Rows[i]["ID"].ToString()));
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO kategori (Baslik, UstID, Onay) VALUES ('" + Class.Fonksiyonlar.Genel.SQLTemizle(form_kategori.Text) + "', '" + form_ustid.SelectedValue + "', " + form_onay.SelectedValue + ")");
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Kategori eklenmiştir.", "KategoriEkle.aspx");
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "HaberEkle.aspx");
        }
    }
}