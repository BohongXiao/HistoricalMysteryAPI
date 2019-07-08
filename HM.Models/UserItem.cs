using System;

namespace HM.Models
{
    public class UserItem
    {
        int UserId { get; set; }

        string UserName { get; set; }

        string UserFirstName { get; set; }

        string UserMiddleName { get; set; }

        string UserLastName { get; set; }

        string EmailAddress { get; set; }

        string MobileNumber { get; set; }

        string UserAvatar { get; set; }

        string UserSelfDescription { get; set; }

        DateTime CreationDateTime { get; set; }
    }
}
