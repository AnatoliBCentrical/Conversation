using System;
using Conversation_1._0.Login;
using Conversation_1._0.Conversation_Service;
using Conversation_1._0.Validations;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using Conversation_1._0._IdentifierAndPopulationService;
using System.Linq;


namespace Conversation_1._0
{
    public class LoginTests : SeleniumBase
    {
        public static IEnumerable<TestCaseData> Test
        {
            get
            {
                yield return new TestCaseData(
                new Conversation
                {
                    RoomList = new List<Room>
                    {
                        new Room
                        {
                            roomName = "Dev1",
                            Messages = new List<Message>
                            {
                              new Message
                                {
                                    msgText = ConversationService.RandomString(10)
                                },
                              new Message
                              {
                                  msgText = ConversationService.RandomString(10)
                              }
                            }
                        },
                          new Room
                        {
                            roomName = "2808",
                            Messages = new List<Message>
                            {
                              new Message
                                {
                                    msgText = "bi Anatoly"
                                },
                              new Message
                              {
                                  msgText = "bi Adiel"
                              }
                            }
                        },

                    }
                }
                ).SetName("DefaultConversaion");

                yield return new TestCaseData(
                new Conversation
                {
                    RoomList = new List<Room>
                    {
                        new Room
                        {
                            roomName = "Dev1",
                            Messages = new List<Message>
                            {
                              new Message
                                {
                                    msgText = ConversationService.RandomString(10),
                                    Replies = new List<Message>()
                                    {
                                        new Message
                                        { msgText = null }
                                    },
                                },
                              new Message
                              {
                                  msgText = ConversationService.RandomString(10),
                                  Replies = new List<Message>()
                                    {
                                        new Message
                                        {  },
                                         new Message
                                        { msgText = ConversationService.RandomString(10) },
                                  }

                              }
                            }
                        },
                          new Room
                        {
                            roomName = "2808",
                            Messages = new List<Message>
                            {
                              new Message
                                {
                                    msgText = ConversationService.RandomString(10),
                                    Replies = new List<Message>()
                                    {
                                        new Message
                                        { msgText = ConversationService.RandomString(10) }
                                    },

                                },
                              new Message
                              {
                                  msgText = ConversationService.RandomString(10)
                              }
                            }
                        },

                    }
                }
                ).SetName("ReplyTest");
                yield return new TestCaseData(
                new Conversation
                {
                    isExpandMode = true
                }
                ).SetName("DefaultConversaionWithExpandMode");
            }
        }

        [TestCaseSource("Test")]
        public void SendMessageToChatAndValidateIsMessageIsLast(Conversation conversaion)
        {
            //Arrange
            LoginService loginService = new LoginService(_Infra);
            ConversationService conversationService = new ConversationService(_Infra);
            var lastMssageFromObj = conversaion.RoomList.FirstOrDefault().Messages.LastOrDefault().msgText;

            //Act
            loginService.LoginToUser(@"https://ge4getst2.gameffective.me/w");
            //loginService.CloseLoginPopup();
            conversationService.OpenConversation();
            conversationService.ClickOnExpandMode(conversaion.isExpandMode);
            conversationService.SetConversationData(conversaion);

            //Assert
            var lastMessageInRoom = conversationService.SelectLastMessageInRoom(false);
            Assert.IsTrue(Validations.Validations.StringCompare(lastMessageInRoom.msgText, lastMssageFromObj));
        }


        [TestCaseSource("Test")]
        public void SendMessageToChatAndValidateUserName(Conversation conversaion)
        {
            //Arrange
            LoginService loginService = new LoginService(_Infra);
            ConversationService conversationService = new ConversationService(_Infra);
            var lastUserName = conversaion.RoomList.FirstOrDefault().Messages.LastOrDefault().Users.LastOrDefault().userName;

            //Act
            loginService.LoginToUser(@"https://ge4getst2.gameffective.me/w");
            //loginService.CloseLoginPopup();
            conversationService.OpenConversation();
            conversationService.ClickOnExpandMode(conversaion.isExpandMode);
            conversationService.SetConversationData(conversaion);

            //Assert
            var lastUseranAMEfROMui = conversationService.SelectLastMessageInRoom(false).Users.LastOrDefault().userName;
            Assert.IsTrue(Validations.Validations.StringCompare(lastUseranAMEfROMui, lastUserName));
        }

        [TestCaseSource("Test")]
        public void SendMessageToChatAndValidateUserImage(Conversation conversaion)
        {
            //Arrange
            LoginService loginService = new LoginService(_Infra);
            ConversationService conversationService = new ConversationService(_Infra);
            var lastUserPic = conversaion.RoomList.FirstOrDefault().Messages.LastOrDefault().Users.LastOrDefault().userName;

            //Act
            loginService.LoginToUser(@"https://ge4getst2.gameffective.me/w");
            //loginService.CloseLoginPopup();
            conversationService.OpenConversation();
            conversationService.ClickOnExpandMode(conversaion.isExpandMode);
            conversationService.SetConversationData(conversaion);

            //Assert
            var lastUserFromUI = conversationService.SelectLastMessageInRoom(false).Users.LastOrDefault().userPic;
            Assert.IsTrue(Validations.Validations.StringCompare(lastUserFromUI, lastUserPic));
        }

        [TestCaseSource("Test")]
        public void SendMessageToChatAndValidateMessageDate(Conversation conversaion)
        {
            //Arrange
            LoginService loginService = new LoginService(_Infra);
            ConversationService conversationService = new ConversationService(_Infra);
            var lastMessageDate = conversaion.RoomList.FirstOrDefault().Messages.LastOrDefault().sendTime;

            //Act
            loginService.LoginToUser(@"https://ge4getst2.gameffective.me/w");
            //loginService.CloseLoginPopup();
            conversationService.OpenConversation();
            conversationService.ClickOnExpandMode(conversaion.isExpandMode);
            conversationService.SetConversationData(conversaion);

            //Assert
            var lastUserFromUI = conversationService.SelectLastMessageInRoom(false).sendTime;
            Assert.IsTrue(Validations.Validations.StringCompare(lastUserFromUI, lastMessageDate));
        }

        [Test]
        public void testingPopulation()
        {
            LoginService loginService = new LoginService(_Infra);
            ConversationService conversationService = new ConversationService(_Infra);
            IDAndPopulateConversationDataService identifierAndPopulationService = new IDAndPopulateConversationDataService(_Infra);
            loginService.LoginToUser(@"https://ge4getst2.gameffective.me/w");
            conversationService.OpenConversation();
            //identifierAndPopulationService.ReturnFullConversationData(conversationService);
            identifierAndPopulationService.PopulateAndCreateConversationData(conversationService);





        }

    }
}