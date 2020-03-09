<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthForm.aspx.cs" Inherits="RWPictures.Pages.AuthForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Логин
            <div>
                <asp:TextBox ID="textBoxLogin" runat="server"></asp:TextBox>
            </div>
            Пароль
            <div>
                <asp:TextBox ID="textBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="loginBtn" runat="server" Text="Войти" OnClick="loginBtn_Click" />
            </div>
            <div>
                <a href="Registration.cshtml">Регистрация</a>
            </div>
        </div>
    </form>
</body>
</html>
