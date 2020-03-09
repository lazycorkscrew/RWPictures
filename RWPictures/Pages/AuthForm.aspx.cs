using RWPictures.Entities;
using RWPictures.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RWPictures.Pages
{
    public partial class AuthForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = LogicProvider.Logic.GetMd5Hash(textBoxPassword.Text);

            HttpCookie loginCookie = new HttpCookie("login", login);
            loginCookie.Expires = DateTime.Now.AddDays(10);
            HttpCookie passwordCookie = new HttpCookie("password", password);
            passwordCookie.Expires = DateTime.Now.AddDays(10);

            Response.Cookies.Add(loginCookie);
            Response.Cookies.Add(passwordCookie);

            User user = LogicProvider.Logic.GetUserByLoginAndPass(login, password) as User;
            if(user != null)
            {
                Session.Add("user", user);
                Response.Redirect("~");
            }
        }
    }
}