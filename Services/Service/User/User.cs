using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;


public partial class User : BaseModel
{
    public User()
    {
        WorkshopSession = new HashSet<WorkshopSession>();
    }


    public string UserName { get; set; }
    public string Pass { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public int? LoginCount { get; set; }


    public virtual ICollection<WorkshopSession> WorkshopSession { get; set; }
}

