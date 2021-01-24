using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;


public partial class User : BaseModel
{
    public User()
    {
    }


    public string UserName { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string LdapId { get; set; }


}

