using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Section : BaseModel
{
    public Section()
    {
        Content = new HashSet<Content>();
    }

    [Required]
    public string Name { get; set; }
    public string Definition { get; set; }
    public int? No { get; set; }

    [Required]
    public int WorkshopId { get; set; }
    public virtual Workshop Workshop { get; set; }

    public virtual ICollection<Content> Content { get; set; }

}

