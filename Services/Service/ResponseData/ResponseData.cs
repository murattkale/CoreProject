using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class ResponseData : BaseModel
{
    public ResponseData()
    {
        ActionData = new HashSet<ActionData>();
    }

    [Required]
    public string ReponseContent { get; set; }

    [Required]
    public ResponseType ResponseType { get; set; }

    [Required]
    public int ContentId { get; set; }
    public virtual Content Content { get; set; }

    public virtual ICollection<ActionData> ActionData { get; set; }

}

