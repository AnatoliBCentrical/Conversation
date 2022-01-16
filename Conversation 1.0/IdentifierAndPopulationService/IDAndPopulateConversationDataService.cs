using Conversation_1._0.Conversation_Service;
using Conversation_1._0;


using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation_1._0._IdentifierAndPopulationService
{
    internal class IDAndPopulateConversationDataService
    {
        private Infraweb infra;

        public IDAndPopulateConversationDataService(Infraweb infra)
        {
            this.infra = infra;

        }

        public List<Message> GetListOfAllMessagesInRoom()
        {
            List<Message> msgList = new List<Message>();
            List<IWebElement> messageElements = infra.GetElements(IDAndPopulateConversationDataRepo.messageObj).ToList();
            try
            {
                foreach (IWebElement messageInUI in messageElements)
                {
                    Message msg = PopulateMessageFromUI(messageInUI, infra);
                    msgList.Add(msg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"GetListOfAllMessagesInRoom Failed, {ex}");
            }

            return msgList;
        }

        public Message PopulateMessageFromUI(IWebElement webElement, Infraweb infra)
        {
            Message msg = new Message();

            msg.msgText = infra.GetElementInnerElement(webElement, IDAndPopulateConversationDataRepo.messageTextXPath).Text;
            msg.sender.fullname = infra.GetElementInnerElement(webElement, IDAndPopulateConversationDataRepo.messageSenderNameXPath).Text;
            msg.sendTime = infra.GetElementInnerElement(webElement, IDAndPopulateConversationDataRepo.messageSendDateXpath).Text;
            msg.sender.userPic = infra.GetElementInnerElement(webElement, IDAndPopulateConversationDataRepo.messageSenderPicXPath).GetAttribute("style");
            if (infra.GetElements(IDAndPopulateConversationDataRepo.ReturnReplyButtonXpathForMessage(msg.msgText)).Count > 0)
            {
                msg.Replies = ReturnListOfRepliesFromReplyScreen(msg, infra);
            }

            return msg;
        }

        public List<Message> ReturnListOfRepliesFromReplyScreen(Message msg, Infraweb infra)
        {
            List<Message> replies = new List<Message>();
            infra.ClickOn(IDAndPopulateConversationDataRepo.ReturnReplyButtonXpathForMessage(msg.msgText));
            List<IWebElement> replyElements = infra.GetElements(IDAndPopulateConversationDataRepo.replyMessageObj).ToList();
            foreach (IWebElement element in replyElements)
            {
                Message newMessage = PopulateMessageFromUI(element, infra);
                replies.Add(newMessage);
            }
            infra.ClickOn(Conversation_Repo.ConversationRepos.conversationBackToRoomListButton);
            return replies;
        }

        public List<Room> ReturnFullConversationData(ConversationService conversationService)
        {
            List<IWebElement> roomsElements = infra.GetElements(IDAndPopulateConversationDataRepo.roomObj).ToList();
            List<Room> listOfRooms = new List<Room>();


            foreach (IWebElement el in roomsElements)
            {
                Room newRoom = new Room();
                newRoom.roomName = infra.GetElementInnerElement(el, IDAndPopulateConversationDataRepo.roomName).Text;
                conversationService.OpenRoom(newRoom.roomName);
                newRoom.Messages = GetListOfAllMessagesInRoom();
                listOfRooms.Add(newRoom);
                conversationService.ClickBackToRoomList();


            }
            return listOfRooms;

        }

        public List<Room> ReturnALlRooms()
        {
            List<Room> roomList = new List<Room>();
            IList<IWebElement> roomsElements = infra.GetElements(IDAndPopulateConversationDataRepo.roomObj);
            foreach (var room in roomsElements)
            {
                Room newRoom = new Room();
                newRoom.roomName = infra.GetElementInnerElement(room, IDAndPopulateConversationDataRepo.roomName).Text;
                //newRoom.roomPic = infra.GetElementInnerElement(room, IDAndPopulateConversationDataRepo.RoomIconGeneral).Text;
                if (infra.GetElementInnerElement(room, IDAndPopulateConversationDataRepo.roomGroupIcon) != null)
                    newRoom.roomType = Room.RoomType.Group;
                else if (infra.GetElementInnerElement(room, IDAndPopulateConversationDataRepo.roomOUIcon) != null)
                    newRoom.roomType = Room.RoomType.OrgUnit;
                else if (infra.GetElementInnerElement(room, IDAndPopulateConversationDataRepo.roomPersonalIcon) != null)
                    newRoom.roomType = Room.RoomType.OneOnOne;
                else
                    throw new Exception($"Room type was not recognized by room pic {newRoom.roomName}");
                roomList.Add(newRoom);

            }
            return roomList;
        }
        public List<Message> ReturnAllMessagesInRoom()
        {
            List<Message> msgList = new List<Message>();
            IList<IWebElement> MsgElements = infra.GetElements(IDAndPopulateConversationDataRepo.messageObj);
            foreach (var msg in MsgElements)
            {
                Message newMessage = new Message();

                newMessage.msgText = infra.GetElementInnerElement(msg, IDAndPopulateConversationDataRepo.messageTextXPath).Text;
                newMessage.sender.fullname = infra.GetElementInnerElement(msg, IDAndPopulateConversationDataRepo.messageSenderNameXPath).Text;
                newMessage.sender.fullname = infra.GetElementInnerElement(msg, IDAndPopulateConversationDataRepo.messageSenderNameXPath).Text;
                newMessage.sendTime = infra.GetElementInnerElement(msg, IDAndPopulateConversationDataRepo.messageSendDateXpath).Text;
                newMessage.sender.userPic = infra.GetElementInnerElement(msg, IDAndPopulateConversationDataRepo.messageSenderPicXPath).GetAttribute("style");
                msgList.Add(newMessage);
            }
            foreach (Message msg in msgList)
            {
                if (infra.GetElements(IDAndPopulateConversationDataRepo.ReturnReplyButtonXpathForMessage(msg.msgText)).Count > 0)
                {
                    msg.Replies = ReturnListOfRepliesFromReplyScreen(msg, infra);
                }
            }
            return msgList;
        }

        public List<Message> ReturnAllRepliesForMessage(Message message)
        {

            List<Message> replies = new List<Message>();
            infra.ClickOn(IDAndPopulateConversationDataRepo.ReturnReplyButtonXpathForMessage(message.msgText));
            List<IWebElement> replyElements = infra.GetElements(IDAndPopulateConversationDataRepo.replyMessageObj).ToList();
            foreach (IWebElement element in replyElements)
            {
                Message newMessage = PopulateMessageFromUI(element, infra);
                replies.Add(newMessage);
            }
            infra.ClickOn(Conversation_Repo.ConversationRepos.conversationBackToRoomListButton);
            return replies;
        }

        public List<Room> PopulateAndCreateConversationData(ConversationService conversation)
        {
            List<Room> rooms = ReturnALlRooms();
            foreach (Room room in rooms)
            {
                conversation.OpenRoom(room.roomName);
                room.Messages = ReturnAllMessagesInRoom();
                conversation.ClickBackToRoomList();
            }
            return rooms;
        }

    }
}

