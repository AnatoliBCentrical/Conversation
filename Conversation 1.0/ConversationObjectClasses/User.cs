using Conversation_1._0.Conversation_Repo;
using Conversation_1._0.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conversation_1._0
{
    public class User
    {
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? fullname { get; set; }        
        public string? userPic { get; set; }
        public List<Permissions>? permission { get; set; }
        public User()
        {
            userName = "ariel.herman";
            fullname = "Ariel Herman";
            password = "Aa123456";
            userPic = ConversationRepos.defaultUserPic;
                
        }    
        public string GetFullName()
        {
            string fullname = string.Format("{0} {1}", firstname, lastname);
            return fullname;
        }
    }

    public enum Permissions { NoPermissions, TeamLeader, ConversationManager }
}
     
    

