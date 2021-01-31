using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;


public partial class UserClient : BaseModel
{
    public UserClient()
    {
        UserClientSession = new HashSet<UserClientSession>();
    }



    public string Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<UserClientSession> UserClientSession { get; set; }
}

