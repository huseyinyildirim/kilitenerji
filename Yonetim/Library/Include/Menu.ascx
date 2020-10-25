<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Yonetim_Library_Include_Menu" %>

<div class="menu">
    <ul>
        <li><a href="Default.aspx">Panel</a></li>
        <li><a href="#">İçerik Yönetimi</a>
            <ul>
                <li><a class="sub1" href="#">Sayfa Yönetimi</a>
                    <ul>
                        <li><a href="Sayfa.aspx">Sayfa Listesi</a></li>
                        <li><a href="SayfaEkle.aspx">Sayfa Ekle</a></li>
                    </ul>
                </li>
                <li><a class="sub1" href="#">Referans Yönetimi</a>
                    <ul>
                        <li><a href="Referans.aspx">Referans Listesi</a></li>
                        <li><a href="ReferansEkle.aspx">Referans Ekle</a></li>
                    </ul>
                </li>
                <li><a class="sub1" href="#">Banner Yönetimi</a>
                    <ul>
                        <li><a href="Manset.aspx">Banner Listesi</a></li>
                        <li><a href="MansetEkle.aspx">Banner Ekle</a></li>
                    </ul>
                </li>
                <li><a class="sub1" href="#">Döküman Yönetimi</a>
                    <ul>
                        <li><a href="Dokuman.aspx">Döküman Listesi</a></li>
                        <li><a href="DokumanEkle.aspx">Döküman Ekle</a></li>
                    </ul>
                </li>
            </ul>
            
        </li>
        <li><a href="#">Haber Yönetimi</a>
            <ul>
                <li><a href="Haber.aspx">Haber Listesi</a></li>
                <li><a href="HaberEkle.aspx">Haber Ekle</a></li>
            </ul>
        </li>
        <li><a href="#">Ürün Yönetimi</a>
            <ul>
                <li><a class="sub1" href="Sayfa.aspx">Ürünler</a>
                    <ul>
                        <li><a href="Urun.aspx">Ürün Listesi</a></li>
                        <li><a href="UrunEkle.aspx">Ürün Ekle</a></li>
                    </ul>
                </li>
                <li><a class="sub1" href="#">Kategori Yönetimi</a>
                    <ul>
                        <li><a href="Kategori.aspx">Kategori Listesi</a></li>
                        <li><a href="KategoriEkle.aspx">Kategori Ekle</a></li>
                    </ul>
                </li>
            </ul>
        </li>
        <li><a href="#">E-Bülten</a>
            <ul>
                <li><a href="Bulten.aspx">E-Posta Listesi</a></li>
                <li><a href="BultenEkle.aspx">E-Posta Ekle</a></li>
                <li><a href="BultenGonder.aspx">E-Posta Gönder</a></li>
            </ul>
        </li>
        <li><a href="#">Parametreler</a>
            <ul>
                <li><a href="Ayar.aspx">Ayarlar</a></li>
                <li><a href="Bakim.aspx">Bakım</a></li>
            </ul>
        </li>
        <li><a href="Cikis.aspx">Güvenli Çıkış</a></li>
    </ul>
</div>