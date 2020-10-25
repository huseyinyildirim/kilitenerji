<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="_Default" %>

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
                        <div class="metin">
                            <asp:Literal runat="server" ID="altkategori" />
                            <asp:Literal runat="server" ID="baslik" />
                            <div>
                                <asp:Literal runat="server" ID="mesaj" Visible="false" Text="Bu kategoriye ait ürün bulunmamaktadır." />
                                <asp:DataList ID="urunliste" runat="server" CellPadding="10" RepeatColumns="2" 
                                    RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td valign="top" style="width:170px;"><img style="border:3px solid #EFEFEF;" src="/Library/Include/ResimGoster.aspx?R=/Upload/Urun/<%# DataBinder.Eval(Container.DataItem, "Resim") %>&G=150&Y=150" /></td>
                                                <td valign="top">
                                                    <strong>Ana Kategori : </strong><%# Class.Fonksiyonlar.Genel.KategoriAl(""+DataBinder.Eval(Container.DataItem, "UstID")) %><br />
                                                    <strong>Kategori : </strong><%# DataBinder.Eval(Container.DataItem, "Kategori") %><br />
                                                    <strong>Ürün Adı : </strong><%# DataBinder.Eval(Container.DataItem, "Baslik") %><br /><br />
                                                    <a href="UrunDetay.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>"><img src="Library/Image/urunincele.jpg" /></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
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

