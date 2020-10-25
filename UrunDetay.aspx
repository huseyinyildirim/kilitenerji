<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UrunDetay.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="include" TagName="head" Src="~/Library/Include/Head.ascx" %>
<%@ Register TagPrefix="include" TagName="alt" Src="~/Library/Include/Alt.ascx" %>
<%@ Register TagPrefix="include" TagName="menu" Src="~/Library/Include/Menu.ascx" %>
<%@ Register TagPrefix="include" TagName="manset" Src="~/Library/Include/Manset.ascx" %>
<%@ Register TagPrefix="include" TagName="solblok" Src="~/Library/Include/SolBlok.ascx" %>
<%@ Register TagPrefix="include" TagName="logo" Src="~/Library/Include/Logo.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <include:head runat="server" ID="head" />
    <script src="Library/App/Lightbox/js/jquery.lightbox-0.5.js" type="text/javascript"></script>
    <link href="Library/App/Lightbox/css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script src="Library/App/Tabs/Tabs.js" type="text/javascript"></script>
    <link href="Library/App/Tabs/Tabs.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('#resim a').lightBox();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cerceve">

            <include:logo runat="server" ID="logo" />

            <div class="iccerceve">

                <include:menu runat="server" ID="menu" />

                <include:manset runat="server" ID="manset" />
                <div class="icerik">
                    <div class="sol">
                        <include:solblok runat="server" ID="solblok" />
                    </div>
                    <div class="sag">
                        <div class="metin">
                            <asp:Literal runat="server" ID="detay" />
                            <div style="overflow:hidden;">
                                <div id="detaylar" class="usual"> 
                                  <ul> 
                                    <li><a class="selected" href="#tab1">Teknik Bilgiler</a></li>
                                    <li><a href="#tab2">Fotoğraf Galeri</a></li>
                                    <li><a style="font-weight:bold;" href="#tab3">Teklif Al</a></li>
                                  </ul> 
                                  <div class="tablar" id="tab1" runat="server"></div>
                                  <div class="tablar" id="tab2"><div style="overflow:hidden;" class="resim" runat="server" id="resim"></div></div>
                                  <div class="tablar" id="tab3">
                                    Ürünümüz hakkında teklif almak istiyorsanız, lütfen aşağıdaki formu eksiksiz doldurun. En kısa zaman içinde tarafınıza dönülecektir.<br />
&nbsp;<table>
                                          <tr>
                                              <td>
                                                  <strong>Adınız Soyadınız</strong></td>
                                              <td>
                                                  <strong>:</strong></td>
                                              <td>
                                                  <asp:TextBox ID="form_fiyat_ad" runat="server" Width="250px"></asp:TextBox>
                                              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                      ControlToValidate="form_fiyat_ad" ErrorMessage="*" ForeColor="#FF3300" 
                                                      ValidationGroup="fiyat"></asp:RequiredFieldValidator>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <strong>E-Posta</strong></td>
                                              <td>
                                                  <strong>:</strong></td>
                                              <td>
                                                  <asp:TextBox ID="form_fiyat_eposta" runat="server" Width="250px"></asp:TextBox>
                                              &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                      runat="server" ControlToValidate="form_fiyat_eposta" ErrorMessage="*" 
                                                      ForeColor="#FF3300" 
                                                      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                      ValidationGroup="fiyat"></asp:RegularExpressionValidator>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <strong>Telefon</strong></td>
                                              <td>
                                                  <strong>:</strong></td>
                                              <td>
                                                  <asp:TextBox ID="form_fiyat_telefon" runat="server" Width="250px"></asp:TextBox>
                                              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                      ControlToValidate="form_fiyat_telefon" ErrorMessage="*" ForeColor="#FF3300" 
                                                      ValidationGroup="fiyat"></asp:RequiredFieldValidator>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <strong>Ürün Adı</strong></td>
                                              <td>
                                                  <strong>:</strong></td>
                                              <td>
                                                  <asp:TextBox ID="form_fiyat_urun" runat="server" Width="250px" ReadOnly="True"></asp:TextBox>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td valign="top">
                                                  <strong>Mesajınız</strong></td>
                                              <td valign="top">
                                                  <strong>:</strong></td>
                                              <td>
                                                  <asp:TextBox ID="form_fiyat_mesaj" runat="server" Height="150px" TextMode="MultiLine" 
                                                      Width="300px"></asp:TextBox>
                                              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                      ControlToValidate="form_fiyat_mesaj" ErrorMessage="*" ForeColor="#FF3300" 
                                                      ValidationGroup="fiyat"></asp:RequiredFieldValidator>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Button ID="Button1" runat="server" Text="Teklif Al" 
                                                      ValidationGroup="fiyat" onclick="Button1_Click" />
                                              </td>
                                          </tr>
                                      </table>
                                    </div>
                                </div>
                                <script type="text/javascript">
                                    $("#detaylar ul").idTabs();
                                </script>
                            </div>

                        </div>               
                    </div>
                </div>

            </div>
            
            <include:alt runat="server" ID="alt" />

        </div>
    </form>
</body>
</html>

