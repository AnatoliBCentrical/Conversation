using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conversation_1._0.Validations
{
    public static class Validations
    {
        public static void ElementIsNull(IWebElement? el, bool expectedNull)
        {
            if (el == null && expectedNull)
                return;
            else if (el != null && expectedNull)
                throw new Exception("the element is not null but expected to be null");
            else if (el != null && !expectedNull)
                return;
            else if (el == null && !expectedNull)
                throw new Exception("the element is null but expected to be not null");
            else
                throw new Exception("You shouldnt be reading this message - Function name ElementIsNull");
        }


        public static bool StringCompare(string excepeted, string actual)
        {
            return
                 excepeted.Equals(actual);
        }

        public static bool DateCompare(DateTime excepeted, DateTime actual)
        {
            return
                 excepeted.Equals(actual);
        }
        public static bool ConversationDataCompare(List<Room> excepeted, List<Room> actual)
        {
            return
                 excepeted.Equals(actual);
        }

        /////////////////////////   User Validations
        /////////////////////////   Start here 

        public static bool ValidateUserLastName(User user1, User user2)
        {
            try
            {
                return user1.lastname.Equals(user2.lastname);
            }
            catch (Exception ex)
            {
                throw new Exception($"Compared Users have different last names . User 1 is ({user1.lastname}) and the 2nd user is ({user2.lastname}, {ex}.)");
            }
        }
        public static bool ValidateUserFirstName(User user1, User user2)
        {
            try
            {
                return user1.firstname.Equals(user2.firstname);
            }
            catch (Exception ex)
            {
                throw new Exception($"Compared Users have different first names . User 1 is ({user1.firstname}) and the 2nd user is ({user2.firstname}), {ex}.");
            }
        }
        public static bool ValidateUserFullName(User user1, User user2)
        {
            try
            {
                return user1.fullname.Equals(user2.fullname);
            }
            catch (Exception ex)
            {
                throw new Exception($"Compared Users have different fullnames. User 1 is ({user1.fullname}) and the 2nd user is ({user2.fullname}), {ex}.");
            }
        }
        public static bool ValidateUserUserPic(User user1, User user2)
        {
            try
            {
                return user1.userPic.Equals(user2.userPic);
            }
            catch (Exception ex)
            {
                throw new Exception($"Compared Users have different user Pics. User 1 is ({user1.userPic}) and the 2nd user is ({user2.userPic}), {ex}.");
            }
        }
        public static bool ValidateUserPermissions(User user1, User user2)
        {
            try
            {
                CollectionAssert.AreEquivalent(user1.permission, user2.permission);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Compared Users have different permissions. User 1 is ({user1.permission}) and the 2nd user is ({user2.permission}), {ex}.");
            }
        }

        public static bool ValidateUser(User user1, User user2)
        {

            ValidateUserLastName(user1, user2);
            ValidateUserFirstName(user1, user2);
            ValidateUserFullName(user1, user2);
            ValidateUserUserPic(user1, user2);
            ValidateUserPermissions(user1, user2);
            return true;

        }

        /////////////////////////   Message Validations
        /////////////////////////   Start here 
        public static string ValidateMessageMsgText(Message CorrectBase, Message ComparedTo)
        {
            if (CorrectBase.msgText.Equals(ComparedTo.msgText))
            {
                return $"Messages have different message text.Message 1 is ({ CorrectBase.msgText }) and the 2nd message is ({ ComparedTo.msgText })";
            }
            //try
            //{
            //    return CorrectBase.msgText.Equals(ComparedTo.msgText);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"Messages have different message text. Message 1 is ({CorrectBase.msgText}) and the 2nd message is ({ComparedTo.msgText}), {ex}.");
            //}
        }
        public static bool ValidateMessageIcon(Message CorrectBase, Message ComparedTo)
        {
            try
            {
                return CorrectBase.icon.Equals(ComparedTo.icon);
            }
            catch (Exception ex)
            {
                throw new Exception($"Messages have different icons . Message 1 is ({CorrectBase.icon}) and the 2nd message is ({ComparedTo.icon}, {ex}.)");
            }
        }
        public static bool ValidateMessageSendTime(Message CorrectBase, Message ComparedTo)
        {
            try
            {
                return CorrectBase.sendTime.Equals(ComparedTo.sendTime);
            }
            catch (Exception ex)
            {
                throw new Exception($"Messages have different sendTimes. Message 1 is ({CorrectBase.sendTime}) and the 2nd message is ({ComparedTo.sendTime }, {ex}.)");
            }
        }
        public static bool ValidateMessageSender(Message CorrectBase, Message ComparedTo)
        {
            try
            {
                return ValidateUser(CorrectBase.sender, ComparedTo.sender);
            }
            catch (Exception ex)
            {
                throw new Exception($"Messages have different senders. Message 1 is ({CorrectBase.sender}) and the 2nd message is ({ComparedTo.sender}, {ex}.)");
            }
        }
        public static bool ValidateMessageReplies(Message CorrectBase, Message ComparedTo)
        {
            int i = 0;
            foreach (var reply in CorrectBase.Replies)
            {
                ValidateMessages(CorrectBase.Replies[i], ComparedTo.Replies[i]);
                i++;
            }
            return true;
        }
        public static bool ValidateMessageAttachedFileType(Message CorrectBase, Message ComparedTo)
        {
            try
            {
                return CorrectBase.attachedFileType.Equals(ComparedTo.attachedFileType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Messages have different attachedFileType. Message 1 is ({CorrectBase.attachedFileType}) and the 2nd message is ({ComparedTo.attachedFileType}, {ex}.)");
            }
        }
        public static bool ValidateMessageMessageType(Message CorrectBase, Message ComparedTo)
        {
            try
            {
                return CorrectBase.messageType.Equals(ComparedTo.messageType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Messages have different attachedFileType. Message 1 is ({CorrectBase.messageType}) and the 2nd message is ({ComparedTo.messageType}, {ex}).");
            }
        }
        public static bool ValidateMessageReaction(Message CorrectBase, Message ComparedTo)
        {
            try
            {
                return CorrectBase.reaction.Equals(ComparedTo.reaction);
            }
            catch (Exception ex)
            {
                throw new Exception($"Messages have different reactions . Message 1 is ({CorrectBase.reaction}) and the 2nd message is ({ComparedTo.reaction}), {ex}.");
            }
        }

        public static bool ValidateMessages(Message CorrectBase, Message ComparedTo)
        {
            List<string> errors = new List<string>();
            errors.Add(ValidateMessageMsgText (CorrectBase, ComparedTo));
            errors.Add(ValidateMessageIcon(CorrectBase, ComparedTo));
            errors.Add(ValidateMessageSendTime(CorrectBase, ComparedTo));
            errors.Add(ValidateMessageSender(CorrectBase, ComparedTo));
            errors.Add(ValidateMessageReplies(CorrectBase, ComparedTo));
            errors.Add(ValidateMessageAttachedFileType(CorrectBase, ComparedTo));
            errors.Add(ValidateMessageMessageType(CorrectBase, ComparedTo));
            errors.Add(ValidateMessageReaction(CorrectBase, ComparedTo));

            if (errors.Any())
            {
                throw new Exception(string.Join(",", errors)); //Icon, replais, reaction
            }
                
                    
                    return true;
        }

        /////////////////////////        Room Validations
        /////////////////////////        Start Here

        public static bool ValidateRoomUsers(Room CorrectBase, Room ComparedTo)
        {
            int i = 0;
            foreach (var user in CorrectBase.Users)
            {
                ValidateUser(CorrectBase.Users[i], ComparedTo.Users[i]);
                i++;
            }
            return true;
        }
        public static bool ValidateRoomMessages(Room CorrectBase, Room ComparedTo)
        {
            int i = 0;
            foreach (var message in CorrectBase.Messages)
            {
                ValidateMessages(CorrectBase.Messages[i], ComparedTo.Messages[i]);
                i++;
            }
            return true;

        }
        public static bool ValidateRoomRoomName(Room CorrectBase, Room ComparedTo)
        {
            try
            {
                return CorrectBase.roomName.Equals(ComparedTo.roomName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Rooms have different Room names. CorrectBase is {CorrectBase.roomName}, ComparedTo is {ComparedTo.roomName}, {ex}.");
            }
        }

        public static bool ValidateRoomIsBoradcastMode(Room CorrectBase, Room ComparedTo)
        {
            try
            {
                return CorrectBase.isBoradcastMode.Equals(ComparedTo.isBoradcastMode);
            }
            catch (Exception ex)
            {
                throw new Exception($"Rooms are not same on broadcast mode status. CorrectBase is {CorrectBase.isBoradcastMode }, ComparedTo is {ComparedTo.isBoradcastMode }, {ex}.");
            }
        }

        public static bool ValidateRoomRoomPic(Room CorrectBase, Room ComparedTo)
        {
            try
            {
                return CorrectBase.roomPic.Equals(ComparedTo.roomPic);
            }
            catch (Exception ex)
            {
                throw new Exception($"Rooms Have different icons, {ex}.");
            }
        }

        public static bool ValidateRooms(Room CorrectBase, Room ComparedTo)
        {
            ValidateRoomUsers(CorrectBase, ComparedTo);
            ValidateRoomMessages(CorrectBase, ComparedTo);
            ValidateRoomRoomName(CorrectBase, ComparedTo);
            ValidateRoomIsBoradcastMode(CorrectBase, ComparedTo);
            ValidateRoomRoomPic(CorrectBase, ComparedTo);
            return true;
        }

        public static bool ValidateRoomList(List<Room> CorrectBase, List<Room> ComparedTo)
        {
            int i = 0;
            foreach (Room room in CorrectBase)
            {
                ValidateRooms(CorrectBase[i],ComparedTo[i]);
            }
            return true;
        }


    }
}

