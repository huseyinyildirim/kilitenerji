using System;
using System.Data;
using System.IO;

public partial class Yonetim_Tur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        Islem();
        Kayitlar();
    }

    protected void Kayitlar()
    {
        string SQL = "SELECT a.ID, a.Baslik, a.KayitTarih, (SELECT Baslik FROM kategori WHERE ID=a.UstID) AS UstKategori, (CASE WHEN a.Onay=1 THEN 'EVET' ELSE 'HAYIR' END) AS Onay FROM kategori a USE INDEX (ID) ORDER BY UstKategori, Baslik ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");

        kayitlar.DataSource = DS;
        kayitlar.DataBind();
    }

    protected void Islem()
    {
        switch (Request.QueryString["Islem"])
        {
            case "sil":
                string SQL2 = "SELECT ID FROM urun USE INDEX (KatID) WHERE KatID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS2 = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL2, "urun");

                if (DS2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                    {
                        string SQL3 = "SELECT Url FROM urunresim WHERE UrunID=" + DS2.Tables[0].Rows[i]["ID"].ToString() + "";
                        DataSet DS3 = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL3, "urunresim");

                        if (DS3.Tables[0].Rows.Count > 0)
                        {
                            for (int x = 0; x < DS3.Tables[0].Rows.Count; x++)
                            {
                                if (File.Exists(Server.MapPath("~/Upload/Urun/" + DS3.Tables[0].Rows[x]["Url"].ToString() + "")))
                                {
                                    File.Delete(Server.MapPath("~/Upload/Urun/" + DS3.Tables[0].Rows[x]["Url"].ToString() + ""));
                                }
                            }
                        }
                        Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM urunresim WHERE UrunID=" + DS2.Tables[0].Rows[i]["ID"].ToString() + "");
                    }
                }

                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM urun WHERE KatID=" + Request.QueryString["ID"].ToString() + "");
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM kategori WHERE ID=" + Request.QueryString["ID"].ToString() + "");

                Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıda ait kategori bilgileri, detayları ve fotoğrafları silinmiştir.");
                break;

            case "durum":
                string SQL = "SELECT Onay FROM kategori USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    switch (DS.Tables[0].Rows[0]["Onay"].ToString())
                    {
                        case "0":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE kategori SET Onay=1 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu aktif yapılmıştır.");
                            break;
                        case "1":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE kategori SET Onay=0 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu pasif yapılmıştır.");
                            break;
                    }
                }
                break;
        }
    }
}