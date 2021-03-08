using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Section : BaseModel
{
    public Section()
    {
        Content = new HashSet<Content>();
        UserClientSession = new HashSet<UserClientSession>();
        WorkshopSession = new HashSet<WorkshopSession>();

    }

    [Required]
    public string Name { get; set; }
    public string Definition { get; set; }

    [Required]
    [DisplayName("Workshop")]
    public int WorkshopId { get; set; }
    public virtual Workshop Workshop { get; set; }

    public virtual ICollection<Content> Content { get; set; }
    public virtual ICollection<UserClientSession> UserClientSession { get; set; }
    public virtual ICollection<WorkshopSession> WorkshopSession { get; set; }


}

