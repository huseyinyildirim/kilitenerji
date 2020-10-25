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
        string SQL = "SELECT a.ID, a.Baslik, a.KayitTarih, (SELECT Baslik FROM sayfa WHERE ID=a.UstID) AS UstSayfa, (CASE WHEN a.Onay=1 THEN 'EVET' ELSE 'HAYIR' END) AS Onay FROM sayfa a USE INDEX (ID) ORDER BY UstSayfa, Baslik ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");

        kayitlar.DataSource = DS;
        kayitlar.DataBind();
    }

    protected void Islem()
    {
        switch (Request.QueryString["Islem"])
        {
            case "sil":

                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM sayfa WHERE ID=" + Request.QueryString["ID"].ToString() + "");

                Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıda ait bilgiler silinmiştir.");
                break;

            case "durum":
                string SQL = "SELECT Onay FROM sayfa USE INDEX (ID) WHERE ID=" + Request.QueryString["ID"].ToString() + "";
                DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "sayfa");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    switch (DS.Tables[0].Rows[0]["Onay"].ToString())
                    {
                        case "0":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE sayfa SET Onay=1 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu aktif yapılmıştır.");
                            break;
                        case "1":
                            Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("UPDATE sayfa SET Onay=0 WHERE ID=" + Request.QueryString["ID"].ToString() + "");
                            Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıdın durumu pasif yapılmıştır.");
                            break;
                    }
                }
                break;
        }
    }
}