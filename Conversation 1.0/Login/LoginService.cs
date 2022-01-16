using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Conversation_1._0.Login
{
    internal  class LoginService 
    {
        private Infraweb infra;

        public LoginService(Infraweb infra)
        {
            this.infra = infra;
        }
        public  void LoginToUser(string url, User user = null)
        {
            infra.WaitFor(2000);
            if (user == null)
            {
                user = new User();
            }

            string username = user.userName;
            string password = user.password;
            infra.driver.Navigate().GoToUrl(url);
            infra.WaitFor(2000);

            infra.InsertText(By.XPath("//input[contains(@placeholder,'User Name')]"),username);
            infra.InsertText(By.XPath("//input[contains(@placeholder,'Password')]"),password);
            
            infra.ClickOn(By.Id("loginButton"));
            infra.WaitFor(5000);
        }

        public void CloseLoginPopup()
        {
            infra.ClickOn(Conversation_Repo.ConversationRepos.closeAnnoyingPopUp);

        }

    }
}
