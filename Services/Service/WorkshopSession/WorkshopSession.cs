using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class WorkshopSession : BaseModel
{
    public WorkshopSession()
    {
    }

    public int SectionId { get; set; }
    public int WorkshopId { get; set; }
    public int UserId { get; set; }


    public virtual Section Section { get; set; }
    public virtual Workshop Workshop { get; set; }
    public virtual User User { get; set; }
}

