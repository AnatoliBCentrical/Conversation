using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation_1._0._IdentifierAndPopulationService
{
    internal class IDAndPopulateConversationDataRepo
    {

        public static string messageXpath = "//div[@test-id='conversation-message-container']";
        public static By messageObj = By.XPath($"//div[@test-id='conversation-message-container']");
        public static By replyMessageObj = By.XPath($"//ng-scrollbar//div[@test-id='conversation-message']");
        public static By roomObj = By.XPath($"//div[@class='conversation-room']");

        public static By messageSenderPicXPath = By.XPath(".//div[(@class='user-image gm-image ng-star-inserted circle')]");
        public static By messageSenderSubPicXPath = By.XPath(".//div[(@class='manager-image-container ng-star-inserted')]");
        public static By messageSenderNameXPath = By.XPath(".//div[(@class='sender-name ng-star-inserted')]");
        public static By messageSendDateXpath = By.XPath(".//div[(@class='message-send-date')]");
        public static By messageTextXPath = By.XPath(".//div[(@class='conversation-text ng-star-inserted')]");

        public static By ReturnReplyButtonXpathForMessage(string msgText)
        {
            try
            {
                return By.XPath($"//div[text()='{msgText}']/parent::div/parent::div//div[@test-id='conversation-reply-button']");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to return Reply ButtonXpathForMessage {msgText}. Exception:, {ex}");
            }
        }
        public static By ReturnReplyCounterXpathForMessage(string msgText)
        {
            try
            {
                return By.XPath($"//div[text()='{msgText}']/parent::div/parent::div//div[@class='reply-summary ng-star-inserted']");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to return Reply ReturnReplyCounterXpathForMessage {msgText}. Exception:, {ex}");
            }
        }

        public static string roomXpath = "//div[@class='conversation-room']";

        public static By roomName = By.XPath(".//span[@class='room-name']");
        public static By roomLastmessageSenderName = By.XPath(".//span[@test-id='conversation-preview-text-sender-name']");

        public static By RoomIconGeneral = By.XPath(".//centri-conversation-image");
        public static By roomPersonalIcon = By.XPath(".//div[@class='conversation-image gm-image ng-star-inserted circle']");
        public static By roomGroupIcon = By.XPath(".//div[@class='conversation-image gm-image isSvg ng-star-inserted']");
        public static By roomOUIcon = By.XPath(".//div[@class='conversation-team-image-container ng-star-inserted']");
        public static By roomOUIconWithUploadedImage = By.XPath(".//div[@class='conversation-image gm-image ng-star-inserted']");

        public static By roomDescryptionIndication = By.XPath(".//span[contains(@class,'room-description ng-star-inserted')]");
    }

}
