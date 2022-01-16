using Conversation_1._0.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conversation_1._0
{
    internal class RoomListOld : SeleniumBase
    {
        //public List<Tuple<Room, Message>> SortConversations(List<Room> listOfAllRooms)
        //{
        //    List<Tuple<Room, Message>> sortedOneOnOneConversations = new List<Tuple<Room, Message>>();
        //    List<Tuple<Room, Message>> sortedGroupConversations = new List<Tuple<Room, Message>>();
    
        //    foreach (Room room in listOfAllRooms)
        //    {
        //        if (room.RoomType == room)
        //        {
        //            sortedOneOnOneConversations.Add(new Tuple<Room, Message>(room, room.LastMessage));
        //        }
        //        else
        //        {
        //            sortedGroupConversations.Add(new Tuple<Room, Message>(room, room.LastMessage));
        //        }
    
        //    }
        //    //Sort SortedOneOnOneConversations by Message.sendTime
        //    //Sort SortedGroupConversations by Message.sendTime
        //    List<Tuple<Room, Message>> orderedAndSortedGroupConversations = sortedGroupConversations.OrderBy(N => N.Item2.SendTime).ToList();
        //    List<Tuple<Room, Message>> orderedAndSortedOneOnOneConversations = sortedOneOnOneConversations.OrderBy(N => N.Item2.SendTime).ToList();
        //    // create new list and merge the two ordered lists to it in order Group > 1*1
        //    List<Tuple<Room, Message>> sortedRooms = new List<Tuple<Room, Message>>();
        //    sortedRooms.AddRange(orderedAndSortedGroupConversations);
        //    sortedRooms.AddRange(orderedAndSortedOneOnOneConversations);
        //    return sortedRooms;
    
        //}

        public void SSS()
        { 
            //Assert.IsTrue(Validations.StringCompare("x", "x"), "string are equals");
        }
    }
}   //
    