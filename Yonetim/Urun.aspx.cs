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
        string SQL = "SELECT (SELECT UstID FROM kategori WHERE ID=a.KatID) AS UstID, (SELECT Baslik FROM kategori WHERE ID=a.KatID) AS Kategori, a.ID, a.Baslik, a.KayitTarih, (CASE WHEN a.Onay=1 THEN 'EVET' ELSE 'HAYIR' END) AS Onay FROM urun a USE INDEX (ID) ORDER BY Kategori ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "urun");

        kayitlar.DataSource = DS;
        kayitlar.DataBind();
    }

    protected void Islem()
    {
        switch (Request.QueryString["Islem"])
        {
            case "sil":
                string SQL2 = "SELECT Url FROM urunresim USE INDEX (UrunID) WHERE UrunID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS2 = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL2, "urunresim");

                if (DS2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                    {
                        if (File.Exists(Server.MapPath("~/Upload/Urun/" + DS2.Tables[0].Rows[i]["Url"].ToString() + "")))
                        {
                            File.Delete(Server.MapPath("~/Upload/Urun/" + DS2.Tables[0].Rows[i]["Url"].ToString() + ""));
                        }
                    }
                }
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM urun WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM urunresim WHERE UrunID=" + Request.QueryString["ID"].ToString() + "");

                Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıda ait bilgiler, detaylar ve fotoğraflar silinmiştir.");
                break;

            case "durum":
                string SQL = "SELECT Onay FROM urun USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "haber");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    switch (DS.Tables[0].Rows[0]["Onay"].ToString())
                    {
                        case "0":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE urun SET Onay=1 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu aktif yapılmıştır.");
                            break;
                        case "1":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE urun SET Onay=0 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu pasif yapılmıştır.");
                            break;
                    }
                }
                break;
        }
    }
}