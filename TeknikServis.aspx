<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeknikServis.aspx.cs" Inherits="_Default" %>

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
                        <div class="metin" runat="server" id="detay"></div>
                        <div class="y10">&nbsp;</div>
                        <div class="metin">
                            <h2>Teknik Servis Talep Formu</h2>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <strong>Firma Adı</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_firma" runat="server" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Yetkili Adı</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_ad" runat="server" Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="form_ad" ErrorMessage="*" ForeColor="#FF3300" 
                                                ValidationGroup="mail"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Telefon</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_tel" runat="server" Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="form_tel" ErrorMessage="*" ForeColor="#FF3300" 
                                                ValidationGroup="mail"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Faks</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_faks" runat="server" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>E-Posta</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_eposta" runat="server" Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                runat="server" ControlToValidate="form_eposta" ErrorMessage="*" 
                                                ForeColor="#FF3300" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                ValidationGroup="mail"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Konu</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_konu" runat="server" Width="250px">Teknik Servis Talebi</asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="form_konu" ErrorMessage="*" ForeColor="#FF3300" 
                                                ValidationGroup="mail"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <strong>Arızalı Ürün Modeli</strong></td>
                                        <td valign="top">
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_urunmodel" runat="server" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <strong>Açıklama</strong></td>
                                        <td valign="top">
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_mesaj" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="form_mesaj" ErrorMessage="*" ForeColor="#FF3300" 
                                                ValidationGroup="mail"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Gönder" onclick="Button1_Click" 
                                                ValidationGroup="mail" />
                                        </td>
                                    </tr>
                                </table>
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

