using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Workshop : BaseModel
{
    public Workshop()
    {
        Section = new HashSet<Section>();
    }

    [Required]
    public string Name { get; set; }
    public string Definition { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }
    public DateTime? PublishDate { get; set; }
    public int? PublishDuration { get; set; }


    public virtual ICollection<Section> Section { get; set; }
}

