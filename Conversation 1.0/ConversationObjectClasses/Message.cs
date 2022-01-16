using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using Conversation_1._0.ConversationClasses;
using Conversation_1._0.Conversation_Service;

namespace Conversation_1._0
{
    public class Message : Room
    {

        public string? msgText { get; set; }
        public string? icon { get; set; }

        public string? sendTime { get; set; }

        public User? sender { get; set; }

        public List<Message>? Replies { get; set; }
        public AttachedFileType? attachedFileType { get; set; }
        public MessageType? messageType { get; set; }
        public Reaction? reaction { get; set; }

        public enum AttachedFileType
        {
            Pic, Doc, Vid
        }
        public enum MessageType
        {
            Coaching, Badge
        }

        public enum Reaction
        {
            Clear, Happy, Heart, Like, Dislike, Lightbulb
        }

        public Message()
        {
            
            sender = new User();
            sendTime = "";
        }
        //public class AttachdFileTypeClass
        //{
        //    attachedFileType AFT;
        //
        //    public AttachdFileTypeClass()
        //    {
        //
        //    }
        //    public attachedFileType EnumProperty
        //    {
        //        get
        //        {
        //            return AFT;
        //        }
        //        set
        //        {
        //            AFT = value;
        //        }
        //    }
        //}


        /*
                //Supported File types for each type of upload

                List<string> SupportedFiletypesPic = new List<string>() { ".png", ".gif", ".jpg", ".jpeg" };
                List<string> SupportedFiletypesDoc = new List<string>() { ".doc", ".docx", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx" };
                List<string> SupportedFiletypesVid = new List<string>() { ".mp4", ".mov", ".avi" };

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Constructor Start <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                public Message()
                {
                    sender = new User();
                    msgText = "";
                    attachedFilePath = "";

                }

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Constructor End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Accessors Start <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                public string fileExtension   
                {
                    get
                    {
                        FileInfo fi = new FileInfo(attachedFilePath);
                        string extn = fi.Extension;

                        return extn;
                    }
                    set { }
                }
                public string attachedFileName
                {
                    get
                    {
                        string filename = Path.GetFileName(attachedFilePath);
                        return filename;
                    }
                     set { }
                }

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> MessageTxt Accessors End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Methods <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                public AttachdFileTypeClass CatagorizeFileType(string attachedFile)
                    //Checks for the type of the file as to help identify the desired dispay of the placeholder later on
                {
                    AttachdFileTypeClass attachdFileType = new AttachdFileTypeClass();
                    FileInfo fi = new FileInfo(attachedFile);
                    string extn = fi.Extension;
                    if (SupportedFiletypesPic.Contains(extn))
                    {
                        attachdFileType.EnumProperty = attachedFileType.Pic;
                    }
                    else if (SupportedFiletypesDoc.Contains(extn))
                    {
                        attachdFileType.EnumProperty = attachedFileType.Doc;
                    }
                    else if (SupportedFiletypesVid.Contains(extn))
                    {
                        attachdFileType.EnumProperty = attachedFileType.Vid;
                    }
                    else
                    { 
                        //need to learn error handling.
                    attachdFileType.EnumProperty = attachedFileType.Null;
                    }
                    return attachdFileType;
                }


            }
        */

    }
}

