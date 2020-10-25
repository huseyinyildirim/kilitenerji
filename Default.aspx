<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                            <h2>Web Sitemize Hoşgeldiniz</h2>
                            <div><% Response.Write(Class.Fonksiyonlar.Genel.ParametreAl("AnaSayfa")); %></div>
                        </div>
                        <div class="y10">&nbsp;</div>
                        <div class="metin">
                            <h2>Size nasıl yardımcı olabiliriz?</h2>
                            <div>
                                <table width="100%">
                                    <tr>
                                        <td style="width:210px;"><img src="Library/Image/resim3-1.jpg" /></td>
                                        <td>&nbsp;</td>
                                        <td style="width:210px;"><img src="Library/Image/resim3-2.jpg" /></td>
                                        <td>&nbsp;</td>
                                        <td style="width:210px;"><img src="Library/Image/resim3-3.jpg" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width:210px;">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td style="width:210px;">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td style="width:210px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width:210px;"><a href="Urun.aspx"><strong>Ürünlerimiz &raquo;</strong></a></td>
                                        <td>&nbsp;</td>
                                        <td valign="top" style="width:210px;"><a href="TeknikServis.aspx"><strong>Teknik Destek &raquo;</strong></a></td>
                                        <td>&nbsp;</td>
                                        <td valign="top" style="width:210px;"><a href="Iletisim.aspx"><strong>İletişim &raquo;</strong></a></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width:210px;">Her işe, her ihtiyaçınıza göre ürünlerimizi incelemeden, ihtiyaçlarınıza karar 
                                            vermeyin. Sağlam yapılar doğru kararla oluşur.</td>
                                        <td>&nbsp;</td>
                                        <td valign="top" style="width:210px;">Konusunda profesyonel uzman ekibimizle sadece 
                                            satışta değil, ileri teknoloji desteğinizle her zaman ürünlerimizin arkasında 
                                            sizin yanınızdayız.</td>
                                        <td>&nbsp;</td>
                                        <td valign="top" style="width:210px;">Her türlü istek, öneri ve şikayetlerinizi 
                                            bildiriniz. Sizin görüş ve önerilerinize önem veriyoruz, sizi dinliyoruz.</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="y10">&nbsp;</div>
                        <div class="metin">
                            <h2>Haberler</h2>
                            <div>
                                <asp:DataList runat="server" ID="haber" RepeatColumns="2" CellSpacing="10" Width="100%">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                        Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td valign="top" style="width:160px;"><img style="border:3px solid #CCC;" src="/Library/Include/ResimGoster.aspx?R=/Upload/Haber/<%# DataBinder.Eval(Container.DataItem, "Resim") %>&G=150&Y=100" alt="<%# DataBinder.Eval(Container.DataItem, "Baslik") %>" /></td>
                                                <td valign="top"><strong><%# DataBinder.Eval(Container.DataItem, "Baslik") %></strong><%# DataBinder.Eval(Container.DataItem, "Ozet") %><a href="Haber.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>">Devamı &raquo;</a></td>
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

