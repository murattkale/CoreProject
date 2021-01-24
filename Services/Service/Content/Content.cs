using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public partial class Content : BaseModel
{
    public Content()
    {
        Documents = new HashSet<Documents>();
        ResponseData = new HashSet<ResponseData>();
        ActionData = new HashSet<ActionData>();

    }


    [Required]
    public bool Interaction { get; set; }

    [Required]
    public string ContentData { get; set; }

    [Required]
    public DocumentType DocumentType { get; set; }

    [Required]
    public ResponseType ResponseType { get; set; }

    public string VideoLink { get; set; }

    public string DocVideoDesc { get; set; }

    [Required]
    public int SectionId { get; set; }
    public virtual Section Section { get; set; }


    public virtual ICollection<Documents> Documents { get; set; }
    public virtual ICollection<ResponseData> ResponseData { get; set; }
    public virtual ICollection<ActionData> ActionData { get; set; }

}

