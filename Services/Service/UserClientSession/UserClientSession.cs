using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;


public partial class UserClientSession : BaseModel
{
    public UserClientSession()
    {
    }



    public int UserClientId { get; set; }
    public UserClient UserClient { get; set; }

    public int? SectionId { get; set; }
    public Section Section { get; set; }


    public string SessionGuid { get; set; }


}

