using System;
using System.Data;
using System.IO;

public partial class Yonetim_Golf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class.Fonksiyonlar.Genel.OturumIslemleri.CookieKontrol();

        Islem();
        Kayitlar();
    }

    protected void Kayitlar()
    {
        string SQL = "SELECT * FROM bulteneposta ORDER BY EPosta ASC";
        DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "bulteneposta");

        kayitlar.DataSource = DS;
        kayitlar.DataBind();
    }

    protected void Islem()
    {
        switch (Request.QueryString["Islem"])
        {
            case "sil":
                Class.Fonksiyonlar.MySQL.Komutlar.ExecuteNonQuery("DELETE FROM bulteneposta WHERE ID=" + Request.QueryString["ID"].ToString() + "");

                Class.Fonksiyonlar.JavaScript.MesajKutusu("İlgili kayıda ait bilgiler silinmiştir.");
                break;
        }
    }
}