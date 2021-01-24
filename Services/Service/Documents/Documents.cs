using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Documents : BaseModel
{
    public Documents()
    {

    }


    public string Types { get; set; }

    public string Name { get; set; }

    public string Link { get; set; }

    public string Guid { get; set; }

    public string Alt { get; set; }

    public string Title { get; set; }



    public int? ContentId { get; set; }
    public Content Content { get; set; }



}

