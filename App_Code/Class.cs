using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using MySql.Data.MySqlClient;

public class Class
{
    public class Degiskenler
    {
        public static class MySQL
        {
            public static string Sunucu = "94.73.146.254";
            public static string Port = "3306";
            public static string Veritabani = "kilitenerji07";
            public static string Kullanici = "kilitenerji07";
            public static string Sifre = "ke0707ke";
        }

        public static class Diger
        {
            public static string vbCrLf = "\r\n";
            public static string TamAdres = String.Empty;
        }
    }

    public class Fonksiyonlar
    {
        public static class Genel
        {
            public static string HtmlTemizle(object str)
            {
                return Regex.Replace(str.ToString(), @"<(.|\n)*?>", string.Empty);
            }

            public static void ResimYukle(HttpPostedFile Dosya, int Genislik, int Yukseklik, string Yol)
            {
                Bitmap Resim = new Bitmap(Dosya.InputStream);
                if (Resim.Width > Genislik || Resim.Height > Yukseklik)
                {
                    Size ebatlar = new Size(Resim.Width, Resim.Height);
                    double oran = ((double)Resim.Width / (double)Resim.Height);
                    if (Resim.Width > Genislik && Genislik > 0)
                    {
                        ebatlar.Width = Genislik;
                        ebatlar.Height = (int)((double)Genislik / oran);
                    }
                    if (ebatlar.Height > Yukseklik && Yukseklik > 0)
                    {
                        ebatlar.Height = Yukseklik;
                        ebatlar.Width = (int)((double)Yukseklik * oran);
                    }
                    Resim = new Bitmap(Resim, ebatlar);
                }

                if (Dosya.ContentType == "image/jpeg" || Dosya.ContentType == "image/pjpeg")
                    Resim.Save(Yol, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (Dosya.ContentType == "image/gif")
                    Resim.Save(Yol, System.Drawing.Imaging.ImageFormat.Gif);
                else if (Dosya.ContentType == "image/png" || Dosya.ContentType == "image/x-png")
                    Resim.Save(Yol, System.Drawing.Imaging.ImageFormat.Png);
                Resim.Dispose();
            }

            public static void MailGonder(string GonderenAdSoyad, string GonderenEmail, string AliciEmail, string AliciAdSoyad, string Konu, string MailIcerigi)
            {
                MailAddress gonderen = new MailAddress(GonderenEmail, GonderenAdSoyad);
                MailAddress alan = new MailAddress(AliciEmail, AliciAdSoyad);
                MailMessage eposta = new MailMessage(gonderen, alan);
                eposta.IsBodyHtml = true;
                eposta.Subject = Konu;
                eposta.Body = MailIcerigi;
                NetworkCredential auth = new NetworkCredential(Class.Fonksiyonlar.Genel.ParametreAl("SmtpEPosta").ToString(), Class.Fonksiyonlar.Genel.ParametreAl("SmtpEPostaSifre").ToString());
                SmtpClient SMTP = new SmtpClient();
                SMTP.Host = Class.Fonksiyonlar.Genel.ParametreAl("Smtp").ToString();
                SMTP.UseDefaultCredentials = false;
                SMTP.Credentials = auth;
                SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTP.Send(eposta);
            }

            public class OturumIslemleri
            {
                public static void CookieOlustur(string CookieAdi, string Deger)
                {
                    HttpContext.Current.Response.SetCookie(new HttpCookie(CookieAdi, Deger));
                }

                public static void CookieSil()
                {
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Session.Abandon();

                    string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
                    HttpCookie tmpCookie;

                    foreach (string cookieKey in cookies)
                    {
                        tmpCookie = HttpContext.Current.Response.Cookies[cookieKey];
                        tmpCookie.Expires = DateTime.Now.AddDays(-2);
                        HttpContext.Current.Response.Cookies.Add(tmpCookie);
                    }

                    //HttpContext.Current.Response.Redirect("Giris.aspx");
                }

                public static void CookieKontrol()
                {
                    if (HttpContext.Current.Request.Cookies["" + Class.Fonksiyonlar.Genel.ParametreAl("GuvenlikKodu") + "Giris"] != null)
                    {
                        if (HttpContext.Current.Request.Cookies["" + Class.Fonksiyonlar.Genel.ParametreAl("GuvenlikKodu") + "Giris"].Value != "7777777")
                        {
                            HttpContext.Current.Response.Redirect("Giris.aspx");
                        }
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("Giris.aspx");
                    }
                }
            }

            public static bool NumerikKontrol(string str)
            {
                int numeric;
                if (int.TryParse(str, out numeric))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static void ResimYok(int gen, int yuk, Single x, Single y, string soz, Color bg, Color fir)
            {
                HttpContext.Current.Response.ContentType = "image/jpg";
                Bitmap resimyok = new Bitmap(gen, yuk);
                Graphics.FromImage(resimyok).FillRectangle(new SolidBrush(bg), new Rectangle(0, 0, gen, yuk));
                Graphics.FromImage(resimyok).DrawString(soz, new Font("Helvetica", 12, FontStyle.Bold), new SolidBrush(fir), x, y, new StringFormat());
                resimyok.SetResolution(72, 72);
                resimyok.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Jpeg);
                resimyok.Dispose();
            }

            public static string SQLTemizle(string str)
            {
                try
                {
                    if (str != string.Empty)
                    {
                        str = str.Replace("'", "`");
                        str = str.Replace("’", "`");
                    }
                }
                catch
                {
                }

                return str;
            }

            public static string SeoLink(string str)
            {
                try
                {
                    if (str != string.Empty)
                    {
                        str = str.ToLower();
                        str = str.Replace("ç", "c");
                        str = str.Replace("ş", "s");
                        str = str.Replace(" ", "_");
                        str = str.Replace("ğ", "g");
                        str = str.Replace("ö", "o");
                        str = str.Replace("ü", "u");
                        str = str.Replace(".", "_");
                        str = str.Replace("ı", "i");
                        str = str.Replace("!", "");
                        str = str.Replace(",", "");
                        str = str.Replace(";", "");
                        str = str.Replace("'", "");
                    }
                }
                catch
                {
                }

                return str;
            }

            public static string StringTemizle(string str)
            {
                try
                {
                    if (str != string.Empty)
                    {
                        str = str.Replace("'", "");
                        str = str.Replace("’", "");
                        str = str.Replace("~", "");
                        str = str.Replace("}", "");
                        str = str.Replace("|", "");
                        str = str.Replace("{", "");
                        str = str.Replace("`", "");
                        str = str.Replace("^", "");
                        str = str.Replace("]", "");
                        str = str.Replace("\"", "");
                        str = str.Replace("[", "");
                        str = str.Replace("@", "");
                        str = str.Replace("?", "");
                        str = str.Replace(">", "");
                        str = str.Replace("=", "");
                        str = str.Replace("<", "");
                        str = str.Replace(";", "");
                        str = str.Replace("/", "");
                        str = str.Replace("-", "");
                        str = str.Replace("+", "");
                        str = str.Replace("*", "");
                        str = str.Replace(")", "");
                        str = str.Replace("(", "");
                        str = str.Replace("&", "");
                        str = str.Replace("%", "");
                        str = str.Replace("$", "");
                        str = str.Replace("#", "");
                        str = str.Replace("!", "");
                    }
                }
                catch
                {
                }

                return str;
            }

            public static string UrlvePathYaz()
            {
                string protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (String.IsNullOrEmpty(protocol) | String.Equals(protocol, "0"))
                    protocol = "http://";
                else
                    protocol = "https://";

                string currentAddress = HttpContext.Current.Request.Url.ToString();
                Regex rx = new Regex(@"([^/]*)(localhost|\blocalhost:\d+\b)([^/]*)", RegexOptions.IgnoreCase);
                Match MatchObj = rx.Match(currentAddress);
                if (!(string.IsNullOrEmpty(MatchObj.Groups[0].Value)))
                {
                    Degiskenler.Diger.TamAdres = String.Concat(protocol,
                    MatchObj.Groups[0].Value,
                    HttpContext.Current.Request.ApplicationPath);
                }
                else
                {
                    Degiskenler.Diger.TamAdres = String.Concat(protocol,
                    HttpContext.Current.Request.ServerVariables["SERVER_NAME"],
                    HttpContext.Current.Request.ApplicationPath);
                }

                if (!Degiskenler.Diger.TamAdres.EndsWith("/"))
                    Degiskenler.Diger.TamAdres += "/";

                return Degiskenler.Diger.TamAdres;
            }

            public static string MevcutSayfa()
            {
                return (HttpContext.Current.Request.Url.AbsoluteUri);
            }

            public static string Sifrele(string str)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(str + "-" + Class.Fonksiyonlar.Genel.ParametreAl("SistemAdres").ToString(), "sha1"), "md5"), "md5");
            }

            public static string ParametreAl(string str)
            {
                try
                {
                    string SQL = "SELECT " + str + " FROM parametre USE INDEX (ID) WHERE ID=1";
                    DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "parametre");
                    return string.Format("{0}", DS.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return "Parametre yok!";
                }
            }

            public static string KategoriAl(string ID)
            {
                try
                {
                    string SQL = "SELECT Baslik FROM kategori USE INDEX (ID) WHERE ID=" + ID + "";
                    DataSet DS = Class.Fonksiyonlar.MySQL.Komutlar.DataSetGetir(SQL, "kategori");
                    return string.Format("{0}", DS.Tables[0].Rows[0][0].ToString());
                }
                catch (Exception)
                {
                    return "-";
                    throw;
                }
            }
        }

        public class JavaScript
        {
            public static void Yonlendir(string Url)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type=\"text/javascript\">\n");
                sb.Append("//<![CDATA[\n");
                sb.Append("location.href=\"" + Url + "\"\n");
                sb.Append("//]]>\n");
                sb.Append("</script>\n");
                HttpContext.Current.Response.Write(sb.ToString());
            }

            public static void MesajKutusuVeYonlendir(string Mesaj, string Url)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type=\"text/javascript\">\n");
                sb.Append("//<![CDATA[\n");
                sb.Append("alert(\"" + Mesaj.Replace("[ln]", @"\n") + "\");\n");
                sb.Append("location.href=\"" + Url + "\"\n");
                sb.Append("//]]>\n");
                sb.Append("</script>\n");
                HttpContext.Current.Response.Write(sb.ToString());
            }

            protected static Hashtable handlerPages = new Hashtable();
            public static void MesajKutusu(string Message)
            {
                if (!(handlerPages.Contains(HttpContext.Current.Handler)))
                {
                    Page currentPage = (Page)HttpContext.Current.Handler;
                    if (!((currentPage == null)))
                    {
                        Queue messageQueue = new Queue();
                        messageQueue.Enqueue(Message);
                        handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                        currentPage.Unload += new EventHandler(CurrentPageUnload);
                    }
                }
                else
                {
                    Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                    queue.Enqueue(Message);
                }
            }

            private static void CurrentPageUnload(object sender, EventArgs e)
            {
                Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                if (queue != null)
                {
                    StringBuilder builder = new StringBuilder();
                    int iMsgCount = queue.Count;
                    builder.Append("<script language='javascript'>");
                    string sMsg;
                    while ((iMsgCount > 0))
                    {
                        iMsgCount = iMsgCount - 1;
                        sMsg = System.Convert.ToString(queue.Dequeue());
                        sMsg = sMsg.Replace("\"", "'");
                        builder.Append("alert( \"" + sMsg + "\" );");
                    }
                    builder.Append("</script>");
                    handlerPages.Remove(HttpContext.Current.Handler);
                    HttpContext.Current.Response.Write(builder.ToString());
                }
            }
        }

        public class MySQL
        {
            public static class Baglanti
            {
                public static string ConnectionString()
                {
                    return "SERVER=" + Degiskenler.MySQL.Sunucu + ";" + "PORT=" + Degiskenler.MySQL.Port + ";" + "DATABASE=" + Degiskenler.MySQL.Veritabani + ";" + "USER ID=" + Degiskenler.MySQL.Kullanici + ";" + "PASSWORD=" + Degiskenler.MySQL.Sifre + ";" + "CHARSET=utf8;CONNECTION TIMEOUT=60;DEFAULT COMMAND TIMEOUT=60;POOLING=TRUE;MAX POOL SIZE=15;MIN POOL SIZE=5";
                }

                public static MySqlConnection BaglantiCumlesi()
                {
                    return new MySqlConnection(ConnectionString());
                }
            }

            public static class Komutlar
            {
                public static DataSet DataSetGetir(string SQL, string TabloAdi)
                {
                    DataSet DS = new DataSet();

                    try
                    {
                        using (MySqlConnection MySQLCon = Baglanti.BaglantiCumlesi())
                        {
                            using (MySqlCommand MySQLCom = new MySqlCommand(SQL, MySQLCon))
                            {
                                using (MySqlDataAdapter MDA = new MySqlDataAdapter(SQL, MySQLCon))
                                {
                                    MySQLCon.Open();
                                    MDA.Fill(DS, TabloAdi);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }

                    return DS;
                }

                public static DataTable DataTableGetir(string SQL)
                {
                    DataTable DT = new DataTable();

                    try
                    {
                        using (MySqlConnection MySQLCon = Baglanti.BaglantiCumlesi())
                        {
                            using (MySqlCommand MySQLCom = new MySqlCommand(SQL, MySQLCon))
                            {
                                MySQLCon.Open();
                                DT.Load(MySQLCom.ExecuteReader());
                            }
                        }
                    }
                    catch
                    {
                    }

                    return DT;
                }

                public static string ExecuteNonQuery(string SQL)
                {
                    string sonuc = null;
                    try
                    {
                        using (MySqlConnection MySQLCon = Baglanti.BaglantiCumlesi())
                        {
                            using (MySqlCommand MySQLCom = new MySqlCommand(SQL, MySQLCon))
                            {
                                MySQLCon.Open();
                                sonuc = MySQLCom.ExecuteNonQuery().ToString();
                            }
                        }
                        return sonuc;
                    }
                    catch
                    {
                        return sonuc;
                    }
                }

                public static string ExecuteScalar(string SQL)
                {
                    string sonuc = null;
                    try
                    {
                        using (MySqlConnection MySQLCon = Baglanti.BaglantiCumlesi())
                        {
                            using (MySqlCommand MySQLCom = new MySqlCommand(SQL, MySQLCon))
                            {
                                MySQLCon.Open();
                                sonuc = MySQLCom.ExecuteScalar().ToString();
                            }
                        }
                        return sonuc;
                    }
                    catch
                    {
                    }
                    return sonuc;
                }
            }
        }
    }
}