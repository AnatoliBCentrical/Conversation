using Conversation_1._0.Login;
using Conversation_1._0.Validations;
using Conversation_1._0.Conversation_Service;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Conversation_1._0.Conversation_Repo;

namespace Conversation_1._0.Conversation_Service
{
    internal class ConversationService
    {
        private Infraweb infra;

        public ConversationService(Infraweb infra)
        {
            this.infra = infra;
        }


        public void OpenRoom(string roomName)
        {
            try
            {
                infra.ClickOn(ConversationRepos.GetRoomPath(roomName));
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to OpenRoom {roomName}. Exception:, {ex}");
            }
        }

        public void SetConversationData(Conversation conversaion)
        {
            foreach (var room in conversaion.RoomList)
            {
                SetRoomData(conversaion, room);
            }
        }

        private void SetRoomData(Conversation conversaion, Room room)
        {
            if (conversaion.RoomList.LastOrDefault() == room && conversaion.RoomList.Count > 1)//last room
            {
                ClickBackToRoomList();
            }
            OpenRoom(room.roomName);

            foreach (var msg in room.Messages)
            {
                SetMessageData(msg);
            }
        }

        private void SetMessageData(Message msg)
        {
            InsertMessageAndSend(msg);
            if (msg.Replies != null)
            {
                OpenRepliesScreenToMessage(msg.msgText);
                foreach (var reply in msg.Replies)
                {
                    SetReplyData(msg, reply);
                }
            }
        }

        private void SetReplyData(Message msg, Message reply)
        {
            if (reply.msgText != null && reply.msgText != String.Empty)
            {
                InsertMessageAndSend(reply);
            }

            if (msg.Replies.LastOrDefault() == reply)
            {
                ClickBackToRoomList();
            }
        }

        public Message SelectLastMessageInRoom(bool isExpandMode)

        {
            Message msg = new Message();
            var messages = infra.GetElements(By.XPath("(//conversation-message)[last()]"));
            if (messages.Count > 0)
            {
                IWebElement lastmessage = messages.LastOrDefault();

                IWebElement lastMessageSenderPic = infra.GetElementInnerElement(lastmessage, ConversationRepos.lastMessageSenderPicXPath);

                IWebElement lastMessageText;
                IWebElement lastMessageSenderName;
                IWebElement lastMessageDate;

                lastMessageText = infra.GetElement(ConversationRepos.lastMessageTextXPath);
                lastMessageSenderName = infra.GetElement(ConversationRepos.lastMessageSenderNameXPath);
                lastMessageDate = infra.GetElement(ConversationRepos.lastMessageSendDateXpath);



                Validations.Validations.ElementIsNull(lastmessage, false);
                msg.msgText = lastMessageText.Text;
                msg.sender.userPic = lastMessageSenderPic.GetAttribute("style");
                msg.sender.fullname = lastMessageSenderName.Text;
                msg.sendTime = lastMessageDate.Text;
            }
            else if (messages.Count == 0)
            {
                msg.msgText = "Start a conversation";

            }

            return msg;
        }

        internal void ClickOnExpandMode(bool? isExpandMode)
        {
            if (isExpandMode != null)
            {
                if ((bool)isExpandMode)
                {
                    infra.ClickOn(ConversationRepos.conversationHeader);//expand path
                }
            }
        }

        public void OpenConversation()
        {
            infra.ClickOn(ConversationRepos.conversationHeader);

        }
        public void CloseConversation()
        {
            infra.ClickOn(ConversationRepos.conversationHeader);

        }

        public void SelectRoom(string room)
        {
            infra.ClickOn(ConversationRepos.GetRoomPath(room));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// 

        public void OpenRepliesScreenToMessage(string msgTxt)
        {
            infra.ClickOn(ConversationRepos.GetMessageReplyXpath(msgTxt));
        }
        public void InsertMessageAndSend(Message message)
        {
            try
            {
                infra.InsertText(ConversationRepos.textBox, message.msgText);
                infra.ClickOn(ConversationRepos.sendButton);
            }

            catch (Exception ex)
            {
                throw new Exception($"Failed to send message {message.msgText}. Exception:, {ex}");
            }

            message.sender.fullname = "Me";
            //message.sendTime = DateTime.Now;
        }

        internal void ClickBackToRoomList()
        {
            infra.ClickOn(ConversationRepos.conversationBackToRoomListButton);
        }

        public void OnlyInsertMessage(Message message)
        {
            infra.InsertText(ConversationRepos.textBox, message.msgText);
        }



        //**

        public static string TruncateSenderAndMessage(Room room)
        {
            string truncationSuffix = "…";
            int maxLength = 25;
            string fullString = "";
            Message msg = room.GetLastOrDefaultMessage();
            if (msg.isToDisplaySenderNameOnLastMessage())
            {
                fullString = $"{msg.sender}: {msg.msgText}";
            }
            else
            {
                fullString = msg.msgText;
            }


            if (fullString.Length > maxLength)
            {
                fullString = fullString.Substring(0, maxLength) + truncationSuffix;
            }

            return fullString;
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
