using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace Conversation_1._0
{
    public class Room : Conversation
    {
        public List<User>? Users { get; set; }
        public List<Message>? Messages { get; set; }
        public string? roomName { get; set; }
        public bool? isBoradcastMode { get; set; }
        public RoomType? roomType { get; set; }
        public string? roomPic { get; set; }


        public enum RoomType
        {
            OneOnOne, Group, OrgUnit
        }



        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  Constructor Start <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public Room()
        {
            roomName = "";
            Users = new List<User>();
            Messages = new List<Message>();
            isBoradcastMode = false;

        }



        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Constructor End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<



        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Methods <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        public bool isToDisplaySenderNameOnLastMessage()
        {
            if(this.roomType==RoomType.OneOnOne)
            {
                return false;
            }
            else 
                return true;
        }

        public Message GetLastOrDefaultMessage()
        {
            
            Message msg = new Message();
            if (this.Messages == null)
                msg.msgText = "Start a conversation";
            else if (this.Messages != null)
            {
                msg = this.Messages.LastOrDefault();
            }

            return msg;

        }
        /*
        // Check if contained in 3 lists of supported files as defined in Message class.

        List<string> SupportedFiletypesPic = new List<string>() { ".png", ".gif", ".jpg", ".jpeg" };
        List<string> SupportedFiletypesDoc = new List<string>() { ".doc", ".docx", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx" };
        List<string> SupportedFiletypesVid = new List<string>() { ".mp4", ".mov", ".avi" };

        public bool CheckUploadedFileIsSuppported(Message msg)
        {
            Message.AttachdFileTypeClass fileCategory = new Message.AttachdFileTypeClass();
            fileCategory = msg.CatagorizeFileType(msg.attachedFilePath);
            if (fileCategory != null)
            {
                return true;

            }

            else
            {
                return false;
            }

        }
        */
    }
}