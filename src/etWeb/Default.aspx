<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="etWeb._Default" %>

<%-- Please do not delete this file. It is used to ensure that ASP.NET MVC is activated by IIS when a user makes a "/" request to the server. --%><form 
id="form1" runat="server">
<asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
    Font-Size="0.8em" ForeColor="#333333" Height="210px" Width="410px">
    <TextBoxStyle Font-Size="0.8em" />
    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
    <LayoutTemplate>
        <table border="0" cellpadding="4" cellspacing="0" 
            style="border-collapse:collapse;">
            <tr>
                <td>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td align="center" colspan="2" 
                                style="color:White;background-color:#5D7B9D;font-size:0.9em;font-weight:bold;">
                                Iniciar sesión</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre 
                                de usuario:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" 
                                    ErrorMessage="El nombre de usuario es obligatorio." 
                                    ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." 
                                    ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="RememberMe" runat="server" 
                                    Text="Recordármelo la próxima vez." />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" 
                                    onclick="LoginButton_Click" Text="Inicio de sesión" ValidationGroup="Login1" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblMensajes" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
        ForeColor="White" />
</asp:Login>
</form>

