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
            Kategori();
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
                form_katid.Items.Add(new ListItem(DS.Tables[0].Rows[i]["UstKategori"].ToString()+" > "+ DS.Tables[0].Rows[i]["Baslik"].ToString(), DS.Tables[0].Rows[i]["ID"].ToString()));
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO urun (Baslik, KatID, Onay) VALUES ('" + form_kategori.Text + "', '" + form_katid.SelectedValue + "', " + form_onay.SelectedValue + ")");
            
            string SQL = "SELECT ID FROM urun ORDER BY ID DESC LIMIT 1";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "urun");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Ürün eklenmiştir. Detaylarını düzenlemek için yönlendiriliyorsunuz.", "UrunDuzenle.aspx?ID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "");
                }
            }
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "UrunEkle.aspx");
        }
    }
}