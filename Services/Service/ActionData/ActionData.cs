using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class ActionData : BaseModel
{
    public ActionData()
    {
    }

    [Required]
    public int ResponseDataId { get; set; }
    public virtual ResponseData ResponseData { get; set; }

    [Required]
    public int ContentID { get; set; }
    public virtual Content Content { get; set; }

    public ActionType ActionType { get; set; }

}

