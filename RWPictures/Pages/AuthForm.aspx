<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthForm.aspx.cs" Inherits="RWPictures.Pages.AuthForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="~/Content/styles.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auth_page">
            <div>
                
                <div>
                    <asp:TextBox ID="textBoxLogin" placeholder="Логин" runat="server"></asp:TextBox>
                </div>
                
                <div>
                    <asp:TextBox ID="textBoxPassword" placeholder="Пароль" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="loginBtn" runat="server" Text="Войти" OnClick="loginBtn_Click" />
                </div>
                <div>
                    <a href="Registration.cshtml">Регистрация</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
