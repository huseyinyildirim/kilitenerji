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
        string SQL = "SELECT (SELECT Baslik FROM sayfa WHERE ID=a.UstID) AS UstKategori, a.Baslik, a.ID FROM sayfa a WHERE a.UstID=" + ID + "";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

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
        string SQL = "SELECT Baslik, ID FROM sayfa WHERE UstID=0";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

        if (DS.Tables[0].Rows.Count > 0)
        {
            form_katid.Items.Add(new ListItem("Üst Ana Sayfa", "0"));

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
            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("INSERT INTO sayfa (Baslik, UstID, Onay) VALUES ('" + Class.Fonksiyonlar.Genel.SQLTemizle(form_kategori.Text) + "', '" + form_katid.SelectedValue + "', " + form_onay.SelectedValue + ")");
            
            string SQL = "SELECT ID FROM sayfa ORDER BY ID DESC LIMIT 1";
            DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Sayfa eklenmiştir. Detaylarını düzenlemek için yönlendiriliyorsunuz.", "SayfaDuzenle.aspx?ID=" + DS.Tables[0].Rows[i]["ID"].ToString() + "");
                }
            }
        }
        catch (Exception)
        {
            Class.Fonksiyonlar.JavaScript.MesajKutusuVeYonlendir("Beklenmedik bir hata oluştu! Lütfen tekrar deneyiniz.", "SayfaEkle.aspx");
        }
    }
}