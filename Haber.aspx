<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Haber.aspx.cs" Inherits="_Default" %>

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

                <!-- İçerik başlıyor -->
                <div class="icerik">
                    <div class="sol">
                        <include:solblok runat="server" ID="solblok" />
                    </div>
                    <div class="sag">
                        <div class="metin">
                            
                                <asp:DataList runat="server" ID="haber" RepeatColumns="2" CellSpacing="10" Width="100%">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                        Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <h2><%# DataBinder.Eval(Container.DataItem, "Baslik") %></h2>
                                        <div>
                                        <table>
                                            <tr>
                                                <td valign="top" style="width:160px;"><img style="border:3px solid #CCC;" src="/Library/Include/ResimGoster.aspx?R=/Upload/Haber/<%# DataBinder.Eval(Container.DataItem, "Resim") %>&G=150&Y=100" alt="<%# DataBinder.Eval(Container.DataItem, "Baslik") %>" /></td>
                                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Ozet") %><%# DataBinder.Eval(Container.DataItem, "Detay") %><%# DataBinder.Eval(Container.DataItem, "KayitTarih") %></td>
                                            </tr>
                                        </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            <h2>Diğer Haberler</h2>
                            <div runat="server" id="digerhaber"></div>
                        </div>
                    </div>
                </div>

            </div>
            
            <include:alt runat="server" ID="alt" />

        </div>
    </form>
</body>
</html>

