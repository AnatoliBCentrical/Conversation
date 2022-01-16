using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Conversation_1._0.Login;
using Conversation_1._0.Validations;
using Conversation_1._0.Conversation_Service;

namespace Conversation_1._0.Conversation_Repo
{
    class ConversationRepos
    {
        public static string defaultUserPic = "/media-processed/4485/user/profilepicture--959184809_small.png?version=637468278546391325&Policy=eyJTdGF0ZW1lbnQiOiBbeyJSZXNvdXJjZSI6Imh0dHBzOi8vZ2U0Z2V0c3QyLmdhbWVmZmVjdGl2ZS5tZS9tZWRpYS1wcm9jZXNzZWQvNDQ4NS8qIiwiQ29uZGl0aW9uIjp7IkRhdGVMZXNzVGhhbiI6eyJBV1M6RXBvY2hUaW1lIjoxNjM4MjAxODg1fSwiRGF0ZUdyZWF0ZXJUaGFuIjp7IkFXUzpFcG9jaFRpbWUiOjE2Mzc1OTM0ODV9fX1dfQ__&Signature=nBuFnB-etgkiGKZFZS8skBZFXvSSvJPxOs7yzaWu23SPgAXytCeJN0~AQ0H8TCCg0l49SdKE~stvQSFmR8kbUhvlxGgEbITwIVO5O3cCcB0TElidqjAh5JpMf5auuGvvul3aoSCpFeuXbQGj9pD-gPBNVW5m5h4yxE-HyRKOPUQj-d-vGhgTd6NSwRzf8A0pBqb9Lc7EN-RFk~wU63ozczHkWhfaQuUF5yPao-pJzRNEJAvcOiuxRKptnD-0-n3aqx~FpTIiMtGqSt3Lp-kivjqKQFapV5aMOrnlsZneq3RFJQclTX3VtQ1TCG0a~J7lEexun0U2vCWW6mJvof0N9Q__&Key-Pair-Id=APKAI4G4PV5YM4G6VOPQ";

        public static By conversationHeader = By.Id("conversation-header");
        
        public static By textBox = By.XPath("//textarea[@test-id='conversation-message-input']");

        public static By GetRoomPath(string roomName)
        {
            return By.XPath($"//div[@test-id='conversation-room']//span[text()='{roomName}']");
        }

        public static By GetMessageReplyXpath(string msgTxt)
        {
            return By.XPath($"//div[text()='{msgTxt}']//parent::div//following-sibling::div//div[@test-id='conversation-reply-button']");

        }

        public static string generalRoomXPathWaitingForRoomName = "//div[@test-id='conversation-room']//[contains(.,{0})]";
        
        public static string lastMessageXPath = "(//conversation-message)[last()]";

        public static By lastMessageSenderPicXPath = By.XPath($"{lastMessageXPath}//div[(@class='user-image gm-image ng-star-inserted circle')]");

        public static By lastMessageSenderNameXPath = By.XPath($"{lastMessageXPath}//div[(@class='sender-name ng-star-inserted')]");

        public static By lastMessageSendDateXpath = By.XPath($"{lastMessageXPath}//div[(@class='message-send-date')]");
                         
        public static By lastMessageTextXPath = By.XPath($"{lastMessageXPath}//div[(@class='conversation-text ng-star-inserted')]");
        
        public static By sendButton = By.XPath("//div[(@icon='send')]");

        public static By closeAnnoyingPopUp = By.XPath("//div[(@class='popupClose')]");
        public static By conversationBackToRoomListButton = By.XPath("//div[(@test-id='conversation-back-button')]");


        public static By userNameLogin = By.XPath("//input[contains(@placeholder,'User Name')]");
        public static By passwordLogin = By.XPath("//input[contains(@placeholder,'Password')]");
    }
}
