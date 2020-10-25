<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SolBlok.ascx.cs" Inherits="Library_Include_SolBlok" %>

                        <div class="blok">
                            <h5>ÜRÜNLERİMİZ</h5>
                            <div runat="server" id="menu"></div>
                        </div>
                        <div class="y10"></div>
                        <div class="blok">
                            <h5>E-BÜLTEN</h5>
                            <div>Ürün, kampanya ve duyurulardan ilk önce siz haberdar olmak istiyorsanız, lütfen aşağıdaki form ile 
                                kayıt olunuz.<br />
                                <br />
                                Adınız Soyadınız<br />
                                <asp:TextBox ID="bulten_isim" runat="server" Width="200px"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="bulten_isim" ErrorMessage="*" ForeColor="#CC3300" 
                                    ValidationGroup="bulten"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                E-Posta Adresiniz<br />
                                <asp:TextBox ID="bulten_eposta" runat="server" Width="200px"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                    runat="server" ControlToValidate="bulten_eposta" ErrorMessage="*" 
                                    ForeColor="#CC3300" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="bulten"></asp:RegularExpressionValidator>
                                <br />
                                <br />
                                <asp:Button ID="bulten_buton" runat="server" Text="Kayıt Ol" 
                                    ValidationGroup="bulten" Width="69px" onclick="bulten_buton_Click" />
                            </div>
                        </div>