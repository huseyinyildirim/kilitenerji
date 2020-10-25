using System;
using System.Data;
using System.IO;

public partial class Yonetim_Manset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        Islem();
        Kayitlar();
    }

    protected void Kayitlar()
    {
        string SQL = "SELECT a.ID, a.Resim, a.Url, a.KayitTarih, (CASE WHEN a.Onay=1 THEN 'EVET' ELSE 'HAYIR' END) AS Onay FROM manset a USE INDEX (ID) ORDER BY a.KayitTarih DESC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "manset");

        kayitlar.DataSource = DS;
        kayitlar.DataBind();
    }

    protected void Islem()
    {
        switch (Request.QueryString["Islem"])
        {
            case "sil":
                string SQL2 = "SELECT Resim FROM manset USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS2 = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL2, "manset");

                if (DS2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                    {
                        if (File.Exists(Server.MapPath("~/Upload/Manset/" + DS2.Tables[0].Rows[i]["Resim"].ToString() + "")))
                        {
                            File.Delete(Server.MapPath("~/Upload/Manset/" + DS2.Tables[0].Rows[i]["Resim"].ToString() + ""));
                        }
                    }
                }
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM manset WHERE ID=" + Request.QueryString["ID"].ToString() + "");

                Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıda ait manşet bilgileri, detayları ve fotoğrafları silinmiştir.");
                break;

            case "durum":
                string SQL = "SELECT Onay FROM manset USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "manset");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    switch (DS.Tables[0].Rows[0]["Onay"].ToString())
                    {
                        case "0":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE manset SET Onay=1 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu aktif yapılmıştır.");
                            break;
                        case "1":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE manset SET Onay=0 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu pasif yapılmıştır.");
                            break;
                    }
                }
                break;
        }
    }
}